using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контролер работы с индивидуальными уроками
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SingleLessonController : ControllerBase
    {
        private readonly ISingleLessonService _singleLessonService;
        private readonly ILogger<SingleLessonController> _logger;

        public SingleLessonController(ISingleLessonService singleLessonService, ILogger<SingleLessonController> logger)
        {
            _singleLessonService = singleLessonService;
            _logger = logger;
        }
        
        
        [HttpGet("GetSingleLessonForId")]
        public async Task<IActionResult> GetSingleLessonForIdAsync(string id)
        {
            try
            {
                var result = await _singleLessonService.GetSingleLessonForIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода GetSingleLessonForIdAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetSingleLessonForTeacherId")]
        public async Task<IActionResult> GetSingleLessonForTeacherIdAsync(string teacherId)
        {
            try
            {
                var result = await _singleLessonService.GetSingleLessonForTeacherIdAsync(teacherId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода GetSingleLessonForTeacherIdAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetUnConfirmSingleLesson")]
        public async Task<IActionResult> GetUnConfirmSingleLessonAsync()
        {
            try
            {
                var result = await _singleLessonService.GetUnConfirmSingleLessonAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода GetUnConfirmSingleLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateSingleLesson")]
        public async Task<IActionResult> CreateSingleLessonAsync(CreateSingleLessonDto data)
        {
            try
            {
                var result = await _singleLessonService.CreateSingleLessonAsync(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода CreateSingleLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("ConfirmSingleLesson")]
        public async Task<IActionResult> ConfirmSingleLessonAsync(string lessonId)
        {
            try
            {
                var result = await _singleLessonService.ConfirmSingleLessonAsync(lessonId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода ConfirmSingleLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CancelSingleLesson")]
        public async Task<IActionResult> CancelSingleLessonAsync(string lessonId, string description)
        {
            try
            {
                var result = await _singleLessonService.CancelSingleLessonAsync(lessonId, description);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. Произошла ошибка при работе метода CancelSingleLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}