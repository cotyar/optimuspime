using System;
using CalculationService;
using Google.Protobuf.WellKnownTypes;

namespace Orleans.SiloGrpc.Utils
{
    public static class IdUtils
    {
        public static (string, MonikerVersionPartId) ToGrainKey(this MonikerId monikerId)
        {
            var (grainKey, monikerVersionPartId) =
                monikerId.MonikerCase switch // TODO: Change GrainKey calculation logic to an unbreakable one
                {
                    MonikerId.MonikerOneofCase.None => throw new ArgumentException("MonikerId is missing"),
                    MonikerId.MonikerOneofCase.Latest => ($"{monikerId.Latest.Key}||{0}", new MonikerVersionPartId
                    {
                        Id = monikerId.Version.Id,
                        Version = monikerId.Version.Version
                    }),
                    MonikerId.MonikerOneofCase.Version => ($"{monikerId.Version.Id.Key}||{monikerId.Version.Version}",
                        new MonikerVersionPartId
                        {
                            Id = monikerId.Version.Id,
                            Version = monikerId.Version.Version
                        }),
                    _ => throw new NotImplementedException("Impossible case")
                };
            return (grainKey, monikerVersionPartId);
        }

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