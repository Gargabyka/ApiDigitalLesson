using System.Collections.Immutable;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Common.Services.Impl.Telegram;
using AspDigitalLesson.Model.Const;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис для работы с преподавателями
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Students> _studentsRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonsRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonsRepository;
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonsRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonRepository;
        private readonly IGenericRepository<Scheduler> _schedulerGenericRepository;
        private readonly IGenericRepository<GroupLessonStudents> _groupLessonsStudentsRepository;
        private readonly IGenericRepository<SettingsTeacher> _settingsTeacherGenericRepository;
        private readonly ISchedulerService _schedulerService;
        private readonly ITelegramService _telegramService;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherService> _logger;
        private readonly IUserIdentityService _identityService;

        public TeacherService(
            IGenericRepository<Students> studentsRepository, 
            IGenericRepository<SingleLesson> singleLessonsRepository, 
            IGenericRepository<GroupLesson> groupLessonsRepository, 
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonsRepository, 
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<SingleLesson> singleLessonRepository, 
            IGenericRepository<Scheduler> schedulerGenericRepository,
            IGenericRepository<GroupLessonStudents> groupLessonsStudentsRepository,
            IGenericRepository<SettingsTeacher> settingsTeacherGenericRepository,
            IMapper mapper, 
            ILogger<TeacherService> logger, 
            ITelegramService telegramService, 
            ISchedulerService schedulerService, 
            IUserIdentityService identityService)
        {
            _studentsRepository = studentsRepository;
            _singleLessonsRepository = singleLessonsRepository;
            _groupLessonsRepository = groupLessonsRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
            _teacherRepository = teacherRepository;
            _singleLessonRepository = singleLessonRepository;
            _schedulerGenericRepository = schedulerGenericRepository;
            _settingsTeacherGenericRepository = settingsTeacherGenericRepository;
            _groupLessonsStudentsRepository = groupLessonsStudentsRepository;
            _mapper = mapper;
            _logger = logger;
            _telegramService = telegramService;
            _schedulerService = schedulerService;
            _identityService = identityService;
        }
        
        /// <summary>
        /// Получить преподавателя пользователя
        /// </summary>
        public async Task<BaseResponse<TeacherDto>> GetTeacherUserAsync(string? userId)
        {
            try
            {
                var user = userId != null && !userId.IsNull()
                    ? await _identityService.GetUserForEmailAsync(userId)
                    : await _identityService.GetCurrentUserAsync();
                
                var teacher = await _teacherRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.UserId == Guid.Parse(user.Id));

                if (teacher == null)
                {
                    throw new Exception("Не удалось получить студента пользователя");
                }

                var result = _mapper.Map<TeacherDto>(teacher);

                return new BaseResponse<TeacherDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить преподавателя по id: {userId}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить преподавателя по Id
        /// </summary>
        public async Task<BaseResponse<TeacherDto>> GetTeacherAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id преподавателя");
                }
                
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(id));

                var result = _mapper.Map<TeacherDto>(teacher);

                return new BaseResponse<TeacherDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить преподавателя по id: {id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить список преподователей
        /// </summary>
        public async Task<BaseResponse<List<TeacherDto>>> GetTeachersLessonAsync()
        {
            try
            {
                var teachers = await _teacherRepository.GetAll().ToListAsync();

                var result = _mapper.Map<List<TeacherDto>>(teachers);

                return new BaseResponse<List<TeacherDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список преподавателей, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить список преподавателей и их типов уроков
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<List<TeacherWithTypeLessonDto>>> GetTeachersWithTypeLessonAsync()
        {
            try
            {
                var teacherTypeLessonList = _teacherTypeLessonsRepository.GetAll();
                var teachers = await _teacherRepository.GetAll()
                    .Select(x => new TeacherWithTypeLessonDto
                    {
                        Id = x.Id,
                        Description = x.Description,
                        DateBirthday = x.DateBirthday,
                        Name = x.Name,
                        MiddleName = x.MiddleName,
                        Surname = x.Surname,
                        Photo = x.Photo
                    })
                    .ToListAsync();

                foreach (var teacher in teachers)
                {
                    var teacherTypeLesson = await teacherTypeLessonList
                        .Where(x => x.TeacherId == teacher.Id)
                        .Select(x => new TeacherTypeLessonDto
                        {
                            Id = x.Id.ToString(),
                            TypeLessons = new TypeLessonDto()
                            {
                                Id = x.TypeLessons.Id,
                                Name = x.TypeLessons.Name,
                                Description = x.TypeLessons.Description,
                                ParentId = x.TypeLessons.ParentId
                            },
                            Description = x.Description,
                            IsOffline = x.IsOffline,
                            IsGroup = x.IsGroup,
                            IsOnline = x.IsOnline,
                            IsSingle = x.IsSingle,
                            Price = x.Price
                        })
                        .ToListAsync();
                    
                    teacher.TeacherTypeLesson.AddRange(teacherTypeLesson);
                }

                return new BaseResponse<List<TeacherWithTypeLessonDto>>(teachers);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список преподавателей и их типов уроков, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание нового преподавателя
        /// </summary>
        public async Task<IActionResult> CreateTeacherAsync(TeacherDto teacherDto, string userId)
        {
            try
            {
                var user = await _identityService.GetUserForIdAsync(userId);
                var role = await _identityService.GetRoleUserAsync(user.Id);

                if (role != Roles.Teacher)
                {
                    throw new Exception("Роль пользователя не преподаватель");
                }

                var teacherList = _teacherRepository.GetAll();
                var studentsList = _studentsRepository.GetAll();

                if (studentsList.Any(x => x.UserId == Guid.Parse(user.Id)) || 
                    teacherList.Any(x=>x.UserId == Guid.Parse(user.Id)))
                {
                    throw new Exception("Пользователь под таким пользователем уже существует");
                }

                if (studentsList.Any(x => x.TelegramId == teacherDto.TelegramId) ||
                    teacherList.Any(x=>x.TelegramId == teacherDto.TelegramId))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует");
                }
                
                var settingsStudent = new SettingsTeacher()
                {
                    Id = Guid.NewGuid(),
                    IsAllowCreateLesson = false,
                    IsNotificationTelegram = true,
                    IsRequestForLessonTelegram = true,
                    IsAcceptForLessonTelegram = true,
                    IsLessonComingSoonTelegram = true,
                    IsCancelLessonTelegram = true,
                    TimeBeforeLesson = 1,
                    IsNotificationEmail = true,
                    IsRequestForLessonEmail = true,
                    IsAcceptForLessonEmail = true,
                    IsLessonComingSoonEmail = true,
                    IsCancelLessonEmail = true,
                    TimeCancelLesson = 24,
                    TimeCreateLesson = 24
                };

                var settingsId = await _settingsTeacherGenericRepository.AddAsync(settingsStudent);

                var teacher = new Teacher()
                {
                    Id = Guid.NewGuid(),
                    Name = teacherDto.Name,
                    Surname = teacherDto.Surname,
                    MiddleName = teacherDto.MiddleName,
                    Phone = user.PhoneNumber.IsNull() ? teacherDto.Phone : user.PhoneNumber,
                    Email = user.Email,
                    TelegramId = teacherDto.TelegramId,
                    Description = teacherDto.Description,
                    UserId = Guid.Parse(user.Id),
                    DateBirthday = teacherDto.DateBirthday,
                    SettingsTeacherId = settingsId
                };
                
                await _teacherRepository.AddAsync(teacher);
                
                if (teacher.TelegramId.HasValue && teacher.TelegramId.Value != 0)
                {
                    var message =
                        $"Уважаемый(ая) {teacher.Surname} {teacher.Name} {teacher.MiddleName}, вы успешно привязали телеграмм к своему аккаунту";
                    await _telegramService.SendMessageAsync(teacher.TelegramId.Value, message);
                }
                
                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать нового преподавателя, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить информацию по преподавателю
        /// </summary>
        public async Task<IActionResult> UpdateTeacherAsync(TeacherDto teacherDto)
        {
            try
            {
                var allStudents = _studentsRepository.GetAll();
                var teacherList = _teacherRepository.GetAll();
                
                var teacher = await _teacherRepository.GetAsync(teacherDto.Id);
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }

                if (teacher.TelegramId != teacherDto.TelegramId &&
                    (allStudents.Any(x => x.TelegramId == teacherDto.TelegramId) ||
                    teacherList.Any(x=>x.TelegramId == teacherDto.TelegramId)))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует");
                }

                teacher.Phone = teacherDto.Phone;
                teacher.TelegramId = teacherDto.TelegramId;
                teacher.Description = teacherDto.Description;
                teacher.Photo = teacherDto.Photo;
                
                await _teacherRepository.UpdateAsync(teacher);

                if (teacher.TelegramId.HasValue && teacher.TelegramId.Value != 0)
                {
                    var message =
                        $"Уважаемый(ая) {teacher.Surname} {teacher.Name} {teacher.MiddleName}, вы успешно привязали телеграмм к своему аккаунту";
                    await _telegramService.SendMessageAsync(teacher.TelegramId.Value, message);
                }

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить информацию о студенте по id: {teacherDto.Id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить настройки преподавателя
        /// </summary> 
        public async Task<IActionResult> UpdateTeacherSettingsAsync(SettingsTeacherDto teacherDto, string teacherId)
        {
            try
            {
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя изменять не своего пользователя");
                }
                
                var settings = teacher.SettingsTeacher;
                settings.IsAllowCreateLesson = teacherDto.IsAllowCreateLesson;
                settings.IsNotificationTelegram = teacherDto.IsNotificationTelegram;
                settings.IsRequestForLessonTelegram = teacherDto.IsRequestForLessonTelegram;
                settings.IsAcceptForLessonTelegram = teacherDto.IsAcceptForLessonTelegram;
                settings.IsLessonComingSoonTelegram = teacherDto.IsLessonComingSoonTelegram;
                settings.IsCancelLessonTelegram = teacherDto.IsCancelLessonTelegram;
                settings.TimeBeforeLesson = teacherDto.TimeBeforeLesson;
                settings.IsNotificationEmail = teacherDto.IsNotificationEmail;
                settings.IsRequestForLessonEmail = teacherDto.IsRequestForLessonEmail;
                settings.IsAcceptForLessonEmail = teacherDto.IsAcceptForLessonEmail;
                settings.IsLessonComingSoonEmail = teacherDto.IsLessonComingSoonEmail;
                settings.IsCancelLessonEmail = teacherDto.IsCancelLessonEmail;
                settings.TimeCancelLesson = teacherDto.TimeCancelLesson;
                settings.TimeCreateLesson = teacherDto.TimeCreateLesson;
                
                await _settingsTeacherGenericRepository.UpdateAsync(settings);
                
                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить настройки студента по id: {teacherId}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание выходных для преподавателя
        /// </summary>
        public async Task<IActionResult> CreateWeekendForTeacherAsync(SchedulerDto scheduler)
        {
            try
            {
                var teacher = await _teacherRepository.GetAsync(scheduler.TeacherId);
                
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (teacher.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя обновлять не своего пользователя");
                }


                if (scheduler.DateStart == default || scheduler.DateEnd == default)
                {
                    throw new Exception("Дата начала и дата окончания не может быть стандартной");
                }

                var intersectionDates = new IntersectionDatesDto
                {
                    TeacherId = teacher.Id.ToString(),
                    DateStart = scheduler.DateStart,
                    DateEnd = scheduler.DateEnd
                };

                var intersection = await _schedulerService.IntersectionDates(intersectionDates);

                if (intersection)
                {
                    return new BadRequestResult();
                }

                var weekend = new Scheduler()
                {
                    TeacherId = teacher.Id,
                    DateStart = scheduler.DateStart,
                    DateEnd = scheduler.DateEnd,
                    IsWeekend = true,
                    Description = scheduler.Description
                };

                await _schedulerGenericRepository.AddAsync(weekend);

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать выходные для преподавателя, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить расписание преподавателя
        /// </summary>
        public async Task<BaseResponse<List<SchedulerDto>>> GetSchedulerTeacherAsync(string teacherId)
        {
            try
            {
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                var scheduler = await _schedulerGenericRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id)
                    .Select(x=> new SchedulerDto
                    {
                        Id = x.Id,
                        GroupLessonId = x.GroupLessonId,
                        SingleLessonId = x.SingleLessonId,
                        IsWeekend = x.IsWeekend,
                        NameGroup = x.GroupLessonId.HasValue ? x.GroupLesson.GroupName : string.Empty,
                        NameLesson = x.IsWeekend ? string.Empty : 
                            (x.GroupLessonId.HasValue 
                                ? x.GroupLesson.TeacherTypeLesson.TypeLessons.Name 
                                : x.SingleLesson.TeacherTypeLesson.TypeLessons.Name),
                        TeacherId = x.TeacherId,
                        Description = x.Description,
                        IsCancel = !x.IsWeekend && (x.GroupLessonId.HasValue 
                            ? x.GroupLesson.IsCancel 
                            : x.SingleLesson.IsCancel),
                        IsConfirmedStudent = !x.IsWeekend && (x.GroupLessonId.HasValue 
                            ? x.GroupLesson.IsConfirmedForStudent 
                            : x.SingleLesson.IsConfirmedForStudent),
                        IsConfirmedTeacher = !x.IsWeekend && (x.GroupLessonId.HasValue 
                            ? x.GroupLesson.IsConfirmedForTeacher 
                            : x.SingleLesson.IsConfirmedForTeacher),
                        IsFinish = !x.IsWeekend && (x.GroupLessonId.HasValue 
                            ? x.GroupLesson.IsFinish 
                            : x.SingleLesson.IsFinish),
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd
                    })
                    .ToListAsync();

                return new BaseResponse<List<SchedulerDto>>(scheduler);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить расписание преподавателя, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить список студентов преподавателя
        /// </summary>
        public async Task<BaseResponse<List<StudentsDto>>> GetStudentsForTeacherAsync(string teacherId)
        {
            try
            {
                var students = new List<StudentsDto>();
                var teacher = await _teacherRepository.GetAsync(Guid.Parse(teacherId));
                var scheduler = await _schedulerGenericRepository.GetAll()
                    .Where(x => x.TeacherId == teacher.Id && !x.IsWeekend)
                    .ToListAsync();

                var singleLessonScheduler = scheduler
                    .Where(x => x.SingleLessonId.HasValue)
                    .Select(x => x.SingleLessonId)
                    .ToImmutableList();

                var singleLesson = _singleLessonRepository.GetAll()
                    .Where(x => singleLessonScheduler.Contains(x.Id))
                    .Select(x => x.Students)
                    .Distinct()
                    .ToImmutableList();

                var singleStudents = _mapper.Map<List<StudentsDto>>(singleLesson);
                students.AddRange(singleStudents);
                
                var groupLessonScheduler = scheduler
                    .Where(x => x.GroupLessonId.HasValue)
                    .Select(x => x.GroupLessonId)
                    .ToImmutableList();

                var groupLesson = _groupLessonsRepository.GetAll()
                    .Where(x => groupLessonScheduler.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToImmutableList();

                var groupLessonStudents = _groupLessonsStudentsRepository.GetAll()
                    .Where(x => groupLesson.Contains(x.GroupId))
                    .Select(x => x.Students)
                    .Distinct()
                    .ToImmutableList();
                
                var groupStudents = _mapper.Map<List<StudentsDto>>(groupLessonStudents);
                students.AddRange(groupStudents);

                return new BaseResponse<List<StudentsDto>>(students);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить студентов преподавателя, {e.InnerException}";
                
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}