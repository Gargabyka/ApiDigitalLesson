using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
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
        public async Task<IActionResult> GetStudentUserAsync(string? id)
        {
            try
            {
                var result = await _studentsService.GetStudentUserAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода GetStudentUserAsync";
                
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
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода GetStudentsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("CreateStudents")]
        public async Task<IActionResult> CreateStudentsAsync(StudentsDto students, string id)
        {
            try
            {
                var result = await _studentsService.CreateStudentsAsync(students, id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода CreateStudentsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("UpdateStudents")]
        public async Task<IActionResult> UpdateStudentsAsync(StudentsDto students)
        {
            try
            {
                var result = await _studentsService.UpdateStudentsAsync(students);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода UpdateStudentsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        [HttpPost("UpdateStudentSettings")]
        public async Task<IActionResult> UpdateStudentSettingsAsync(StudentSettingsDto settingsDto, string studentId)
        {
            try
            {
                var result = await _studentsService.UpdateStudentSettingsAsync(settingsDto, studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода UpdateStudentSettingsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("GetListTeacherForStudent")]
        public async Task<IActionResult> GetListTeacherForStudentAsync(string id)
        {
            try
            {
                var result = await _studentsService.GetListTeacherForStudentAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода GetListTeacherForStudentAsync";
                
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
                    $"Контроллер: {nameof(StudentsController)}. Произошла ошибка при работе метода GetScheduleStudentsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}
