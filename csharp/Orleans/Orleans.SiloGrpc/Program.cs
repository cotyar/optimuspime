using System;
using CalculationService.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
                        .UseUrls("http://localhost:8082");
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
                        o.Address = new Uri("http://localhost:8085");
                        o.ChannelOptionsActions.Add(options => options.Credentials = ChannelCredentials.Insecure); // TODO: Probably not needed
                    });
                })
                .UseOrleans(builder =>
                {
                    builder.ConfigureApplicationParts(manager =>
                    {
                        manager.AddApplicationPart(typeof(WeatherGrain).Assembly).WithReferences();
                    });
                    builder.UseLocalhostClustering();
                    builder.AddMemoryGrainStorageAsDefault();
                    builder.AddSimpleMessageStreamProvider("SMS");
                    builder.AddMemoryGrainStorage("PubSubStore");
                    builder.UseDashboard(options =>
                    {
                        options.HideTrace = true;
                    });
                });
    }
}