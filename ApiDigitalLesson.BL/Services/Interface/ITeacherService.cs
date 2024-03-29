﻿using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="TeacherService"/>
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Получить преподавателя пользователя
        /// </summary>
        Task<BaseResponse<TeacherDto>> GetTeacherUserAsync(string? userId);

        /// <summary>
        /// Получить список преподователей
        /// </summary>
        Task<BaseResponse<List<TeacherDto>>> GetTeachersLessonAsync();

        /// <summary>
        /// Получить список преподавателей и их типов уроков
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<List<TeacherWithTypeLessonDto>>> GetTeachersWithTypeLessonAsync();
        
        /// <summary>
        /// Создание выходных для преподавателя
        /// </summary>
        Task<IActionResult> CreateWeekendForTeacherAsync(SchedulerDto scheduler);

        /// <summary>
        /// Создание нового преподавателя
        /// </summary>
        Task<IActionResult> CreateTeacherAsync(TeacherDto teacherDto, string userId);

        /// <summary>
        /// Получить преподавателя по Id
        /// </summary>
        Task<BaseResponse<TeacherDto>> GetTeacherAsync(string id);

        /// <summary>
        /// Обновить информацию по преподавателю
        /// </summary>
        Task<IActionResult> UpdateTeacherAsync(TeacherDto teacherDto);

        /// <summary>
        /// Получить расписание преподавателя
        /// </summary>
        Task<BaseResponse<List<SchedulerDto>>> GetSchedulerTeacherAsync(string teacherId);

        /// <summary>
        /// Получить список студентов преподавателя
        /// </summary>
        Task<BaseResponse<List<StudentsDto>>> GetStudentsForTeacherAsync(string teacherId);

        /// <summary>
        /// Обновить настройки преподавателя
        /// </summary> 
        Task<IActionResult> UpdateTeacherSettingsAsync(SettingsTeacherDto teacherDto, string teacherId);
    }
}