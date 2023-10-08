using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Migrator.Context;
using ApiDigitalLesson.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис для работы с сущностью
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<GenericRepository<T>> _logger;
        
        public GenericRepository(ApplicationContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Получить все данные сущности
        /// </summary>
        public IQueryable<T> GetAll()
        {
            try
            {
                var result =  _context.Set<T>().AsQueryable();
                return result;
            }
            catch (Exception e)
            {
                var message = $"{typeof(T)}:Не удалось получить данные сущности: {nameof(T)}, {e.Message}";
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Получить конкретную сущность
        /// </summary>
        public async Task<T> GetAsync(Guid id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new ApiException($"Не удалось найти сущность: {nameof(T)} по указанному id: {id}");
                }
                
                await transaction.CommitAsync();
                
                return entity;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                
                var message = $"Не удалось получить данные сущности: {nameof(T)}, {e.Message}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        public async Task<Guid> AddAsync(T entity)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
                
                return entity.Id;
            }
            catch (ApiException e)
            {
                await transaction.RollbackAsync();
                
                var message = $"Не удалось добавить данные сущность: {nameof(T)}, {e.Message}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        public async Task<Guid> UpdateAsync(T entity)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (entity == null)
                {
                    throw new ApiException($"Не удалось обновить сущность: {nameof(T)}");
                }
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
                
                return entity.Id;
                
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                
                var message = $"Не удалось обновить сущность: {nameof(T)}, {e.Message}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);
                if (entity == null)
                {
                    throw new ApiException($"Не удалось найти сущность: {nameof(T)}  по указанному id: {id}");
                }

                _context.Set<T>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                    
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                    
                var message = $"Не удалось удалить данные сущности: {nameof(T)}, {e.Message}";

                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Удалить множество данных сущности
        /// </summary>
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Set<T>().RemoveRange(entities);
                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                    
                var message = $"Не удалось удалить множество данных сущности: {nameof(T)}, {e.Message}";

                _logger.LogError(message);
                throw new ApiException(message);
            }
        }
    }
}
