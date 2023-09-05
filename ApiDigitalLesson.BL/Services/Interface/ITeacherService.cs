using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Scheduler;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Teacher;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="TeacherService"/>
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Получить преподавателя пользователя
        /// </summary>
        Task<BaseResponse<TeacherDto>> GetTeacherUserAsync();

        /// <summary>
        /// Получить настройки преподавателя
        /// </summary>
        Task<BaseResponse<SettingsTeacherDto>> GetTeacherSettingsAsync();

        /// <summary>
        /// Получить список преподавателей
        /// </summary>
        Task<BaseResponse<List<TeacherDto>>> GetTeachersLessonAsync();

        /// <summary>
        /// Получить список преподавателей и их типов уроков
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<List<TeacherWithTypeLessonDto>>> GetTeachersWithTypeLessonAsync();
        
        /// <summary>
        /// Создание выходных для преподавателя
        /// </summary>
        Task<BaseResponse<string>> CreateWeekendForTeacherAsync(SchedulerDto scheduler);

        /// <summary>
        /// Создание нового преподавателя
        /// </summary>
        Task CreateTeacherAsync(TeacherDto teacherDto, string userId);

        /// <summary>
        /// Получить преподавателя по Id
        /// </summary>
        Task<BaseResponse<TeacherDto>> GetTeacherAsync(string id);

        /// <summary>
        /// Обновить информацию по преподавателю
        /// </summary>
        Task UpdateTeacherAsync(UpdateTeacherDto teacherDto);

        /// <summary>
        /// Получить расписание преподавателя
        /// </summary>
        Task<BaseResponse<List<SchedulerDto>>> GetSchedulerTeacherAsync(string teacherId);

        /// <summary>
        /// Получить список студентов преподавателя
        /// </summary>
        Task<BaseResponse<List<StudentsDto>>> GetStudentsForTeacherAsync(string teacherId);

        /// <summary>
        /// Обновить настройки преподавателя
        /// </summary> 
        Task UpdateTeacherSettingsAsync(SettingsTeacherDto teacherDto, string teacherId);
    }
}