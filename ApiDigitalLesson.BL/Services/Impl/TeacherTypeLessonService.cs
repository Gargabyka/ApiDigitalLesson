using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с типом урока преподавателя
    /// </summary>
    public class TeacherTypeLessonService : ITeacherTypeLessonService
    {
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonGenericRepository;
        private readonly IGenericRepository<Teacher> _teacherGenericRepository;
        private readonly IGenericRepository<TypeLessons> _typeLessonsGenericRepository;
        private readonly IUserIdentityService _identityService;
        private readonly ILogger<TeacherTypeLessonService> _logger;

        public TeacherTypeLessonService(
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonGenericRepository, 
            IGenericRepository<Teacher> teacherGenericRepository,
            IGenericRepository<TypeLessons> typeLessonsGenericRepository, 
            IUserIdentityService identityService, 
            ILogger<TeacherTypeLessonService> logger)
        {
            _teacherTypeLessonGenericRepository = teacherTypeLessonGenericRepository;
            _teacherGenericRepository = teacherGenericRepository;
            _typeLessonsGenericRepository = typeLessonsGenericRepository;
            _identityService = identityService;
            _logger = logger;
        }

        /// <summary>
        /// Получить тип урока преподавателя
        /// </summary>
        public async Task<BaseResponse<TeacherTypeLessonDto>> GetTeacherTypeLessonAsync(string id)
        {
            try
            {
                var teacherTypeLesson = await _teacherTypeLessonGenericRepository.GetAsync(Guid.Parse(id));
                var typeLesson = await _typeLessonsGenericRepository.GetAsync(teacherTypeLesson.TypeLessonsId);

                var result = new TeacherTypeLessonDto
                {
                    Id = teacherTypeLesson.Id.ToString(),
                    TypeLessons = new TypeLessonDto()
                    {
                        Id = typeLesson.Id,
                        Name = typeLesson.Name,
                        Description = typeLesson.Description,
                        ParentId = typeLesson.ParentId
                    },
                    TeacherId = teacherTypeLesson.TeacherId.ToString(),
                    IsOnline = teacherTypeLesson.IsOnline,
                    IsOffline = teacherTypeLesson.IsOffline,
                    IsGroup = teacherTypeLesson.IsGroup,
                    IsSingle = teacherTypeLesson.IsSingle,
                    Description = teacherTypeLesson.Description,
                    Price = teacherTypeLesson.Price
                };

                return new BaseResponse<TeacherTypeLessonDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить тип урока преподавателя по id: {id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить список типов уроков преподавателя
        /// </summary>
        public async Task<BaseResponse<List<TeacherTypeLessonDto>>> GetTeacherTypeLessonListAsync(string? teacherId)
        {
            try
            {
                var result = await _teacherTypeLessonGenericRepository.GetAll()
                    .WhereIf(!teacherId.IsNull(), x => x.TeacherId.ToString() == teacherId)
                    .Select(x => new TeacherTypeLessonDto
                    {
                        Id = x.Id.ToString(),
                        TypeLessons = new TypeLessonDto()
                        {
                            Id = x.TypeLessons.Id,
                            Name = x.TypeLessons.Name,
                            Description = x.TypeLessons.Description,
                            ParentId = x.TypeLessons.ParentId
                        },
                        TypeLessonId = x.TypeLessonsId.ToString(),
                        TeacherId = x.TeacherId.ToString(),
                        IsOnline = x.IsOnline,
                        IsOffline = x.IsOffline,
                        IsGroup = x.IsGroup,
                        IsSingle = x.IsSingle,
                        Description = x.Description,
                        Price = x.Price
                    })
                    .ToListAsync();

                return new BaseResponse<List<TeacherTypeLessonDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить типы уроков преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создать тип урока преподавателя
        /// </summary>
        public async Task<IActionResult> CreateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto)
        {
            try
            {
                var teacher = await _teacherGenericRepository.GetAsync(Guid.Parse(typeLessonDto.TeacherId));
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (typeLessonDto.IsOnline.HasValue && typeLessonDto.IsOffline.HasValue &&
                    !typeLessonDto.IsOffline.Value && !typeLessonDto.IsOnline.Value)
                {
                    throw new Exception("Надо выбрать минимум один тип проведения урока");
                }

                if (typeLessonDto.IsSingle.HasValue && typeLessonDto.IsGroup.HasValue &&
                    !typeLessonDto.IsSingle.Value && !typeLessonDto.IsGroup.Value)
                {
                    throw new Exception("Надо выбрать минимум один тип проведения урока");
                }

                if (teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }

                var typeLesson = await _typeLessonsGenericRepository.GetAsync(Guid.Parse(typeLessonDto.TypeLessonId));

                if (!typeLesson.ParentId.HasValue)
                {
                    throw new Exception("Нельзя добавлять в тип урока категорию");
                }

                var teacherTypeLesson = new TeacherTypeLesson
                {
                    Id = Guid.NewGuid(),
                    TeacherId = teacher.Id,
                    Description = typeLessonDto.Description,
                    TypeLessonsId = typeLesson.Id,
                    IsOffline = typeLessonDto.IsOffline ?? false,
                    IsOnline = typeLessonDto.IsOnline  ?? false,
                    IsSingle = typeLessonDto.IsSingle ?? false,
                    IsGroup = typeLessonDto.IsGroup ?? false,
                    Price = typeLessonDto.Price ?? 0
                };

                await _teacherTypeLessonGenericRepository.AddAsync(teacherTypeLesson);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать типы уроков преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить тип урока преподавателя
        /// </summary>
        public async Task<IActionResult> UpdateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto)
        {
            try
            {
                var teacher = await _teacherGenericRepository.GetAsync(Guid.Parse(typeLessonDto.TeacherId));
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }

                var teacherTypeLesson = await _teacherTypeLessonGenericRepository.GetAsync(Guid.Parse(typeLessonDto.Id));

                teacherTypeLesson.Description = typeLessonDto.Description;
                teacherTypeLesson.IsOffline = typeLessonDto.IsOffline ?? teacherTypeLesson.IsOffline;
                teacherTypeLesson.IsOnline = typeLessonDto.IsOnline ?? teacherTypeLesson.IsOnline;
                teacherTypeLesson.IsSingle = typeLessonDto.IsSingle ?? teacherTypeLesson.IsSingle;
                teacherTypeLesson.IsGroup = typeLessonDto.IsGroup ?? teacherTypeLesson.IsGroup;
                teacherTypeLesson.Price = typeLessonDto.Price ?? teacherTypeLesson.Price;

                await _teacherTypeLessonGenericRepository.UpdateAsync(teacherTypeLesson);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить типы уроков преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Удалить тип урока преподавателя
        /// </summary>
        public async Task<IActionResult> DeleteTeacherTypeLessonAsync(string id)
        {
            try
            {
                var teacherTypeLesson = await _teacherTypeLessonGenericRepository.GetAsync(Guid.Parse(id));
                var teacher = await _teacherGenericRepository.GetAsync(teacherTypeLesson.TeacherId);
                
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (currentUser.Id != teacher.UserId.ToString())
                {
                    throw new Exception("Нельзя удалять не свой тип урока");
                }

                await _teacherTypeLessonGenericRepository.DeleteAsync(Guid.Parse(id));

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалять типы уроков преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}