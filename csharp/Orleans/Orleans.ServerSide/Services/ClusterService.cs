using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Grains.Sample;

namespace Orleans.Blazor.ServerSide.Services
{
    public class ClusterService : IHostedService
    {
        private readonly ILogger<ClusterService> _logger;

        public ClusterService(ILogger<ClusterService> logger)
        {
            _logger = logger;

            var gateways = new[]
            {
                IPEndPoint.Parse("127.0.0.1:11111"),
                IPEndPoint.Parse("127.0.0.1:11112")
            };
            Client = new ClientBuilder()
                .ConfigureApplicationParts(manager => manager.AddApplicationPart(typeof(IWeatherGrain).Assembly).WithReferences())
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "Megathon Cluster";
                    options.ServiceId = "ASF Caching";
                })
                .AddSimpleMessageStreamProvider("SMS")
                .Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Client.Connect(async error =>
            {
                _logger.LogError(error, error.Message);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                return true;
            });
        }

        public Task StopAsync(CancellationToken cancellationToken) => Client.Close();

        public IClusterClient Client { get; }
    }

    public static class ClusterServiceBuilderExtensions
    {
        public static IServiceCollection AddClusterService(this IServiceCollection services)
        {
            services.AddSingleton<ClusterService>();
            services.AddSingleton<IHostedService>(_ => _.GetService<ClusterService>());
            services.AddTransient(_ => _.GetService<ClusterService>().Client);
            return services;
        }
    }
}