using ApiDigitalLesson.BL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контроллер для работы с городами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesServices _citiesService;
        private readonly ILogger<CitiesController> _logger;
        
        public CitiesController(ICitiesServices citiesService, ILogger<CitiesController> logger)
        {
            _citiesService = citiesService;
            _logger = logger;
        }
        
        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCitiesAsync()
        {
            try
            {
                var result = await _citiesService.GetCitiesAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(CitiesController)}. " +
                    $"Произошла ошибка при работе метода GetCitiesAsync, {e.Message}";

                _logger.LogError(e, message);
                return StatusCode(500, message);
            }
        }
    }
}