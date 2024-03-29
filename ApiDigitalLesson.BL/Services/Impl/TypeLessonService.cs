﻿using System.Collections.Immutable;
using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Models.Entity;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с типом уроков
    /// </summary>
    public class TypeLessonService : ITypeLessonService 
    {
        private readonly ClaimsPrincipal _userPrincipal;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly IGenericRepository<TypeLessons> _typeLessonGenericRepository;
        private readonly IGenericRepository<Teacher> _teacherGenericRepository;
        private readonly ILogger<TypeLessonService> _logger;
        private readonly IMapper _mapper;

        public TypeLessonService(
            ClaimsPrincipal userPrincipal, 
            UserManager<UserIdentity> userManager, 
            IGenericRepository<TypeLessons> typeLessonGenericRepository, 
            ILogger<TypeLessonService> logger, 
            IGenericRepository<Teacher> teacherGenericRepository,
            IMapper mapper)
        {
            _userPrincipal = userPrincipal;
            _userManager = userManager;
            _typeLessonGenericRepository = typeLessonGenericRepository;
            _logger = logger;
            _teacherGenericRepository = teacherGenericRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать новый тип урока
        /// </summary>
        public async Task<IActionResult> CreateTypeLessonAsync(TypeLessonDto typeLesson)
        {
            try
            {
                var result = new TypeLessons()
                {
                    Id = Guid.NewGuid(),
                    Name = typeLesson.Name,
                    Description = typeLesson.Description,
                    Category = typeLesson.Category,
                    ParentId = typeLesson.ParentId
                };

                await _typeLessonGenericRepository.AddAsync(result);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать новый тип урока, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить данные урока
        /// </summary>
        public async Task<IActionResult> UpdateTypeLessonAsync(TypeLessonDto typeLesson)
        {
            try
            {
                var typeLessons = _typeLessonGenericRepository.GetAll();
                var lesson = await typeLessons.SingleOrDefaultAsync(x => x.Id == typeLesson.Id);
                
                if (lesson == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                lesson.Name = typeLesson.Name;
                lesson.Description = typeLesson.Description;
                
                await _typeLessonGenericRepository.UpdateAsync(lesson);

                return new OkResult();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
 
        /// <summary>
        /// Получить список типов уроков
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<ImmutableList<TypeLessons>>> GetTypeLessonsAsync()
        {
            try
            {
                var typeLessons = _typeLessonGenericRepository.GetAll();

                var result = typeLessons
                    .AsEnumerable()
                    .SelectMany(x => x.TraverseTree(y => y.SubCategories))
                    .Where(x => !x.ParentId.HasValue)
                    .OrderBy(x => x.Category)
                    .ToImmutableList();

                return new BaseResponse<ImmutableList<TypeLessons>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список типов уроков, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Удалить тип урока
        /// </summary>
        public async Task DeleteTypeLessonAsync(Guid id)
        {
            try
            {
                var typeLessons = _typeLessonGenericRepository.GetAll();
                var lesson = await typeLessons.SingleOrDefaultAsync(x => x.Id == id);

                if (lesson == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                var isChild = typeLessons.Any(x => x.ParentId == lesson.Id);

                if (isChild)
                {
                    throw new Exception("Нельзя удалить категорию в которой есть дочерние элементы");
                }

                await _typeLessonGenericRepository.DeleteAsync(lesson.Id);
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалить тип урока, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}