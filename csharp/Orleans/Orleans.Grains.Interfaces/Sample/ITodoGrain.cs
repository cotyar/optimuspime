using System.Threading.Tasks;
using Orleans;
using Orleans.Grains.Sample.Models;

namespace Orleans.Grains.Sample
{
    public interface ITodoGrain : IGrainWithGuidKey
    {
        Task SetAsync(TodoItem item);

        Task ClearAsync();

        Task<TodoItem> GetAsync();
    }
}