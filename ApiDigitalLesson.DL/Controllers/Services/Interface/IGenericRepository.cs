namespace ApiDigitalLesson.DL.Controllers.Services.Interface
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
        T GetAsync(Guid id);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        void AddAsync(T entity);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        void UpdateAsync(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        void DeleteAsync(Guid id);
    }
}
