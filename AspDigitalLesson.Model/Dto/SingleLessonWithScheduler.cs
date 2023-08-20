namespace AspDigitalLesson.Model.Dto
{
    public class SingleLessonWithScheduler : SingleLessonDto
    {
        /// <summary>
        /// Расписание
        /// </summary>
        public SchedulerDto Scheduler { get; set; }
    }
}