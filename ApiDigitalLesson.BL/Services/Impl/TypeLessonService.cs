using System.Collections.Immutable;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto.TypeLesson;
using ApiDigitalLesson.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с типом уроков
    /// </summary>
    public class TypeLessonService : ITypeLessonService 
    {
        private readonly IGenericRepository<TypeLessons> _typeLessonGenericRepository;
        private readonly ILogger<TypeLessonService> _logger;
        private readonly IDistributedCache _cache;
        
        private const string TypeLessonCacheKey = "TypeLesson";

        public TypeLessonService(
            IGenericRepository<TypeLessons> typeLessonGenericRepository, 
            ILogger<TypeLessonService> logger, 
            IDistributedCache cache)
        {
            _typeLessonGenericRepository = typeLessonGenericRepository;
            _logger = logger;
            _cache = cache;
        }

        /// <summary>
        /// Создать новый тип урока
        /// </summary>
        public async Task CreateTypeLessonAsync(TypeLessonDto typeLesson)
        {
            try
            {
                await _cache.SetStringAsync(TypeLessonCacheKey, null);
                
                var result = new TypeLessons
                {
                    Id = Guid.NewGuid(),
                    Name = typeLesson.Name,
                    Description = typeLesson.Description,
                    ParentId = typeLesson.ParentId
                };

                await _typeLessonGenericRepository.AddAsync(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать новый тип урока, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить данные урока
        /// </summary>
        public async Task UpdateTypeLessonAsync(TypeLessonDto typeLesson)
        {
            try
            {
                await _cache.SetStringAsync(TypeLessonCacheKey, null);
                
                var typeLessons = _typeLessonGenericRepository.GetAll();
                var lesson = await typeLessons.SingleOrDefaultAsync(x => x.Id == typeLesson.Id);
                
                if (lesson == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                lesson.Name = typeLesson.Name;
                lesson.Description = typeLesson.Description;
                
                await _typeLessonGenericRepository.UpdateAsync(lesson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
 
        /// <summary>
        /// Получить список типов уроков
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<ImmutableList<TypeLessons>>> GetTypeLessonsAsync()
        {
            try
            {
                var typeLessonsCache = await _cache.GetStringAsync(TypeLessonCacheKey);

                if (!string.IsNullOrEmpty(typeLessonsCache))
                {
                    var typeLessonsResult = JsonConvert.DeserializeObject<ImmutableList<TypeLessons>>(typeLessonsCache);

                    if (typeLessonsResult != null)
                    {
                        return new BaseResponse<ImmutableList<TypeLessons>>(typeLessonsResult);
                    }
                }
                
                var typeLessons = _typeLessonGenericRepository.GetAll();

                var result = typeLessons
                    .AsEnumerable()
                    .SelectMany(x => x.TraverseTree(y => y.SubCategories))
                    .Where(x => !x.ParentId.HasValue)
                    .OrderBy(x => x.Name)
                    .ToImmutableList();

                var cache = JsonConvert.SerializeObject(result);
                
                await _cache.SetStringAsync(TypeLessonCacheKey, cache, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                });

                return new BaseResponse<ImmutableList<TypeLessons>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список типов уроков, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Удалить тип урока
        /// </summary>
        public async Task DeleteTypeLessonAsync(Guid id)
        {
            try
            {
                await _cache.SetStringAsync(TypeLessonCacheKey, null);
                
                var typeLessons = _typeLessonGenericRepository.GetAll();
                var lesson = await typeLessons.SingleOrDefaultAsync(x => x.Id == id);

                if (lesson == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                var isChild = typeLessons.Any(x => x.ParentId == lesson.Id);

                if (isChild)
                {
                    throw new Exception("Нельзя удалить категорию в которой есть дочерние элементы");
                }

                await _typeLessonGenericRepository.DeleteAsync(lesson.Id);
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалить тип урока, {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}