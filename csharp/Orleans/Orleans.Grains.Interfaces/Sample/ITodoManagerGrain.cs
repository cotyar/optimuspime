using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Orleans;

namespace Orleans.Grains.Sample
{
    public interface ITodoManagerGrain : IGrainWithGuidKey
    {
        Task RegisterAsync(Guid itemKey);
        Task UnregisterAsync(Guid itemKey);

        Task<ImmutableArray<Guid>> GetAllAsync();
    }
}