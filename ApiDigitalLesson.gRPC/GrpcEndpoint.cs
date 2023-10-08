using ApiDigitalLesson.gRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ApiDigitalLesson.gRPC
{
    public static class GrpcEndpoint
    {
        public static void AddGrpcEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<CleanJobService>();
            endpoints.MapGrpcHealthChecksService();
        }
    }
}