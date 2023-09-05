using System.Collections.Immutable;
using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.TypeLesson;
using ApiDigitalLesson.Model.Entity;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="TypeLessonService"/>
    /// </summary>
    public interface ITypeLessonService
    {
        /// <summary>
        /// Создать новый тип урока
        /// </summary>
        Task CreateTypeLessonAsync(TypeLessonDto typeLesson);
        
        /// <summary>
        /// Обновить данные урока
        /// </summary>
        Task UpdateTypeLessonAsync(TypeLessonDto typeLesson);
        
        /// <summary>
        /// Получить типы уроков
        /// </summary>
        Task<BaseResponse<ImmutableList<TypeLessons>>> GetTypeLessonsAsync();

        /// <summary>
        /// Удалить тип урока
        /// </summary>
        Task DeleteTypeLessonAsync(Guid id);
    }
}