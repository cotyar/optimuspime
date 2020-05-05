using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using CalculationService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Orleans.Grains.Cache;

// using FastHashes;

namespace Orleans.SiloGrpc.Services
{
    public class CacheControl : CalculationService.CacheControl.CacheControlBase
    {
        private readonly ILogger<FakeDataSource> _logger;
        private readonly IClusterClient _orleansClient;
        private GrpcChannel _channel;

        public CacheControl(ILogger<FakeDataSource> logger, IClusterClient orleansClient)
        {
            _logger = logger;
            _orleansClient = orleansClient;
            _channel = GrpcChannel.ForAddress("http://localhost:8085");
        }

        public override async Task<CacheInvalidateResponse> Invalidate(CacheInvalidateRequest request, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Invalidate request: '{requestUid}' from '{context.Peer}'");
            
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
                await Task.Run(() => _orleansClient.GetGrain<ICacheItemGrain>(grainKey).InvalidateAsync());

                return new CacheInvalidateResponse { Success = new Empty() };
            }
            catch (Exception e)
            {
                _logger.LogError($"{e} while processing: '{requestUid}' from '{context.Peer}'");
                return new CacheInvalidateResponse { Error = new CacheError { Error = new InternalError { StorageError = e.Message } } };
                // throw;
            }
            finally
            {
                _logger.LogInformation($"Finished processing Invalidate request: '{requestUid}' from '{context.Peer}'");
            }
        }
    }
}