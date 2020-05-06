using System;
using System.Net;
using CalculationService.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Grains.Sample;
using Orleans.Hosting;
using Orleans.SiloGrpc.Services;
using Serilog;
using Serilog.Events;

namespace Orleans.SiloGrpc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true); // Allows to send unencrypted gRPC requests
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureServices((webHostBuilderContext, services) =>
                        {
                            services.AddGrpc();
                            // EndpointDefaults { "Protocols": "Http1AndHttp2" } requires some weired handshake to be done by the client. So using Http2 only for now here
                        })
                        .Configure((context, app) =>
                        {
                            if (context.HostingEnvironment.IsDevelopment())
                            {
                                app.UseDeveloperExceptionPage();
                            }

                            app.UseRouting();
                            app.UseEndpoints(endpoints =>
                            {
                                endpoints.MapGrpcService<GreeterService>();
                                // endpoints.MapGrpcService<ProxyDataSource>();
                                endpoints.MapGrpcService<CacheDataSource>();
                                endpoints.MapGrpcService<CacheControl>();
                                
                                endpoints.MapGet("/",
                                    async httpContext =>
                                    {
                                        await httpContext.Response.WriteAsync(
                                            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                                    });
                            });
                        })
                        .UseUrls("http://0.0.0.0:8082");
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddFilter("Orleans.Runtime.Management.ManagementGrain", LogLevel.Warning);
                    builder.AddFilter("Orleans.Runtime.SiloControl", LogLevel.Warning);
                    builder.AddSerilog(new LoggerConfiguration()
                        .WriteTo.Console()
                        .Filter.ByExcluding(e => e.Properties["SourceContext"].ToString() == @"""Orleans.Runtime.Management.ManagementGrain""" && e.Level < LogEventLevel.Warning)
                        .Filter.ByExcluding(e => e.Properties["SourceContext"].ToString() == @"""Orleans.Runtime.SiloControl""" && e.Level < LogEventLevel.Warning)
                        .CreateLogger());
                })
                .ConfigureServices(services =>
                {
                    services.Configure<ConsoleLifetimeOptions>(options =>
                    {
                        options.SuppressStatusMessages = true;
                    });
                    services.AddGrpcClient<CalculationService.DataSource.DataSourceClient>(o =>
                    {
                        o.Address = new Uri("http://127.0.0.1:8085");
                        o.ChannelOptionsActions.Add(options => options.Credentials = ChannelCredentials.Insecure); // TODO: Probably not needed
                    });
                    services.AddGrpcHttpApi();
                })
                .UseOrleans(builder =>
                {
                    builder.ConfigureApplicationParts(manager =>
                    {
                        manager.AddApplicationPart(typeof(WeatherGrain).Assembly).WithReferences();
                    });
                    builder.UseLocalhostClustering();
                    // builder.UseDevelopmentClustering((IPEndPoint) null /*IPEndPoint.Parse("127.0.0.1:11111")*/);
                    builder.Configure<ClusterOptions>(options =>
                    {
                        options.ClusterId = "Megathon Cluster";
                        options.ServiceId = "ASF Caching";
                    });
                    // builder.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30001);
                    builder.Configure<EndpointOptions>(options =>
                    {
                        // Port to use for Silo-to-Silo
                        options.SiloPort = 11111;
                        // Port to use for the gateway
                        options.GatewayPort = 30000;
                        // IP Address to advertise in the cluster
                        // options.AdvertisedIPAddress = IPAddress.Parse("172.16.0.42");
                        // The socket used for silo-to-silo will bind to this endpoint
                        options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 30000);
                        // The socket used by the gateway will bind to this endpoint
                        options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 11111);

                    });
                    builder.AddMemoryGrainStorageAsDefault();
                    builder.AddSimpleMessageStreamProvider("SMS");
                    builder.AddMemoryGrainStorage("PubSubStore");
                    builder.UseDashboard(options =>
                    {
                        options.HideTrace = true;
                        options.Port = 8081;
                    });
                });
    }
}