using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans.Grains.Sample.Models;
using Google.Protobuf.WellKnownTypes;
using CalculationService;

namespace Orleans.Grains.Cache
{
    public interface ICacheItemGrain : IGrainWithStringKey
    {
        Task<ImmutableArray<StoredValue>?> GetAsync(MonikerVersionPartId item);

        Task InvalidateAsync();
        
        // Task ClearAsync();
        //
        // Task PutAsync(StoredValue item);
    }
}