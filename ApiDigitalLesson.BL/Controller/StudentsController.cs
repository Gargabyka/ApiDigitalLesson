using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Student;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контролер работы со студентом
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController: ControllerBase
    {
        private readonly IStudentService _studentsService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentsService, ILogger<StudentsController> logger)
        {
            _studentsService = studentsService;
            _logger = logger;
        }
        
        [HttpGet("GetStudentUser")]
        public async Task<IActionResult> GetStudentUserAsync()
        {
            try
            {
                var result = await _studentsService.GetStudentUserAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода GetStudentUserAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("GetStudentSettings")]
        public async Task<IActionResult> GetStudentSettingsAsync()
        {
            try
            {
                var result = await _studentsService.GetStudentSettingsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода GetStudentSettingsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudentsAsync(string id)
        {
            try
            {
                var result = await _studentsService.GetStudentsAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода GetStudentsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("CreateStudents")]
        public async Task<IActionResult> CreateStudentsAsync(StudentsDto students, string id)
        {
            try
            {
                await _studentsService.CreateStudentsAsync(students, id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода CreateStudentsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("UpdateStudents")]
        public async Task<IActionResult> UpdateStudentsAsync(UpdateStudentsDto students)
        {
            try
            {
                await _studentsService.UpdateStudentsAsync(students);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода UpdateStudentsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateStudentSettings")]
        public async Task<IActionResult> UpdateStudentSettingsAsync(SettingsStudentDto dto, string studentId)
        {
            try
            {
                await _studentsService.UpdateStudentSettingsAsync(dto, studentId);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода UpdateStudentSettingsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("GetListTeacherForStudent")]
        public async Task<IActionResult> GetListTeacherForStudentAsync()
        {
            try
            {
                var result = await _studentsService.GetListTeacherForStudentAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода GetListTeacherForStudentAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpGet("GetScheduleStudentsAsync")]
        public async Task<IActionResult> GetScheduleStudentsAsync(string id)
        {
            try
            {
                var result = await _studentsService.GetScheduleStudentsAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. " +
                    $"Произошла ошибка при работе метода GetScheduleStudentsAsync, {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}
