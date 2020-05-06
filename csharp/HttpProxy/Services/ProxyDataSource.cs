using System;
using System.Threading.Tasks;
using CalculationService;
using Grpc.Core;
using Microsoft.Extensions.Logging;

// using FastHashes;

namespace HttpProxyService.Services
{
    public class ProxyDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<ProxyDataSource> _logger;
        private readonly DataSource.DataSourceClient _grpcClient;

        public ProxyDataSource(ILogger<ProxyDataSource> logger, DataSource.DataSourceClient grpcClient)
        {
            _logger = logger;
            _grpcClient = grpcClient;
        }

        public override async Task<DataSourceGetResponse> GetVersion(DataSourceGetVersionRequest request, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            var result = await _grpcClient.GetVersionAsync(request);
            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
            return result;
        }

        public override async Task Get(DataSourceGetRequest request, IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");
            
            await Task.Run(async () =>
            {
                await foreach (var dsgr in _grpcClient.Get(request).ResponseStream.ReadAllAsync())
                    await responseStream.WriteAsync(dsgr);
            });

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
        }
    }
}