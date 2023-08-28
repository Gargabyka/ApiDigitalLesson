using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы с сервисом <see cref="TeacherTypeLessonService"/>
    /// </summary>
    public interface ITeacherTypeLessonService
    {
        /// <summary>
        /// Получить тип урока преподавателя
        /// </summary>
        Task<BaseResponse<TeacherTypeLessonDto>> GetTeacherTypeLessonAsync(string id);

        /// <summary>
        /// Получить список типов уроков преподавателя
        /// </summary>
        Task<BaseResponse<List<TeacherTypeLessonDto>>> GetTeacherTypeLessonListAsync(string? teacherId);

        /// <summary>
        /// Создать тип урока преподавателя
        /// </summary>
        Task CreateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto);

        /// <summary>
        /// Обновить тип урока преподавателя
        /// </summary>
        Task UpdateTeacherTypeLessonAsync(TeacherTypeLessonDto typeLessonDto);

        /// <summary>
        /// Удалить тип урока преподавателя
        /// </summary>
        Task DeleteTeacherTypeLessonAsync(string id);
    }
}