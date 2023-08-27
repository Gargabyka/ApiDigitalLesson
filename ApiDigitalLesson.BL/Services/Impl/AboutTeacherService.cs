using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
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
                    throw new ApiException("Не удалось получить id преподавателя");
                }

                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                if (teacher == null)
                {
                    throw new ApiException("Не удалось найти преподавателя");
                }

                var aboutList = _aboutTeacherRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id)
                    .ToListAsync();
                
                var result = _mapper.Map<List<AboutTeacherDto>>(aboutList);

                return new BaseResponse<List<AboutTeacherDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить отзывы о преподавателе, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить среднюю оценку преподавателя
        /// </summary>
        public async Task<BaseResponse<double>> GetAvengerRatingForTeacherAsync(string teacherId)
        {
            try
            {
                if (teacherId.IsNull())
                {
                    throw new ApiException("Не удалось получить id преподавателя");
                }
                
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                if (teacher == null)
                {
                    throw new ApiException("Не удалось найти преподавателя");
                }
                
                var ratingList = await _aboutTeacherRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id)
                    .Select(x=> x.Rating)
                    .ToListAsync();

                var rating = 0;
                double result = 0;

                if (ratingList.Count > 0)
                {
                    foreach (var rat in ratingList)
                    {
                        rating += rat;
                    }
                
                    result = (double)rating / ratingList.Count;
                }

                return new BaseResponse<double>(result);

            }
            catch (Exception e)
            {
                var message = $"Не удалось получить среднюю оценку о преподавателе, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
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
                    Comment = aboutTeacherDto.Comment,
                    Rating = aboutTeacherDto.Rating,
                    Name = !aboutTeacherDto.Name.IsNull() ? aboutTeacherDto.Name : "Аноним",
                    CreateDate = aboutTeacherDto.CreateDate
                };

                await _aboutTeacherRepository.AddAsync(teacherAbout);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать отзыв о преподавателе, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
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
                var message = $"Не удалось удалить отзыв о преподавателе, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}
