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
    public class FakeDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<FakeDataSource> _logger;
        private readonly int _rowsInTheResponse;
        private readonly Fixture _fixture;
        // private readonly SipHash _hash;

        public FakeDataSource(ILogger<FakeDataSource> logger)
        {
            _logger = logger;
            _rowsInTheResponse = 10;
            _fixture = new Fixture();
            // _hash = new SipHash();
        }

        private static StoredValueChecksum HashString(string str) => //new StoredValueChecksum { Hash = BitConverter.ToUInt64(_hash.ComputeHash(Encoding.UTF8.GetBytes(str))) };
            new StoredValueChecksum { Hash = 12345 };

        public override async Task Get(DataSourceGetRequest request, IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");
            
            foreach (var i in Enumerable.Range(0, _rowsInTheResponse))
            {
                var value = _fixture.Create<string>();
                var (id, version, timestamp) = request.Deconstruct();
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
                            PartsCount = (uint) _rowsInTheResponse,
                            Checksum = HashString(value)
                        },
                        StringValue = value
                    }
                };

                await responseStream.WriteAsync(response);
            }

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
        }
    }
}