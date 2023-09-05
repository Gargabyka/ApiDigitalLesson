using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Const;
using ApiDigitalLesson.Model.Dto.Violators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контролер работы с жалобами
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ViolatorsController : ControllerBase
    {
        private readonly IViolatorsService _violatorsService;
        private readonly ILogger<ViolatorsController> _logger;

        public ViolatorsController(IViolatorsService violatorsService, ILogger<ViolatorsController> logger)
        {
            _violatorsService = violatorsService;
            _logger = logger;
        }
        
        [Authorize(Roles = Roles.Admin +","+ Roles.Moderator)]
        [HttpGet("GetViolatorsList")]
        public async Task<IActionResult> GetViolatorsListAsync()
        {
            try
            {
                var result = await _violatorsService.GetViolatorsListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода GetViolatorsListAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateViolator")]
        public async Task<IActionResult> CreateViolatorAsync(ViolatorsDto violatorsDto)
        {
            try
            {
                await _violatorsService.CreateViolatorAsync(violatorsDto);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода CreateViolatorAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [Authorize(Roles = Roles.Admin +","+ Roles.Moderator)]
        [HttpPost("BannedViolators")]
        public async Task<IActionResult> BannedViolatorsAsync(string id, DateTime dateBan)
        {
            try
            {
                await _violatorsService.BannedViolatorsAsync(id, dateBan);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода BannedViolatorsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [Authorize(Roles = Roles.Admin +","+ Roles.Moderator)]
        [HttpPost("CancelViolators")]
        public async Task<IActionResult> CancelViolatorsAsync(string id)
        {
            try
            {
                await _violatorsService.CancelViolatorsAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода CancelViolatorsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("IsBanned")]
        public async Task<IActionResult> IsBannedAsync(string? teacherId, string? studentId)
        {
            try
            {
                await _violatorsService.IsBannedAsync(teacherId, studentId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода IsBannedAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [Authorize(Roles = Roles.Admin +","+ Roles.Moderator)]
        [HttpPost("UnbanViolators")]
        public async Task<IActionResult> UnbanViolatorsAsync(string id)
        {
            try
            {
                await _violatorsService.UnbanViolatorsAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ViolatorsController)}. " +
                    $"Произошла ошибка при работе метода UnbanViolatorsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}