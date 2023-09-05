using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Dto.Scheduler;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контролер работы с преподавателем
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }
        
        [HttpGet("GetTeacherUser")]
        public async Task<IActionResult> GetTeacherUserAsync()
        {
            try
            {
                var result = await _teacherService.GetTeacherUserAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetTeacherUserAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetTeacherSettings")]
        public async Task<IActionResult> GetTeacherSettingsAsync()
        {
            try
            {
                var result = await _teacherService.GetTeacherSettingsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetTeacherSettingsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetTeacher")]
        public async Task<IActionResult> GetTeacherAsync(string id)
        {
            try
            {
                var result = await _teacherService.GetTeacherAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetTeachersLesson")]
        public async Task<IActionResult> GetTeachersLessonAsync()
        {
            try
            {
                var result = await _teacherService.GetTeachersLessonAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetTeachersLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetTeachersWithTypeLessonAsync")]
        public async Task<IActionResult> GetTeachersWithTypeLessonAsync()
        {
            try
            {
                var result = await _teacherService.GetTeachersWithTypeLessonAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetTeachersWithTypeLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacherAsync(TeacherDto teacherDto, string userId)
        {
            try
            {
                await _teacherService.CreateTeacherAsync(teacherDto, userId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода CreateTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacherAsync(UpdateTeacherDto teacherDto)
        {
            try
            {
                await _teacherService.UpdateTeacherAsync(teacherDto);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода UpdateTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateTeacherSettings")]
        public async Task<IActionResult> UpdateTeacherSettingsAsync(SettingsTeacherDto teacherDto, string teacherId)
        {
            try
            {
                await _teacherService.UpdateTeacherSettingsAsync(teacherDto, teacherId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода UpdateTeacherSettingsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
                
        [HttpPost("CreateWeekendForTeacher")]
        public async Task<IActionResult> CreateWeekendForTeacherAsync(SchedulerDto scheduler)
        {
            try
            {
                var result = await _teacherService.CreateWeekendForTeacherAsync(scheduler);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода CreateWeekendForTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetSchedulerTeacher")]
        public async Task<IActionResult> GetSchedulerTeacherAsync(string id)
        {
            try
            {
                var result = await _teacherService.GetSchedulerTeacherAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetSchedulerTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetStudentsForTeacher")]
        public async Task<IActionResult> GetStudentsForTeacherAsync(string id)
        {
            try
            {
                var result = await _teacherService.GetStudentsForTeacherAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. " +
                    $"Произошла ошибка при работе метода GetStudentsForTeacherAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}