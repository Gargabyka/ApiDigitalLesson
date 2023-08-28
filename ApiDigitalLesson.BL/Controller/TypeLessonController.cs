using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Controller
{
    /// <summary>
    /// Контролер работы с типов уроков
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TypeLessonController : ControllerBase
    {
        private readonly ITypeLessonService _typeLessonService;
        private readonly ILogger<TypeLessonController> _logger;

        public TypeLessonController(
            ITypeLessonService typeLessonService, 
            ILogger<TypeLessonController> logger)
        {
            _typeLessonService = typeLessonService;
            _logger = logger;
        }
        
        //[Authorize(Roles = RolesConst.Admin)]
        [HttpPost("CreateTypeLesson")]
        public async Task<IActionResult> CreateTypeLessonAsync(TypeLessonDto typeLessonDto)
        {
            try
            {
                await _typeLessonService.CreateTypeLessonAsync(typeLessonDto);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TypeLessonController)}. Произошла ошибка при работе метода CreateTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        //[Authorize(Roles = RolesConst.Admin)]
        [HttpPost("UpdateTypeLesson")]
        public async Task<IActionResult> UpdateTypeLessonAsync(TypeLessonDto typeLessonDto)
        {
            try
            {
                await _typeLessonService.UpdateTypeLessonAsync(typeLessonDto);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TypeLessonController)}. Произошла ошибка при работе метода UpdateTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        //[Authorize(Roles = RolesConst.Admin)]
        [HttpPost("DeleteTypeLesson")]
        public async Task<IActionResult> DeleteTypeLessonAsync(Guid id)
        {
            try
            {
                await _typeLessonService.DeleteTypeLessonAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TypeLessonController)}. Произошла ошибка при работе метода DeleteTypeLessonAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
        
        
        [HttpGet("GetTypeLessons")]
        public async Task<IActionResult> GetTypeLessonsAsync()
        {
            try
            {
                var result = await _typeLessonService.GetTypeLessonsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(TypeLessonController)}. Произошла ошибка при работе метода GetTypeLessonsAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }
    }
}