using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans.Grains.Sample;
using Orleans.Grains.Sample.Models;

namespace Orleans.Blazor.ServerSide.Services
{
    public class WeatherForecastService
    {
        private readonly IClusterClient client;

        public WeatherForecastService(IClusterClient client)
        {
            this.client = client;
        }

        public Task<ImmutableArray<WeatherInfo>> GetForecastAsync() =>

            client.GetGrain<IWeatherGrain>(Guid.Empty)
                .GetForecastAsync();
    }
}