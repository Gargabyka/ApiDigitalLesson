using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контроллер для работы с отзывами о пользователе
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AboutTeacherController : ControllerBase
    {
        private readonly IAboutTeacherService _aboutTeacherService;

        public AboutTeacherController(IAboutTeacherService aboutTeacherService)
        {
            _aboutTeacherService = aboutTeacherService;
        }


        [HttpGet("GetAboutTeachersList")]
        public async Task<IActionResult> GetAboutTeachersListAsync(string id)
        {
            var result = await _aboutTeacherService.GetAboutTeachersListAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateAboutTeacher")]
        public async Task<IActionResult> CreateAboutTeacherAsync(AboutTeacherDto aboutTeacherDto)
        {
            var result = await _aboutTeacherService.CreateAboutTeacherAsync(aboutTeacherDto);
            return Ok(result);
        }

        [HttpPost("DeleteAboutTeacher")]
        public async Task<IActionResult> DeleteAboutTeacherAsync(string id)
        {
            var result = await _aboutTeacherService.DeleteAboutTeacherAsync(id);
            return Ok(result);
        }
    }
}
