using ApiDigitalLesson.DL.Controllers.Context;
using ApiDigitalLesson.DL.Controllers.Services.Interface;
using ApiDigitalLesson.DL.Model.Entity;
using ApiDigitalLesson.Identity.Exception;
using Microsoft.EntityFrameworkCore;

namespace ApiDigitalLesson.DL.Controllers.Services.Impl
{
    /// <summary>
    /// Сервис для работы с сущностью
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить все данные сущности
        /// </summary>
        public IQueryable<T> GetAll()
        {
           return _context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Получить конкретную сущность
        /// </summary>
        public T GetAsync(Guid id)
        {
            var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ApiException("Не удалось найти сущность по указанному id");
            }
            return entity;
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        public void AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        public void UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ApiException("Не удалось обновить сущность");
            }
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        public void DeleteAsync(Guid id)
        {
            var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ApiException("Не удалось найти сущность по указанному id");
            }

            _context.Set<T>().Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
