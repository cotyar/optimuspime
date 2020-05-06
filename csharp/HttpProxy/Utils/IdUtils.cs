using System;
using CalculationService;
using Google.Protobuf.WellKnownTypes;

namespace HttpProxyService.Utils
{
    public static class IdUtils
    {
        public static (MonikerIdentifier, ulong, PointInTime) Deconstruct(this DataSourceGetRequest request)
        {
            return request.Id.MonikerCase switch
            {
                MonikerId.MonikerOneofCase.Latest => (request.Id.Latest, 0UL, ToPointInTime(DateTimeOffset.Now)),
                MonikerId.MonikerOneofCase.Version => (request.Id.Version.Id, request.Id.Version.Version, ToPointInTime(DateTimeOffset.Now.Date) /*request.Id.Version.Timestamp*/),
                _ => throw new NotImplementedException()
            };
        }

        public static PointInTime ToPointInTime(this DateTimeOffset dto) => new PointInTime {Time = Timestamp.FromDateTimeOffset(dto)};
    }
}