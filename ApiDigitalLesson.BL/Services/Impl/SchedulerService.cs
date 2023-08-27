using ApiDigitalLesson.BL.Services.Interface;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AspDigitalLesson.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с расписанием
    /// </summary>
    public class SchedulerService : ISchedulerService
    {
        private readonly IGenericRepository<Scheduler> _schedulerGenericRepository;
        private readonly IGenericRepository<Teacher> _teacherGenericRepository;
        private readonly ILogger<SchedulerService> _logger;

        public SchedulerService(
            IGenericRepository<Scheduler> schedulerGenericRepository, 
            IGenericRepository<Teacher> teacherGenericRepository, 
            ILogger<SchedulerService> logger)
        {
            _schedulerGenericRepository = schedulerGenericRepository;
            _teacherGenericRepository = teacherGenericRepository;
            _logger = logger;
        }

        //TODO: Доработать проверку дат для студентов
        /// <summary>
        /// Проверка пересечений дат
        /// </summary>
        public async Task<bool> IntersectionDates(IntersectionDatesDto intersectionDates)
        {
            try
            {
                if (intersectionDates.TeacherId == default)
                {
                    throw new Exception("Не передан Guid преподавателя");
                }
                
                if (intersectionDates.DateStart == default || intersectionDates.DateEnd == default)
                {
                    throw new Exception("Дата начала и дата окончания не может быть стандартной");
                }
                
                var scheduler = _schedulerGenericRepository.GetAll();
                var teacher = await _teacherGenericRepository.GetAsync(Guid.Parse(intersectionDates.TeacherId));

                var dateNew = new DateTimeRange
                {
                    StartDate = intersectionDates.DateStart,
                    EndDate = intersectionDates.DateEnd
                };

                var schedulerTeacher = await scheduler
                    .Where(x => x.TeacherId == teacher.Id)
                    .Where(x => x.SingleLessonId.HasValue && x.SingleLesson.IsConfirmedForStudent && x.SingleLesson.IsConfirmedForTeacher)
                    .Where(x => x.GroupLessonId.HasValue && x.GroupLesson.IsConfirmedForStudent && x.GroupLesson.IsConfirmedForTeacher)
                    .Select(x=> new DateTimeRange
                    {
                        StartDate = x.DateStart,
                        EndDate = x.DateEnd
                    })
                    .ToListAsync();

                foreach (var date in schedulerTeacher)
                {
                    var result = Intersects(date, dateNew);

                    if (result)
                    {
                        return result;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при поиске пересечения дат, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        
        /// <summary>
        /// Проверка на пересечение дат
        /// </summary>
        private bool Intersects(DateTimeRange dateInTable, DateTimeRange dateNew)
        {
            if(dateInTable.StartDate > dateInTable.EndDate || dateNew.StartDate > dateNew.EndDate)
                throw new Exception("Ошибка в проставлении дат");

            if(dateInTable.StartDate == dateInTable.EndDate || dateNew.StartDate == dateNew.EndDate)
                return false; 

            if(dateInTable.StartDate == dateNew.StartDate || dateInTable.EndDate == dateNew.EndDate)
                return true; 

            if(dateInTable.StartDate < dateNew.StartDate)
            {
                if(dateInTable.EndDate > dateNew.StartDate && dateInTable.EndDate < dateNew.EndDate)
                    return true; 

                if(dateInTable.EndDate > dateNew.EndDate)
                    return true; 
            }
            else
            {
                if(dateNew.EndDate > dateInTable.StartDate && dateNew.EndDate < dateInTable.EndDate)
                    return true; 

                if(dateNew.EndDate > dateInTable.EndDate)
                    return true; 
            }

            return false;
        }
    }
}