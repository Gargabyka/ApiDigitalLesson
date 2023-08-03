#nullable enable
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы со студентом
    /// </summary>
    public interface IStudentsService
    {
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
        Task<IActionResult> UpdateStudentsAsync(StudentsDto students, string id);

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync(string id);

        /// <summary>
        /// Получить расписание студента
        /// </summary>
        Task<BaseResponse<List<SchedulerDto>>> GetScheduleStudentsAsync(string studentId);
    }
}
