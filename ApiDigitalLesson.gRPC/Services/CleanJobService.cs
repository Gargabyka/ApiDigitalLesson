using ApiDigitalLesson.BL.Services.Interface;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.gRPC.Services 
{
    public class CleanJobService : CleanJob.CleanJobBase
    {
        private readonly ILogger<CleanJobService> _logger;
        private readonly ICleanerServices _cleanerServices;

        public CleanJobService(
            ILogger<CleanJobService> logger, 
            ICleanerServices cleanerServices)
        {
            _logger = logger;
            _cleanerServices = cleanerServices;
        }

        /// <summary>
        /// Джоба по удалению старых данных из бд
        /// </summary>
        public override async Task<Empty> CleanJobAsync(CleanupRequest request, ServerCallContext context)
        {
            try
            {
                await _cleanerServices.CleanAsync(request.Mount);
                return new Empty();
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при попытке отчистки старых данных: {e.Message}.";
                _logger.LogError(message, e);
                throw new Exception(message);
            }
        }
    }
}