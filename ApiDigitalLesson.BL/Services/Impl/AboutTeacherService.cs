using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto.AboutTeacher;
using ApiDigitalLesson.Model.Entity;
using AutoMapper;
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

                var aboutList = await _aboutTeacherRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id)
                    .OrderBy(x=>x.CreateDate)
                    .ToListAsync();
                
                var result = _mapper.Map<List<AboutTeacherDto>>(aboutList);

                return new BaseResponse<List<AboutTeacherDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить отзывы о преподавателе, {e.Message}";
                
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

                if (ratingList.Count <= 0)
                {
                    return new BaseResponse<double>(result);
                }
                
                rating += ratingList.Sum();

                result = (double)rating / ratingList.Count;

                return new BaseResponse<double>(result);

            }
            catch (Exception e)
            {
                var message = $"Не удалось получить среднюю оценку о преподавателе, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создать отзыв о преподавателе
        /// </summary>
        public async Task CreateAboutTeacherAsync(CreateAboutTeacherDto aboutTeacherDto)
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
                    Comment = aboutTeacherDto.Comment,
                    Rating = aboutTeacherDto.Rating,
                    Name = aboutTeacherDto.Name ?? "Аноним",
                    CreateDate = DateTime.UtcNow
                };

                await _aboutTeacherRepository.AddAsync(teacherAbout);
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать отзыв о преподавателе, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Удалить отзыв о преподавателе
        /// </summary>
        public async Task DeleteAboutTeacherAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не удалось получить id отзыва о преподавателе");
                }

                var about = await _aboutTeacherRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id.ToString() == id);

                if (about == null)
                {
                    throw new ApiException("Не удалось найти отзыв");
                }

                await _aboutTeacherRepository.DeleteAsync(about.Id);
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалить отзыв о преподавателе, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}
