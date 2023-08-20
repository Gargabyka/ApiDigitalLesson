using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контроллер работы с типом урока преподавателя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherTypeLessonController : ControllerBase
    {
        private readonly ITeacherTypeLessonService _lessonService;
        private readonly ILogger<TeacherTypeLessonController> _logger;

        public TeacherTypeLessonController(ITeacherTypeLessonService lessonService, ILogger<TeacherTypeLessonController> logger)
        {
            _lessonService = lessonService;
            _logger = logger;
        }

        [HttpGet("GetTeacherTypeLesson")]
        public async Task<IActionResult> GetTeacherTypeLessonAsync(string id)
        {
            try
            {
                var result = await _lessonService.GetTeacherTypeLessonAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherTypeLessonController)}. Произошла ошибка при работе метода GetTeacherTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetTeacherTypeLessonList")]
        public async Task<IActionResult> GetTeacherTypeLessonListAsync(string teacherId)
        {
            try
            {
                var result = await _lessonService.GetTeacherTypeLessonListAsync(teacherId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherTypeLessonController)}. Произошла ошибка при работе метода GetTeacherTypeLessonListAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateTeacherTypeLesson")]
        public async Task<IActionResult> CreateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto)
        {
            try
            {
                var result = await _lessonService.CreateTeacherTypeLessonAsync(typeLessonDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherTypeLessonController)}. Произошла ошибка при работе метода CreateTeacherTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateTeacherTypeLesson")]
        public async Task<IActionResult> UpdateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto)
        {
            try
            {
                var result = await _lessonService.UpdateTeacherTypeLessonAsync(typeLessonDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherTypeLessonController)}. Произошла ошибка при работе метода UpdateTeacherTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("DeleteTeacherTypeLesson")]
        public async Task<IActionResult> DeleteTeacherTypeLessonAsync(string id)
        {
            try
            {
                var result = await _lessonService.DeleteTeacherTypeLessonAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TeacherTypeLessonController)}. Произошла ошибка при работе метода DeleteTeacherTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}