using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using CalculationService.Utils;
// using FastHashes;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace CalculationService.Services
{
    public class FileDataSource : DataSource.DataSourceBase
    {
        private readonly ILogger<FileDataSource> _logger;

        public FileDataSource(ILogger<FileDataSource> logger)
        {
            _logger = logger;
        }

        private static StoredValueChecksum
            HashString(string str) => //new StoredValueChecksum { Hash = BitConverter.ToUInt64(_hash.ComputeHash(Encoding.UTF8.GetBytes(str))) };
            new StoredValueChecksum {Hash = 12345};

        public override async Task<DataSourceGetResponse> GetVersion(DataSourceGetVersionRequest request, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            try
            {
                var value = (await ReadFileAsync($"{request.Id.Id}/{request.Id.Version}", false)).First();
                return GenerateGetResponse(value, request.Id.Id, request.Id.Version,
                    DateTimeOffset.Now.ToPointInTime(), 0, 1);
            }
            catch (Exception e)
            {
                return new DataSourceGetResponse { NotFound = new MonikerId { Version = request.Id } };
            }
            finally
            {
                _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
            }
        }

        public override async Task Get(DataSourceGetRequest request,
            IServerStreamWriter<DataSourceGetResponse> responseStream, ServerCallContext context)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{context.Peer}'");

            var (id, version, timestamp) = request.Deconstruct();

            var (_, mbpid) = request.Id.ToGrainKey();
            var rows = await ReadFileAsync($"{mbpid.Id.Key}/{mbpid.Version}", false);
            var i = 0;
            foreach (var row in rows)
            {
                var response = GenerateGetResponse(row, id, version, timestamp, i++, rows.Length);
                await responseStream.WriteAsync(response);
            }

            _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{context.Peer}'");
        }

        private async Task<string[]> ReadFileAsync(string fileName, bool splitByRows)
        {
            if (splitByRows)
                return await File.ReadAllLinesAsync(fileName);
            
            return new [] { await File.ReadAllTextAsync(fileName) };
        }
        
        private DataSourceGetResponse GenerateGetResponse(string content, MonikerIdentifier id, ulong version, PointInTime timestamp, int i, int total)
        {
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
                        Checksum = HashString(content)
                    },
                    StringValue = content
                }
            };
            return response;
        }
    }
}