﻿using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AspDigitalLesson.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Roles = AspDigitalLesson.Model.Const.Roles;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с индивидуальными занятиями
    /// </summary>
    public class SingleLessonService : ISingleLessonService
    {
        private readonly IGenericRepository<Students> _studentsRepository;
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonsRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonRepository;
        private readonly IGenericRepository<Scheduler> _schedulerGenericRepository;
        private readonly IGenericRepository<SettingsTeacher> _settingsTeacherGenericRepository;
        private readonly IGenericRepository<SettingsStudent> _settingsStudentGenericRepository;
        private readonly ILogger<SingleLessonService> _logger;
        private readonly IUserIdentityService _identityService;
        private readonly INotificationService _notificationService;
        private readonly ISchedulerService _schedulerService;

        public SingleLessonService(
            IGenericRepository<Students> studentsRepository,
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonsRepository, 
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<SingleLesson> singleLessonRepository, 
            IGenericRepository<Scheduler> schedulerGenericRepository,
            ILogger<SingleLessonService> logger, 
            IUserIdentityService identityService, 
            INotificationService notificationService, 
            ISchedulerService schedulerService, 
            IGenericRepository<SettingsTeacher> settingsTeacherGenericRepository, 
            IGenericRepository<SettingsStudent> settingsStudentGenericRepository)
        {
            _studentsRepository = studentsRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
            _teacherRepository = teacherRepository;
            _singleLessonRepository = singleLessonRepository;
            _schedulerGenericRepository = schedulerGenericRepository;
            _logger = logger;
            _identityService = identityService;
            _notificationService = notificationService;
            _schedulerService = schedulerService;
            _settingsTeacherGenericRepository = settingsTeacherGenericRepository;
            _settingsStudentGenericRepository = settingsStudentGenericRepository;
        }

        /// <summary>
        /// Получить индивидуальный урок по id
        /// </summary>
        public async Task<BaseResponse<SingleLessonWithScheduler>> GetSingleLessonForIdAsync(string id)
        {
            try
            {
                var scheduler = _schedulerGenericRepository.GetAll();
                var lesson = await _singleLessonRepository.GetAsync(Guid.Parse(id));

                var currentSchedulerLesson = await scheduler
                    .SingleOrDefaultAsync(x => x.SingleLessonId == lesson.Id);

                if (currentSchedulerLesson == null)
                {
                    throw new Exception("Не удалось найти расписание урока");
                }

                var result = new SingleLessonWithScheduler
                {
                    Id = lesson.Id,
                    IsCancel = lesson.IsCancel,
                    IsConfirmedStudent = lesson.IsConfirmedForStudent,
                    IsConfirmedTeacher = lesson.IsConfirmedForTeacher,
                    IsFinish = lesson.IsFinish,
                    TeacherTypeLessonId = lesson.TeacherTypeLessonId,
                    Scheduler = new SchedulerDto
                    {
                        Id = currentSchedulerLesson.Id,
                        TeacherId = currentSchedulerLesson.TeacherId,
                        NameLesson = currentSchedulerLesson.SingleLesson.TeacherTypeLesson.TypeLessons.Name,
                        Description = currentSchedulerLesson.Description,
                        DateStart = currentSchedulerLesson.DateStart,
                        DateEnd = currentSchedulerLesson.DateEnd
                    },
                    StudentId = lesson.StudentsId,
                    Student = new StudentsDto
                    {
                        Id = lesson.Students.Id,
                        Name = lesson.Students.Name,
                        MiddleName = lesson.Students.MiddleName,
                        Surname = lesson.Students.Surname
                    }
                };

                return new BaseResponse<SingleLessonWithScheduler>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить индивидуальный урок по id: {id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить индивидуальные уроки преподавателя
        /// </summary>
        public async Task<BaseResponse<List<SingleLessonWithScheduler>>> GetSingleLessonForTeacherIdAsync(
            string teacherId)
        {
            try
            {
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                var singleLesson = _singleLessonRepository.GetAll();

                var singleLessonTeacher = await singleLesson
                    .Where(x => x.TeacherTypeLesson.TeacherId == teacher.Id)
                    .Select(x=>x.Id)
                    .ToListAsync();

                var result = await _schedulerGenericRepository.GetAll()
                    .Where(x => x.SingleLessonId.HasValue 
                                && singleLessonTeacher.Contains(x.SingleLessonId.Value))
                    .Where(x=> x.SingleLesson.IsConfirmedForStudent && x.SingleLesson.IsConfirmedForTeacher)
                    .Select(x => new SingleLessonWithScheduler
                    {
                        Id = x.SingleLesson.Id,
                        TeacherTypeLessonId = x.SingleLesson.TeacherTypeLessonId,
                        IsCancel = x.SingleLesson.IsCancel,
                        IsConfirmedStudent = x.SingleLesson.IsConfirmedForStudent,
                        IsConfirmedTeacher = x.SingleLesson.IsConfirmedForTeacher,
                        IsFinish = x.SingleLesson.IsFinish,
                        Scheduler = new SchedulerDto
                        {
                            Id = x.Id,
                            SingleLessonId = x.SingleLessonId,
                            TeacherId = x.TeacherId,
                            NameLesson = x.SingleLesson.TeacherTypeLesson.TypeLessons.Name,
                            Description = x.Description,
                            DateStart = x.DateStart,
                            DateEnd = x.DateEnd
                        },
                        StudentId = x.SingleLesson.StudentsId,
                        Student = new StudentsDto
                        {
                            Id = x.SingleLesson.Students.Id,
                            Name = x.SingleLesson.Students.Name,
                            MiddleName = x.SingleLesson.Students.MiddleName,
                            Surname = x.SingleLesson.Students.Surname
                        }
                    })
                    .ToListAsync();

                return new BaseResponse<List<SingleLessonWithScheduler>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить индивидуальные уроки преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание индивидуального урока
        /// </summary>
        public async Task<ActionResult> CreateSingleLessonAsync(CreateSingleLessonDto data)
        {
            try
            {
                var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(Guid.Parse(data.TeacherTypeLessonId));
                
                var teacher = await _teacherRepository.GetAsync(teacherTypeLesson.TeacherId);
                var teacherSettings = await _settingsTeacherGenericRepository.GetAsync(teacher.SettingsTeacherId);
                
                var student = await _studentsRepository.GetAsync(Guid.Parse(data.StudentId));
                var studentSettings = await _settingsStudentGenericRepository.GetAsync(student.SettingsStudentId);

                var currentUser = await _identityService.GetCurrentUserAsync();
                var currentRole = await _identityService.GetRoleCurrentUserAsync();

                if (currentRole == Roles.Teacher && teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }
                
                if (currentRole == Roles.Student && student.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }

                if (currentRole == Roles.Student && !teacherSettings.IsAllowCreateLesson)
                {
                    throw new Exception("Преподаватель запретил создавать в своем календаре уроки");
                }
                
                if (currentRole == Roles.Teacher && !studentSettings.IsAllowCreateLesson)
                {
                    throw new Exception("Студент запретил создавать в своем календаре уроки");
                }
                
                var timeCancel = data.DateStart.AddHours(-teacherSettings.TimeCreateLesson);

                if (DateTime.UtcNow > timeCancel)
                {
                    throw new Exception("Нельзя отменить занятие позже заложенного преподавателем времени");
                }
                
                var intersectionDates = new IntersectionDatesDto
                {
                    TeacherId = teacher.Id.ToString(),
                    DateStart = data.DateStart,
                    DateEnd = data.DateEnd
                };

                var isIntersectionDates = await _schedulerService.IntersectionDates(intersectionDates);

                if (isIntersectionDates)
                {
                    throw new Exception("Найдено пересечение дат");
                }

                var singleLesson = new SingleLesson()
                {
                    Id = Guid.NewGuid(),
                    StudentsId = student.Id,
                    TeacherTypeLessonId = teacherTypeLesson.Id,
                    IsCancel = false,
                    IsFinish = false,
                    IsConfirmedForStudent = currentRole == Roles.Student,
                    IsConfirmedForTeacher = currentRole == Roles.Teacher
                };

                var singleLessonId = await _singleLessonRepository.AddAsync(singleLesson);

                var scheduler = new Scheduler()
                {
                    Id = Guid.NewGuid(),
                    TeacherId = teacher.Id,
                    SingleLessonId = singleLessonId,
                    Description = data.Description,
                    DateStart = data.DateStart,
                    DateEnd = data.DateEnd
                };

                await _schedulerGenericRepository.AddAsync(scheduler);

                return new OkResult();
            }
            catch (AddException e)
            {
                await DeleteEmptySingleLessonWithError(data);
                var message =
                    $"Не удалось создать индивидуальный урок преподавателя, произошла ошибка при добавлении записи {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать индивидуальный урок преподавателя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить список неподтвержденных уроков пользователя
        /// </summary>
        public async Task<BaseResponse<List<SingleLessonWithScheduler>>> GetUnConfirmSingleLessonAsync()
        {
            try
            {
                var currentUser = await _identityService.GetCurrentUserAsync();
                var currentRole = await _identityService.GetRoleCurrentUserAsync();

                var singleLesson = await _singleLessonRepository.GetAll()
                    .WhereIf(currentRole == Roles.Teacher,
                        x => x.TeacherTypeLesson.Teacher.UserId.ToString() == currentUser.Id &&
                             !x.IsConfirmedForTeacher)
                    .WhereIf(currentRole == Roles.Student,
                        x => x.Students.UserId.ToString() == currentUser.Id && !x.IsConfirmedForStudent)
                    .ToListAsync();
                
                var result = await _schedulerGenericRepository.GetAll()
                    .Where(x => x.SingleLessonId.HasValue 
                                && singleLesson.Select(x=>x.Id).Contains(x.SingleLesson.Id))
                    .Select(x => new SingleLessonWithScheduler
                    {
                        Id = x.SingleLesson.Id,
                        TeacherTypeLessonId = x.SingleLesson.TeacherTypeLessonId,
                        IsCancel = x.SingleLesson.IsCancel,
                        IsConfirmedStudent = x.SingleLesson.IsConfirmedForStudent,
                        IsConfirmedTeacher = x.SingleLesson.IsConfirmedForTeacher,
                        IsFinish = x.SingleLesson.IsFinish,
                        Scheduler = new SchedulerDto
                        {
                            Id = x.Id,
                            SingleLessonId = x.SingleLessonId,
                            TeacherId = x.TeacherId,
                            NameLesson = x.SingleLesson.TeacherTypeLesson.TypeLessons.Name,
                            Description = x.Description,
                            DateStart = x.DateStart,
                            DateEnd = x.DateEnd
                        },
                        StudentId = x.SingleLesson.StudentsId,
                        Student = new StudentsDto
                        {
                            Id = x.SingleLesson.Students.Id,
                            Name = x.SingleLesson.Students.Name,
                            MiddleName = x.SingleLesson.Students.MiddleName,
                            Surname = x.SingleLesson.Students.Surname
                        }
                    })
                    .ToListAsync();

                return new BaseResponse<List<SingleLessonWithScheduler>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список неподтвержденных уроков, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Подтвердить индивидуальный урок урок
        /// </summary>
        public async Task<IActionResult> ConfirmSingleLessonAsync(string id)
        {
            try
            {
                var lesson = await _singleLessonRepository.GetAsync(Guid.Parse(id));
                var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(lesson.TeacherTypeLessonId);
                var teacher = await _teacherRepository.GetAsync(teacherTypeLesson.TeacherId);
                var student = await _studentsRepository.GetAsync(lesson.StudentsId);
                
                var currentUser = await _identityService.GetCurrentUserAsync();

                var currentRole = await _identityService.GetRoleCurrentUserAsync();
                
                if (currentRole == Roles.Teacher && teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя подтвердить не свой урок");
                }
                
                if (currentRole == Roles.Student && student.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя подтвердить не свой урок");
                }

                if (currentRole == Roles.Student && lesson.IsConfirmedForStudent)
                {
                    throw new Exception("Вы уже подтвердили урок");
                }

                if (currentRole == Roles.Teacher && lesson.IsConfirmedForTeacher)
                {
                    throw new Exception("Вы уже подтвердили урок");
                }

                var scheduler = await _schedulerGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.SingleLessonId.HasValue && x.SingleLessonId.Value == lesson.Id);

                if (scheduler == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                var intersectionDates = new IntersectionDatesDto
                {
                    TeacherId = teacher.Id.ToString(),
                    DateStart = scheduler.DateStart,
                    DateEnd = scheduler.DateEnd
                };

                var isIntersectionDates = await _schedulerService.IntersectionDates(intersectionDates);

                if (isIntersectionDates)
                {
                    throw new Exception(
                        "Не удается подтвердить урок. В выбранный промежуток времени уже есть другой урок");
                }

                lesson.IsConfirmedForStudent = currentRole == Roles.Student || lesson.IsConfirmedForStudent;
                lesson.IsConfirmedForTeacher = currentRole == Roles.Teacher || lesson.IsConfirmedForTeacher;

                await _singleLessonRepository.UpdateAsync(lesson);
                
                var notification = new NotificationLessonDto()
                {
                    Id = lesson.Id.ToString(),
                    UserId = currentUser.Id,
                    LessonEnum = LessonEnum.Single,
                    NotificationSend = NotificationSend.AcceptLesson
                };

                await _notificationService.SendNotification(notification);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось подтвердить индивидуальный урок, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Отменить индивидуальный урок
        /// </summary>
        public async Task<IActionResult> CancelSingleLessonAsync(string id, string description)
        {
            try
            {
                var lesson = await _singleLessonRepository.GetAsync(Guid.Parse(id));

                if (lesson.IsCancel)
                {
                    throw new Exception("Занятие уже отменено");
                }
                
                var currentRole = await _identityService.GetRoleCurrentUserAsync();
                
                var scheduler = await _schedulerGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.SingleLessonId.HasValue && x.SingleLessonId == lesson.Id);

                if (scheduler == null)
                {
                    throw new Exception("Не удалось найти урок");
                }

                switch (currentRole)
                {
                    case Roles.Student:
                        await CancelSingleLessonStudentAsync(description, lesson, scheduler);
                        break;
                    case Roles.Teacher:
                        await CancelSingleLessonTeacherAsync(description, lesson);
                        break;
                }

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось отменить индивидуальный урок, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Отмена занятия студентом
        /// </summary>
        private async Task CancelSingleLessonStudentAsync(string description, SingleLesson lesson, Scheduler scheduler)
        {
            var currentUser = await _identityService.GetCurrentUserAsync();

            var teachers = _teacherRepository.GetAll();
            var students = _studentsRepository.GetAll();

            var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(lesson.TeacherTypeLessonId);
            
            var student = await students
                .SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);
            
            if (student == null)
            {
                throw new Exception("Не удалось найти студента");
            }

            if (lesson.Students.Id != student.Id)
            {
                throw new Exception("Нельзя отменить не свой урок");
            }

            var teacher = await teachers
                .SingleOrDefaultAsync(x => x.Id == teacherTypeLesson.TeacherId);

            if (teacher == null)
            {
                throw new Exception("Не удалось найти преподавателя");
            }
            
            var teacherSettings = await _settingsTeacherGenericRepository.GetAsync(teacher.SettingsTeacherId);

            var timeCancel = scheduler.DateStart.AddHours(-teacherSettings.TimeCancelLesson);

            if (DateTime.UtcNow > timeCancel)
            {
                throw new Exception("Нельзя отменить занятие позже заложенного преподавателем времени");
            }

            lesson.IsCancel = true;
            lesson.CancelMessage = description;

            await _singleLessonRepository.UpdateAsync(lesson);

            var notification = new NotificationLessonDto()
            {
                Id = lesson.Id.ToString(),
                UserId = teacher.UserId.ToString(),
                LessonEnum = LessonEnum.Single,
                NotificationSend = NotificationSend.CancelLesson
            };

            await _notificationService.SendNotification(notification);
        }

        /// <summary>
        /// Отмена занятия преподавателем
        /// </summary>
        private async Task CancelSingleLessonTeacherAsync(string description, SingleLesson lesson)
        {
            var currentUser = await _identityService.GetCurrentUserAsync();

            var teachers = _teacherRepository.GetAll();
            var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(lesson.TeacherTypeLessonId);
            var student = await _studentsRepository.GetAsync(lesson.StudentsId);
            var teacher = await teachers
                .SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);
            
            if (teacher == null)
            {
                throw new Exception("Не удалось найти студента");
            }
            
            if (teacherTypeLesson.TeacherId != teacher.Id)
            {
                throw new Exception("Нельзя отменить не свой урок");
            }
            
            lesson.IsCancel = true;
            lesson.CancelMessage = description;

            await _singleLessonRepository.UpdateAsync(lesson);
            

            var notification = new NotificationLessonDto()
            {
                Id = lesson.Id.ToString(),
                UserId = student.UserId.ToString(),
                LessonEnum = LessonEnum.Single,
                NotificationSend = NotificationSend.CancelLesson
            };

            await _notificationService.SendNotification(notification);
        }

        /// <summary>
        /// Удалить пустые уроки в случае ошибки
        /// </summary>
        private async Task DeleteEmptySingleLessonWithError(CreateSingleLessonDto data)
        {
            try
            {
                var singleLessonList = _singleLessonRepository.GetAll();
                var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(Guid.Parse(data.TeacherTypeLessonId));

                var singleLesson = await singleLessonList
                    .Where(x => x.TeacherTypeLesson.Id == teacherTypeLesson.Id)
                    .Select(x => x.Id)
                    .ToListAsync();

                var scheduler = await _schedulerGenericRepository.GetAll()
                    .Where(x => x.SingleLessonId.HasValue && singleLesson.Contains(x.SingleLessonId.Value))
                    .Select(x => x.SingleLessonId)
                    .ToListAsync();

                var deleteId = singleLesson
                    .Where(x => !scheduler.Contains(x))
                    .ToList();

                if (deleteId.Count != 0)
                {
                    foreach (var id in deleteId)
                    {
                        await _singleLessonRepository.DeleteAsync(id);
                    }
                }
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при попытки удалить пустые уроки, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}