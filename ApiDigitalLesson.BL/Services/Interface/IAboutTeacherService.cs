using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="AboutTeacherService"/>
    /// </summary>
    public interface IAboutTeacherService
    {
        /// <summary>
        /// Получить отзывы о преподавателе по Id
        /// </summary>
        Task<BaseResponse<List<AboutTeacherDto>>> GetAboutTeachersListAsync(string teacherId);

        /// <summary>
        /// Создать отзыв о преподавателе
        /// </summary>
        Task<IActionResult> CreateAboutTeacherAsync(AboutTeacherDto aboutTeacherDto);

        /// <summary>
        /// Удалить отзыв о преподавателе
        /// </summary>
        Task<IActionResult> DeleteAboutTeacherAsync(string aboutId);

        /// <summary>
        /// Получить среднюю оценку преподавателя
        /// </summary>
        Task<BaseResponse<double>> GetAvengerRatingForTeacherAsync(string teacherId);
    }
}
