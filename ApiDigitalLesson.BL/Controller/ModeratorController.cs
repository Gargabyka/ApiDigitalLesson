using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Const;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контроллер для работы с модераторами
    /// </summary>
    [Authorize(Roles = Roles.Admin +","+ Roles.Moderator)]
    [ApiController]
    [Route("api/[controller]")]
    public class ModeratorController : ControllerBase
    {
        private readonly IModeratorService _moderatorService;
        private readonly ILogger<ModeratorController> _logger;

        public ModeratorController(IModeratorService moderatorService, ILogger<ModeratorController> logger)
        {
            _moderatorService = moderatorService;
            _logger = logger;
        }

        [HttpGet("GetModeratorUser")]
        public async Task<IActionResult> GetModeratorUserAsync()
        {
            try
            {
                var result = await _moderatorService.GetModeratorUserAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ModeratorController)}. Произошла ошибка при работе метода GetModeratorUserAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetModeratorList")]
        public async Task<IActionResult> GetModeratorListAsync()
        {
            try
            {
                var result = await _moderatorService.GetModeratorListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ModeratorController)}. Произошла ошибка при работе метода GetModeratorListAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetModerator")]
        public async Task<IActionResult> GetModeratorAsync(string id)
        {
            try
            {
                var result = await _moderatorService.GetModeratorAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ModeratorController)}. Произошла ошибка при работе метода GetModeratorAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateModerator")]
        public async Task<IActionResult> CreateModeratorAsync(ModeratorDto moderatorDto, string userId)
        {
            try
            {
                await _moderatorService.CreateModeratorAsync(moderatorDto, userId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ModeratorController)}. Произошла ошибка при работе метода CreateModeratorAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("DeleteModerator")]
        public async Task<IActionResult> DeleteModeratorAsync(string id)
        {
            try
            {
                await _moderatorService.DeleteModeratorAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(ModeratorController)}. Произошла ошибка при работе метода DeleteModeratorAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}