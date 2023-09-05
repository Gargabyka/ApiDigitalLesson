using ApiDigitalLesson.Model.Dto.Scheduler;

namespace ApiDigitalLesson.Model.Dto.SingleLesson
{
    /// <summary>
    /// DTO урока с расписанием
    /// </summary>
    public class SingleLessonWithScheduler : SingleLessonDto
    {
        /// <summary>
        /// Расписание
        /// </summary>
        public SchedulerDto Scheduler { get; set; }
    }
}