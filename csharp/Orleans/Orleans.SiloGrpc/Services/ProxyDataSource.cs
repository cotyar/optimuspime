using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using CalculationService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
// using FastHashes;

namespace Orleans.SiloGrpc.Services
{
    public class ProxyDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<ProxyDataSource> _logger;
        private readonly GrpcChannel _channel;

        public ProxyDataSource(ILogger<ProxyDataSource> logger)
        {
            _logger = logger;
            _channel = GrpcChannel.ForAddress("http://127.0.0.1:8085");
        }

        public override async Task Get(DataSourceGetRequest request, IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");
            
            var client = new CalculationService.DataSource.DataSourceClient(_channel);
            await foreach (var dsgr in client.Get(request).ResponseStream.ReadAllAsync())
                await Task.Run(() => responseStream.WriteAsync(dsgr));

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
        }
    }
}