using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис отчисти старых данных из бд
    /// </summary>
    public class CleanerServices : ICleanerServices
    {
        private readonly IGenericRepository<Scheduler> _schedulerRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonRepository;
        private readonly IGenericRepository<GroupLessonStudents> _groupLessonStudentsRepository;
        private readonly ILogger<CleanerServices> _logger;

        public CleanerServices(
            IGenericRepository<Scheduler> schedulerRepository, 
            IGenericRepository<SingleLesson> singleLessonRepository, 
            IGenericRepository<GroupLesson> groupLessonRepository, 
            IGenericRepository<GroupLessonStudents> groupLessonStudentsRepository, 
            ILogger<CleanerServices> logger)
        {
            _schedulerRepository = schedulerRepository;
            _singleLessonRepository = singleLessonRepository;
            _groupLessonRepository = groupLessonRepository;
            _groupLessonStudentsRepository = groupLessonStudentsRepository;
            _logger = logger;
        }

        /// <summary>
        /// Отчистить старые данные из бд
        /// </summary>
        public async Task CleanAsync(int mount)
        {
            try
            {
                var dateDelete = DateTime.UtcNow.AddMonths(-mount);

                var scheduler = await _schedulerRepository.GetAll()
                    .Where(x => x.DateEnd < dateDelete)
                    .ToListAsync();

                var singleLessons = await _singleLessonRepository.GetAll()
                    .Where(x => scheduler.Select(c => c.SingleLesson.Id).Contains(x.Id))
                    .ToListAsync();

                await _singleLessonRepository.DeleteRangeAsync(singleLessons);

                var groupLesson = await _groupLessonRepository.GetAll()
                    .Where(x => scheduler.Select(c => c.GroupLesson.Id).Contains(x.Id))
                    .ToListAsync();

                var groupLessonStudents = await _groupLessonStudentsRepository.GetAll()
                    .Where(x => groupLesson.Select(c => c.Id).Contains(x.GroupId))
                    .ToListAsync();

                await _groupLessonRepository.DeleteRangeAsync(groupLesson);
                await _groupLessonStudentsRepository.DeleteRangeAsync(groupLessonStudents);

                await _schedulerRepository.DeleteRangeAsync(scheduler);
            }
            catch (Exception e)
            {
                var message = $"Не удалось отчистить старые данные из бд: {e.Message}";
                
                _logger.LogError(message);
                throw new Exception(message, e);
            }
        }
    }
}