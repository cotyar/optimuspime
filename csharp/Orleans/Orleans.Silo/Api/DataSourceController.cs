using System;
using System.Linq;
using System.Buffers;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CalculationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orleans.Grains.Cache;
using Orleans.Grains.Sample;
using Orleans.Grains.Sample.Models;
using Orleans.Silo.Utils;

namespace Orleans.Silo.Api
{
    [ApiController]
    [Route("api/datasource")]
    public class DataSourceController : ControllerBase
    {
        private readonly ILogger<DataSourceController> _logger;
        private readonly IClusterClient _orleansClient;

        public DataSourceController(ILogger<DataSourceController> logger, IClusterClient orleansClient)
        {
            _logger = logger;
            _orleansClient = orleansClient;
        }

        [HttpGet("{key}/{version}")]
        public async Task<DataSourceGetResponse> GetAsync([Required] string key, int version)
        {
            var requestUid = Guid.NewGuid().ToString(); // TODO: Bind the UID to the request 
            _logger.LogInformation($"Started processing Get request: '{requestUid}' from '{Request.HttpContext.Connection.RemoteIpAddress}:{Request.HttpContext.Connection.RemotePort}'");

            var monikerVersionId = new MonikerVersionId
            {
                Id = new MonikerIdentifier{ Key = key},
                Version = (ulong) version,
                Timestamp = DateTimeOffset.Now.ToPointInTime()
            };

            try
            {
                var (grainKey, monikerVersionPartId) = monikerVersionId.ToGrainKey();

                var result = await Task.Run(() => _orleansClient.GetGrain<ICacheItemGrain>(grainKey).GetAsync(monikerVersionPartId));

                var storedValue = result.FirstOrDefault();
                return result != null 
                    ? new DataSourceGetResponse {Success = storedValue} 
                    : new DataSourceGetResponse {NotFound = new MonikerId { Version = monikerVersionId }};
            }
            catch (Exception e)
            {
                _logger.LogError($"{e} while processing: '{requestUid}' from '{Request.HttpContext.Connection.RemoteIpAddress}:{Request.HttpContext.Connection.RemotePort}'");
                return new DataSourceGetResponse {Error = new CacheError { Error = new InternalError { StorageError = e.Message } } };
                // throw;
            }
            finally
            {
                _logger.LogInformation($"Finished processing Get request: '{requestUid}' from '{Request.HttpContext.Connection.RemoteIpAddress}:{Request.HttpContext.Connection.RemotePort}'");
            }
        }
    }
}