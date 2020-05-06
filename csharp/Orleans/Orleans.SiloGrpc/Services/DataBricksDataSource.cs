using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using CalculationService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Orleans.SiloGrpc.Utils;

// using FastHashes;

namespace Orleans.SiloGrpc.Services
{
    public class DataBricksDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<DataBricksDataSource> _logger;
        private readonly int _rowsInTheResponse;
        private readonly Fixture _fixture;
        // private readonly SipHash _hash;

        public DataBricksDataSource(ILogger<DataBricksDataSource> logger)
        {
            _logger = logger;
            _rowsInTheResponse = 10;
            _fixture = new Fixture();
            // _hash = new SipHash();
        }

        private static StoredValueChecksum HashString(string str) => //new StoredValueChecksum { Hash = BitConverter.ToUInt64(_hash.ComputeHash(Encoding.UTF8.GetBytes(str))) };
            new StoredValueChecksum { Hash = 12345 };

        public override Task<DataSourceGetResponse> GetVersion(DataSourceGetVersionRequest request, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            var value = _fixture.Create<string>();
            var response = GenerateGetResponse(request.Id.Id, request.Id.Version, DateTimeOffset.Now.ToPointInTime(), 0, 1);

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
            return Task.FromResult(response);
        }

        public override async Task Get(DataSourceGetRequest request,
            IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            var (id, version, timestamp) = request.Deconstruct();
            
            foreach (var i in Enumerable.Range(0, _rowsInTheResponse))
            {
                var response = GenerateGetResponse(id, version, timestamp, i, _rowsInTheResponse);
                await responseStream.WriteAsync(response);
            }

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
        }

        private DataSourceGetResponse GenerateGetResponse(MonikerIdentifier id, ulong version, PointInTime timestamp, int i, int total)
        {
            var value = _fixture.Create<string>();
            var response = new DataSourceGetResponse
            {
                Success = new StoredValue
                {
                    Id = new MonikerVersionPartId
                    {
                        Id = id,
                        Version = version,
                        Timestamp = timestamp,
                        PartIndex = (uint) i,
                        PartsCount = (uint) total,
                        Checksum = HashString(value)
                    },
                    StringValue = value
                }
            };
            return response;
        }
    }
}