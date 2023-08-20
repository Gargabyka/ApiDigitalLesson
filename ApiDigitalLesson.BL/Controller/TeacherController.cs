using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
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
        public async Task<IActionResult> GetTeacherUserAsync(string? id)
        {
            try
            {
                var result = await _teacherService.GetTeacherUserAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода GetTeacherUserAsync";
                
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
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода GetTeacherAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateTeacher")]
        public async Task<IActionResult> CreateTeacherAsync(TeacherDto teacherDto, string userId)
        {
            try
            {
                var result = await _teacherService.CreateTeacherAsync(teacherDto, userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода CreateTeacherAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacherAsync(TeacherDto teacherDto)
        {
            try
            {
                var result = await _teacherService.UpdateTeacherAsync(teacherDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода UpdateTeacherAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateTeacherSettings")]
        public async Task<IActionResult> UpdateTeacherSettingsAsync(SettingsTeacherDto teacherDto, string teacherId)
        {
            try
            {
                var result = await _teacherService.UpdateTeacherSettingsAsync(teacherDto, teacherId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода UpdateTeacherSettingsAsync";
                
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
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода CreateWeekendForTeacherAsync";
                
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
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода GetSchedulerTeacherAsync";
                
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
                    $"Контроллер: {nameof(TeacherController)}. Произошла ошибка при работе метода GetStudentsForTeacherAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}