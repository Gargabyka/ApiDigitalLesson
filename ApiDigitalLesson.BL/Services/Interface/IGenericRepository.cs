using ApiDigitalLesson.BL.Services.Impl;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс для с сервисом <see cref="GenericRepository{T}"/>
    /// </summary>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получить конкретную запись
        /// </summary>
        Task<T> GetAsync(Guid id);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        Task<Guid> AddAsync(T entity);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        Task<Guid> UpdateAsync(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Удалить множество данных сущности
        /// </summary>
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
