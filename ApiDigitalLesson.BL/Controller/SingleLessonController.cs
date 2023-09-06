using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Dto.SingleLesson;
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
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода GetSingleLessonForIdAsync, {e.Message}";
                
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
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода GetSingleLessonForTeacherIdAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
                
        [HttpGet("GetSingleLessonForStudentId")]
        public async Task<IActionResult> GetSingleLessonForStudentIdAsync(string studentId)
        {
            try
            {
                var result = await _singleLessonService.GetSingleLessonForStudentIdAsync(studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода GetSingleLessonForStudentIdAsync, {e.Message}";
                
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
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода GetUnConfirmSingleLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CreateSingleLesson")]
        public async Task<IActionResult> CreateSingleLessonAsync(CreateSingleLessonDto data)
        {
            try
            {
                await _singleLessonService.CreateSingleLessonAsync(data);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода CreateSingleLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("ConfirmSingleLesson")]
        public async Task<IActionResult> ConfirmSingleLessonAsync(string lessonId)
        {
            try
            {
                await _singleLessonService.ConfirmSingleLessonAsync(lessonId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода ConfirmSingleLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("CancelSingleLesson")]
        public async Task<IActionResult> CancelSingleLessonAsync(string lessonId, string description)
        {
            try
            {
                await _singleLessonService.CancelSingleLessonAsync(lessonId, description);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(SingleLessonController)}. " +
                    $"Произошла ошибка при работе метода CancelSingleLessonAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}