using ApiDigitalLesson.Model.Dto.TeacherTypeLesson;

namespace ApiDigitalLesson.Model.Dto.Teacher
{
    /// <summary>
    /// DTO получение преподавателя с типом урока
    /// </summary>
    public class TeacherWithTypeLessonDto : TeacherDto
    {
        /// <summary>
        /// Тип урока преподователя
        /// </summary>
        public List<TeacherTypeLessonDto> TeacherTypeLesson { get; set; }
    }
}