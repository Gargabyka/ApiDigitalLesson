﻿using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Migration.Context;
using AspDigitalLesson.Model.Entity;
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
                var message = $"{typeof(T)}:Не удалось получить данные сущности: {nameof(T)}, {e.InnerException}";
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Получить конкретную сущность
        /// </summary>
        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                var entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new ApiException($"Не удалось найти сущность: {nameof(T)} по указанному id: {id}");
                }
                return entity;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить данные сущности: {nameof(T)}, {e.InnerException}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        public async Task<Guid> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                var id = entity.Id;
                return id;
            }
            catch (AddException e)
            {
                var message = $"Не удалось добавить данные сущность: {nameof(T)}, {e.InnerException}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        public async Task UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ApiException($"Не удалось обновить сущность: {nameof(T)}");
                }
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить сущность: {nameof(T)}, {e.InnerException}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
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
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалить данные сущности: {nameof(T)}, {e.InnerException}";
                
                _logger.LogError(message);
                throw new ApiException(message);
            }
        }
    }
}
