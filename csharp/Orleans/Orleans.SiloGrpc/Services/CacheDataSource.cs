using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using CalculationService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Orleans.Grains.Cache;
using Orleans.Runtime;
using Orleans.SiloGrpc.Utils;

// using FastHashes;

namespace Orleans.SiloGrpc.Services
{
    public class CacheDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<CacheDataSource> _logger;
        private readonly IClusterClient _orleansClient;

        public CacheDataSource(ILogger<CacheDataSource> logger, IClusterClient orleansClient)
        {
            _logger = logger;
            _orleansClient = orleansClient;
        }

        public override async Task<DataSourceGetResponse> GetVersion(DataSourceGetVersionRequest request, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");
            
            try
            {
                var (grainKey, monikerVersionPartId) = request.Id.ToGrainKey();

                var result = await Task.Run(() => _orleansClient.GetGrain<ICacheItemGrain>(grainKey).GetAsync(monikerVersionPartId));

                var storedValue = result.FirstOrDefault();
                return result != null 
                    ? new DataSourceGetResponse {Success = storedValue} 
                    : new DataSourceGetResponse {NotFound = new MonikerId { Version = request.Id }};
            }
            catch (Exception e)
            {
                _logger.LogError($"{e} while processing: '{requestUid}' from '{context.Peer}'");
                return new DataSourceGetResponse {Error = new CacheError { Error = new InternalError { StorageError = e.Message } } };
                // throw;
            }
            finally
            {
                _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
            }
        }
        
        public override async Task Get(DataSourceGetRequest request, IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");
            
            try
            {
                var (grainKey, monikerVersionPartId) = request.Id.ToGrainKey();

                var result = await Task.Run(() => _orleansClient.GetGrain<ICacheItemGrain>(grainKey).GetAsync(monikerVersionPartId));

                if (result.Any())
                {
                    foreach (var storedValue in result)
                    {
                        await responseStream.WriteAsync(new DataSourceGetResponse {Success = storedValue});
                    }
                }
                else
                {
                    await responseStream.WriteAsync(new DataSourceGetResponse {NotFound = request.Id});
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"{e} while processing: '{requestUid}' from '{context.Peer}'");
                await responseStream.WriteAsync(new DataSourceGetResponse {Error = new CacheError { Error = new InternalError { StorageError = e.Message } } });
                // throw;
            }
            finally
            {
                _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
            }
        }
    }
}