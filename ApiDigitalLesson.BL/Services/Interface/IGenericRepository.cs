namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы с сущностью
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
        Task AddAsync(T entity);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
