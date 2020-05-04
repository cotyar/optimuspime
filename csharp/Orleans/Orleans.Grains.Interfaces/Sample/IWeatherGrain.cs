using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans;
using Orleans.Grains.Sample.Models;

namespace Orleans.Grains.Sample
{
    public interface IWeatherGrain : IGrainWithGuidKey
    {
        Task<ImmutableArray<WeatherInfo>> GetForecastAsync();
    }
}