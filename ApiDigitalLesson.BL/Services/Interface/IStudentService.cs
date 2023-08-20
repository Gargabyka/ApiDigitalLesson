#nullable enable
using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

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
        Task<BaseResponse<StudentsDto>> GetStudentUserAsync(string? userId);
        
        /// <summary>
        /// Получение конкретного студента
        /// </summary>
        Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id);

        /// <summary>
        /// Создать студента
        /// </summary>
        Task<IActionResult> CreateStudentsAsync(StudentsDto students, string id);

        /// <summary>
        /// Обновить студента
        /// </summary>
        Task<IActionResult> UpdateStudentsAsync(StudentsDto students);

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync(string id);

        /// <summary>
        /// Получить расписание студента
        /// </summary>
        Task<BaseResponse<List<SchedulerDto>>> GetScheduleStudentsAsync(string studentId);

        /// <summary>
        /// Обновить настройки студента
        /// </summary>
        Task<IActionResult> UpdateStudentSettingsAsync(StudentSettingsDto settingsDto, string studentId);
    }
}
