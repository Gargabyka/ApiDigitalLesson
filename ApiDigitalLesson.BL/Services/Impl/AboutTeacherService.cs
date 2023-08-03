
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Exception;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис для получения отзывов о преподавателе
    /// </summary>
    public class AboutTeacherService : IAboutTeacherService
    {
        private readonly IGenericRepository<AboutTeacher> _aboutTeacherRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AboutTeacherService> _logger;

        public AboutTeacherService(
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<AboutTeacher> aboutTeacherRepository, 
            IMapper mapper, 
            ILogger<AboutTeacherService> logger)
        {
            _teacherRepository = teacherRepository;
            _aboutTeacherRepository = aboutTeacherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Получить отзывы о преподавателе по Id
        /// </summary>
        public async Task<BaseResponse<List<AboutTeacherDto>>> GetAboutTeachersListAsync(string teacherId)
        {
            try
            {
                if (teacherId.IsNull())
                {
                    throw new ApiException("Не удалось найти id");
                }

                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                if (teacher == null)
                {
                    throw new ApiException("Не удалось найти преподавателя");
                }

                var aboutList = await _aboutTeacherRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id)
                    .ToListAsync();
                
                var result = _mapper.Map<List<AboutTeacherDto>>(aboutList);

                return new BaseResponse<List<AboutTeacherDto>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Не удалось получить отзывы о преподавателе, {e.InnerException}");
                
                throw new Exception(
                    $"Не удалось получить отзывы о преподавателе, {e.InnerException}");
            }
        }

        /// <summary>
        /// Создать отзыв о преподавателе
        /// </summary>
        public async Task<IActionResult> CreateAboutTeacherAsync(AboutTeacherDto aboutTeacherDto)
        {
            try
            {
                if (aboutTeacherDto == null)
                {
                    throw new ApiException("Нет данных о преподавателе");
                }

                var teacher = await _teacherRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id == aboutTeacherDto.TeacherId);
                if (teacher == null)
                {
                    throw new ApiException("Не удалось найти преподавателя");
                }

                var teacherAbout = new AboutTeacher
                {
                    Id = Guid.NewGuid(),
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    Comment = aboutTeacherDto.Comment
                };

                await _aboutTeacherRepository.AddAsync(teacherAbout);

                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Не удалось создать отзыв о преподавателе, {e.InnerException}");
                
                throw new Exception(
                    $"Не удалось создать отзыв о преподавателе, {e.InnerException}");
            }
        }

        /// <summary>
        /// Удалить отзыв о преподавателе
        /// </summary>
        public async Task<IActionResult> DeleteAboutTeacherAsync(string aboutId)
        {
            try
            {
                if (!Guid.TryParse(aboutId, out var id))
                {
                    throw new ApiException("Не удалось найти id");
                }

                var about = await _aboutTeacherRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (about == null)
                {
                    throw new ApiException("Не удалось найти отзыв");
                }

                await _aboutTeacherRepository.DeleteAsync(about.Id);

                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Не удалось удалить отзыв о преподавателе, {e.InnerException}");
                
                throw new Exception(
                    $"Не удалось удалить отзыв о преподавателе, {e.InnerException}");
            }
        }
    }
}
