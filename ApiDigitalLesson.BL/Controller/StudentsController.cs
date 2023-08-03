using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
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
                Console.WriteLine(e);
                throw;
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
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("UpdateStudents")]
        public async Task<IActionResult> UpdateStudentsAsync(StudentsDto students, string id)
        {
            try
            {
                var result = await _studentsService.UpdateStudentsAsync(students, id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
            }
        }
    }
}
