using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CalculationService;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Orleans.Grains.Sample;
using Orleans.Grains.Sample.Models;
using Orleans.Runtime;
using static CalculationService.DataSourceGetResponse.RespOneofCase;

namespace Orleans.Grains.Cache
{
    public class CacheItemGrain : Grain, ICacheItemGrain
    {
        private readonly ILogger<TodoGrain> _logger;
        private readonly DataSource.DataSourceClient _dataSourceClient;

        private string GrainType => GetType().Name;
        private string GrainKey => this.GetPrimaryKeyString();

        private ImmutableArray<StoredValue> _storedValue;
        private bool _loaded;
        private bool _notExists;

        public CacheItemGrain(ILogger<TodoGrain> logger, DataSource.DataSourceClient dataSourceClient)
        {
            _logger = logger;
            _dataSourceClient = dataSourceClient;
        }

        public async Task<ImmutableArray<StoredValue>> GetAsync(MonikerVersionPartId monikerVersionPartId)
        {
            if (_notExists) return ImmutableArray<StoredValue>.Empty;

            if (_loaded) return _storedValue;
            
            var items = await _dataSourceClient.Get(
                new DataSourceGetRequest
                {
                    Id = new MonikerId
                    {
                        Version = new MonikerVersionId
                        {
                            Id = monikerVersionPartId.Id,
                            Version = monikerVersionPartId.Version,
                            Timestamp = monikerVersionPartId.Timestamp
                        }
                    }
                }).ResponseStream.ReadAllAsync().ToArrayAsync();
            var anyError = items.FirstOrDefault(item => item.RespCase == Error);
            if (anyError != null)
                throw new Exception($"Unexpected Error: '{anyError.Error}'");
                
            var anyNotFound = items.FirstOrDefault(item => item.RespCase == NotFound);
            if (anyNotFound != null)
            {
                _storedValue = ImmutableArray<StoredValue>.Empty;
                _loaded = true;
                _notExists = true;
            }
            else
            {
                _storedValue = ImmutableArray.Create(items.Select(item => item.Success).ToArray());
                _loaded = true;
            }

            return _storedValue;
        }

        public Task InvalidateAsync()
        {
            _logger.Info($"Item '{GrainKey}' has been invalidated");
            DeactivateOnIdle();
            return Task.CompletedTask;
        }
    }
}