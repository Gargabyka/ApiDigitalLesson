using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Scheduler;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Student;
using ApiDigitalLesson.Model.Dto.Teacher;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы с сервисом <see cref="StudentService"/>
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Получить студента пользователя
        /// </summary>
        Task<BaseResponse<StudentsDto>> GetStudentUserAsync();

        /// <summary>
        /// Получить настройки студента
        /// </summary>
        Task<BaseResponse<SettingsStudentDto>> GetStudentSettingsAsync();
        
        /// <summary>
        /// Получение конкретного студента
        /// </summary>
        Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id);

        /// <summary>
        /// Создать студента
        /// </summary>
        Task CreateStudentsAsync(StudentsDto students, string id);

        /// <summary>
        /// Обновить студента
        /// </summary>
        Task UpdateStudentsAsync(UpdateStudentsDto students);

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync();

        /// <summary>
        /// Получить расписание студента
        /// </summary>
        Task<BaseResponse<List<SchedulerDto>>> GetScheduleStudentsAsync(string studentId);

        /// <summary>
        /// Обновить настройки студента
        /// </summary>
        Task UpdateStudentSettingsAsync(SettingsStudentDto dto, string studentId);
    }
}
