using System.Security.Claims;
using ApiDigitalLesson.DL.Controllers.Services.Interface;
using ApiDigitalLesson.DL.Model.Dto;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.DL.Controllers.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController: ControllerBase
    {
        private readonly IStudentsService _studentsService;
        private readonly UserManager<UserIdentity> _userManager;

        public StudentsController(IStudentsService studentsService, UserManager<UserIdentity> userManager, ClaimsPrincipal userPrincipal)
        {
            _studentsService = studentsService;
            _userManager = userManager;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetStudentsAsync(string? id)
        {
            var result = await _studentsService.GetStudentsAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudentsAsync(StudentsDto students, string? id)
        {
            var result = _studentsService.CreateStudentsAsync(students, id);
            return Ok(result);
        }
    }
}
