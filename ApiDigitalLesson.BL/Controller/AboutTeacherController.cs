using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Const;
using ApiDigitalLesson.Model.Dto.AboutTeacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контроллер для работы с отзывами о пользователе
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AboutTeacherController : ControllerBase
    {
        private readonly IAboutTeacherService _aboutTeacherService;
        private readonly ILogger<AboutTeacherController> _logger;

        public AboutTeacherController(IAboutTeacherService aboutTeacherService, ILogger<AboutTeacherController> logger)
        {
            _aboutTeacherService = aboutTeacherService;
            _logger = logger;
        }


        [HttpGet("GetAboutTeachersList")]
        public async Task<IActionResult> GetAboutTeachersListAsync(string id)
        {
            try
            {
                var result = await _aboutTeacherService.GetAboutTeachersListAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(AboutTeacherController)}. " +
                    $"Произошла ошибка при работе метода GetAboutTeachersListAsync, {e.Message}";

                _logger.LogError(e, message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("GetAvengerRatingForTeacher")]
        public async Task<IActionResult> GetAvengerRatingForTeacherAsync(string id)
        {
            try
            {
                var result = await _aboutTeacherService.GetAvengerRatingForTeacherAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(AboutTeacherController)}. " +
                    $"Произошла ошибка при работе метода GetAvengerRatingForTeacher, {e.Message}";

                _logger.LogError(e, message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("CreateAboutTeacher")]
        public async Task<IActionResult> CreateAboutTeacherAsync(CreateAboutTeacherDto aboutTeacherDto)
        {
            try
            {
                await _aboutTeacherService.CreateAboutTeacherAsync(aboutTeacherDto);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(AboutTeacherController)}. " +
                    $"Произошла ошибка при работе метода CreateAboutTeacherAsync, {e.Message}";

                _logger.LogError(e, message);
                return StatusCode(500, message);
            }
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.Moderator)]
        [HttpPost("DeleteAboutTeacher")]
        public async Task<IActionResult> DeleteAboutTeacherAsync(string id)
        {
            try
            {
                await _aboutTeacherService.DeleteAboutTeacherAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(AboutTeacherController)}. " +
                    $"Произошла ошибка при работе метода DeleteAboutTeacherAsync, {e.Message}";

                _logger.LogError(e, message);
                return StatusCode(500, message);
            }
        }
    }
}