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

// using FastHashes;

namespace Orleans.SiloGrpc.Services
{
    public class CacheDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<FakeDataSource> _logger;
        private readonly IClusterClient _orleansClient;

        public CacheDataSource(ILogger<FakeDataSource> logger, IClusterClient orleansClient)
        {
            _logger = logger;
            _orleansClient = orleansClient;
        }

        public override async Task Get(DataSourceGetRequest request, IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            // static PointInTime ToPointInTime(DateTimeOffset dto) => new PointInTime { Time = Timestamp.FromDateTimeOffset(dto) };

            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            var (grainKey, monikerVersionPartId) = request.Id.MonikerCase switch // TODO: Change GrainKey calculation logic to an unbreakable one
            {
                MonikerId.MonikerOneofCase.None => throw new ArgumentException("MonikerId is missing"),
                MonikerId.MonikerOneofCase.Latest => ($"{request.Id.Latest.Key}||{0}", new MonikerVersionPartId
                    {
                        Id = request.Id.Version.Id,
                        Version = request.Id.Version.Version
                    }),
                MonikerId.MonikerOneofCase.Version => ($"{request.Id.Version.Id.Key}||{request.Id.Version.Version}", new MonikerVersionPartId
                    {
                       Id = request.Id.Version.Id,
                       Version = request.Id.Version.Version
                    }),
                _ => throw new NotImplementedException("Impossible case")
            };

            try
            {
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