using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Orleans.Configuration;
using Orleans.Grains.Sample;
using Orleans.Hosting;
using Orleans.Silo.Api;
using Serilog;
using Serilog.Events;

namespace Orleans.Silo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureServices(services =>
                        {
                            services.AddControllers()
                                .AddApplicationPart(typeof(WeatherController).Assembly);

                            services.AddSwaggerGen(options =>
                            {
                                options.SwaggerDoc("v1", new OpenApiInfo { Title = nameof(Orleans), Version = "v1" });
                            });

                            services.AddCors(options =>
                            {
                                options.AddPolicy("ApiService",
                                    builder =>
                                    {
                                        builder
                                            .WithOrigins(
                                                "http://localhost:62653",
                                                "http://localhost:62654")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                    });
                            });
                        })
                        .Configure(app =>
                       {
                           app.UseCors("ApiService");
                           app.UseSwagger();
                           app.UseSwaggerUI(options =>
                           {
                               options.SwaggerEndpoint("/swagger/v1/swagger.json", nameof(Orleans));
                           });

                           app.UseRouting();
                           app.UseEndpoints(endpoints =>
                           {
                               endpoints.MapDefaultControllerRoute();
                           });
                       })
                        .UseUrls("http://localhost:8084");
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
                })
                .UseOrleans(builder =>
                {
                    builder.ConfigureApplicationParts(manager =>
                    {
                        manager.AddApplicationPart(typeof(WeatherGrain).Assembly).WithReferences();
                    });
                    // builder.UseLocalhostClustering();
                    var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                        .LastOrDefault();//(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                    // builder.UseDevelopmentClustering(IPEndPoint.Parse(":11111"));
                    builder.UseDevelopmentClustering(new IPEndPoint(ipAddress ?? IPAddress.Any, 11111));
                    // builder.UseDevelopmentClustering(new IPEndPoint(IPAddress.Any, 11111));
                    builder.Configure<ClusterOptions>(options =>
                    {
                        options.ClusterId = "Megathon Cluster";
                        options.ServiceId = "ASF Caching";
                    });
                    builder.ConfigureEndpoints(siloPort: 11112, gatewayPort: 30002);
                    builder.AddMemoryGrainStorageAsDefault();
                    builder.AddSimpleMessageStreamProvider("SMS");
                    builder.AddMemoryGrainStorage("PubSubStore");
                    builder.UseDashboard(options =>
                    {
                        options.HideTrace = true;
                        options.Host = "0.0.0.0";
                        options.Port = 8083;
                    });
                });
    }
}