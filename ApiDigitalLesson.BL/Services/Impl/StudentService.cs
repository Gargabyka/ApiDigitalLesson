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
    /// Сервис для работы со студентами
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IUserIdentityService _identityService;
        private readonly IGenericRepository<Students> _studentsRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonsRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonsRepository;
        private readonly IGenericRepository<GroupLessonStudents> _groupLessonsStudentsRepository;
        private readonly IGenericRepository<Scheduler> _schedulerGenericRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<SettingsStudent> _settingsStudentGenericRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;
        private readonly ITelegramService _telegramService;

        public StudentService(
            IGenericRepository<Students> studentsRepository,
            IGenericRepository<SingleLesson> singleLessonsRepository, 
            IGenericRepository<GroupLesson> groupLessonsRepository, 
            IGenericRepository<Teacher> teacherRepository,
            IGenericRepository<SettingsStudent> settingsStudentGenericRepository,
            IGenericRepository<GroupLessonStudents> groupLessonsStudentsRepository, 
            IGenericRepository<Scheduler> schedulerGenericRepository, 
            IMapper mapper, 
            ILogger<StudentService> logger,
            ITelegramService telegramService, 
            IUserIdentityService identityService)
        {
            _studentsRepository = studentsRepository;
            _singleLessonsRepository = singleLessonsRepository;
            _groupLessonsRepository = groupLessonsRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _logger = logger;
            _groupLessonsStudentsRepository = groupLessonsStudentsRepository;
            _schedulerGenericRepository = schedulerGenericRepository;
            _telegramService = telegramService;
            _identityService = identityService;
            _settingsStudentGenericRepository = settingsStudentGenericRepository;
        }

        /// <summary>
        /// Получить студента пользователя
        /// </summary>
        public async Task<BaseResponse<StudentsDto>> GetStudentUserAsync(string? userId)
        {
            try
            {
                var user = userId != null && !userId.IsNull()
                    ? await _identityService.GetUserForEmailAsync(userId)
                    : await _identityService.GetCurrentUserAsync();
                
                var student = await _studentsRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.UserId == Guid.Parse(user.Id));

                if (student == null)
                {
                    throw new Exception("Не удалось получить студента пользователя");
                }

                var result = _mapper.Map<StudentsDto>(student);
            
                return new BaseResponse<StudentsDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить студента по id: {userId}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить студента по Id
        /// </summary>
        public async Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id студента");
                }

                var student = await _studentsRepository.GetAsync(Guid.Parse(id));

                var result = _mapper.Map<StudentsDto>(student);
            
                return new BaseResponse<StudentsDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить студента по id: {id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание студента по UserId
        /// </summary>
        public async Task CreateStudentsAsync(StudentsDto student, string id)
        {
            try
            {
                var user = await _identityService.GetUserForIdAsync(id);
                var role = await _identityService.GetRoleUserAsync(user.Id);

                if (role != Roles.Student)
                {
                    throw new Exception("Роль пользователя не студент");
                }
                
                var studentsList = _studentsRepository.GetAll();
                var teacherList = _teacherRepository.GetAll();

                if (studentsList.Any(x => x.UserId == Guid.Parse(user.Id)) || 
                    teacherList.Any(x=>x.UserId == Guid.Parse(user.Id)))
                {
                    throw new Exception("Пользователь под таким пользователем уже существует");
                }

                if (studentsList.Any(x => x.TelegramId == student.TelegramId) ||
                    teacherList.Any(x=>x.TelegramId == student.TelegramId))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует");
                }

                var settingsStudent = new SettingsStudent()
                {
                    Id = Guid.NewGuid(),
                    IsAllowCreateLesson = false,
                    IsNotificationTelegram = true,
                    IsRequestForLessonTelegram = true,
                    IsAcceptForLessonTelegram = true,
                    IsCancelLessonTelegram = true,
                    IsLessonComingSoonTelegram = true,
                    TimeBeforeLesson = 1,
                    IsNotificationEmail = true,
                    IsRequestForLessonEmail = true,
                    IsAcceptForLessonEmail = true,
                    IsCancelLessonEmail = true,
                    IsLessonComingSoonEmail = true,
                };

                var settingsId = await _settingsStudentGenericRepository.AddAsync(settingsStudent);

                var newStudent = new Students()
                {
                    Id = Guid.NewGuid(),
                    Name = student.Name,
                    Surname = student.Surname,
                    MiddleName = student.MiddleName,
                    Phone = user.PhoneNumber.IsNull() ? student.Phone : user.PhoneNumber,
                    Email = user.Email,
                    TelegramId = student.TelegramId,
                    Description = student.Description,
                    UserId = Guid.Parse(user.Id),
                    DateBirthday = student.DateBirthday,
                    SettingsStudentId = settingsId
                };
            
                await _studentsRepository.AddAsync(newStudent);
                
                if (student.TelegramId.HasValue && student.TelegramId.Value != 0)
                {
                    var message =
                        $"Уважаемый(ая) {student.Surname} {student.Name} {student.MiddleName}, вы успешно привязали телеграмм к своему аккаунту";
                    await _telegramService.SendMessageAsync(student.TelegramId.Value, message);
                }
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать нового студента по id: {id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить настройки студента
        /// </summary>
        public async Task UpdateStudentSettingsAsync(StudentSettingsDto settingsDto, string studentId)
        {
            try
            {
                var student = await _studentsRepository.GetAsync(Guid.Parse(studentId));
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (student.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя изменять не своего пользователя");
                }

                var settings = student.SettingsStudent;
                settings.IsAllowCreateLesson = settingsDto.IsAllowCreateLesson;
                settings.IsNotificationTelegram = settingsDto.IsNotificationTelegram;
                settings.IsRequestForLessonTelegram = settingsDto.IsRequestForLessonTelegram;
                settings.IsAcceptForLessonTelegram = settingsDto.IsAcceptForLessonTelegram;
                settings.IsLessonComingSoonTelegram = settingsDto.IsLessonComingSoonTelegram;
                settings.IsCancelLessonTelegram = settings.IsCancelLessonTelegram;
                settings.TimeBeforeLesson = settingsDto.TimeBeforeLesson;
                settings.IsNotificationEmail = settingsDto.IsNotificationEmail;
                settings.IsRequestForLessonEmail = settingsDto.IsRequestForLessonEmail;
                settings.IsAcceptForLessonEmail = settingsDto.IsAcceptForLessonEmail;
                settings.IsLessonComingSoonEmail = settingsDto.IsLessonComingSoonEmail;
                settings.IsCancelLessonEmail = settingsDto.IsCancelLessonEmail;

                await _settingsStudentGenericRepository.UpdateAsync(settings);
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить настройки студента по id: {studentId}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить данные студента
        /// </summary>
        public async Task UpdateStudentsAsync(StudentsDto studentsDto)
        {
            try
            {
                var allStudents = _studentsRepository.GetAll();
                var teacherList = _teacherRepository.GetAll();
                
                var student = await allStudents.SingleOrDefaultAsync(x => x.Id == studentsDto.Id);

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студена");
                }
                
                var currentUser = await _identityService.GetCurrentUserAsync();

                if (student.UserId.ToString() != currentUser.Id)
                {
                    throw new Exception("Нельзя изменять не своего пользователя");
                }
                
                if (student.TelegramId != studentsDto.TelegramId &&
                    (allStudents.Any(x => x.TelegramId == student.TelegramId) ||
                    teacherList.Any(x=>x.TelegramId == student.TelegramId)))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует");
                }
                
                student.Phone = studentsDto.Phone;
                student.TelegramId = studentsDto.TelegramId;
                student.Description = studentsDto.Description;

                await _studentsRepository.UpdateAsync(student);

                if (student.TelegramId.HasValue && student.TelegramId.Value != 0)
                {
                    var message =
                        $"Уважаемый(ая) {student.Surname} {student.Name} {student.MiddleName}, вы успешно привязали телеграмм к своему аккаунту";
                    await _telegramService.SendMessageAsync(student.TelegramId.Value, message);
                }
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить информацию о студенте по id: {studentsDto.Id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        public async Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id студента");
                }
                
                var typeLessonList = new List<TeacherTypeLesson>();

                var students = _studentsRepository.GetAll();
                var student = await students.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студента");
                }

                var singleLesson = await _singleLessonsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x => x.TeacherTypeLesson)
                    .ToListAsync();

                typeLessonList.AddRange(singleLesson);

                var groupLessonStudents = await _groupLessonsStudentsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x=> x.GroupId)
                    .ToListAsync();

                var groupLesson = await _groupLessonsRepository.GetAll()
                    .Where(x => groupLessonStudents.Contains(x.Id))
                    .Select(x => x.TeacherTypeLesson)
                    .ToListAsync();

                typeLessonList.AddRange(groupLesson);

                var teacher = typeLessonList
                    .Select(x => x.Teacher)
                    .Distinct()
                    .ToList();

                var result = _mapper.Map<List<TeacherDto>>(teacher);

                return new BaseResponse<List<TeacherDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить всех преподавателей студента, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        
        /// <summary>
        /// Получить расписание студента
        /// </summary>
        public async Task<BaseResponse<List<SchedulerDto>>> GetScheduleStudentsAsync(string studentId)
        {
            try
            {
                var schedulersList = new List<SchedulerDto>();
                var scheduler = _schedulerGenericRepository.GetAll();
                var student = await _studentsRepository.GetAsync(Guid.Parse(studentId));

                var singleLesson = await _singleLessonsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x=>x.Id)
                    .ToListAsync();

                var groupLessonStudents = await _groupLessonsStudentsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x=> x.GroupId)
                    .ToListAsync();
            
                var groupLesson = await _groupLessonsRepository.GetAll()
                    .Where(x => groupLessonStudents.Contains(x.Id))
                    .Select(x=>x.Id)
                    .ToListAsync();

                var singleScheduler = await scheduler
                    .Where(x => singleLesson.Contains(x.Id))
                    .Select(x => new SchedulerDto()
                    {
                        Id = x.Id,
                        SingleLessonId = x.SingleLessonId,
                        NameLesson = x.SingleLesson.TeacherTypeLesson.TypeLessons.Name,
                        Description = x.Description,
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd,
                        IsConfirmedStudent = x.SingleLesson.IsConfirmedForStudent,
                        IsConfirmedTeacher = x.SingleLesson.IsConfirmedForTeacher,
                        IsFinish = x.SingleLesson.IsFinish,
                        IsCancel = x.SingleLesson.IsCancel
                    })
                    .ToListAsync();
                
                schedulersList.AddRange(singleScheduler);

                var groupScheduler = await scheduler
                    .Where(x => groupLesson.Contains(x.Id))
                    .Select(x => new SchedulerDto()
                    {
                        Id = x.Id,
                        GroupLessonId = x.GroupLessonId,
                        NameGroup = x.GroupLesson.GroupName,
                        NameLesson = x.GroupLesson.TeacherTypeLesson.TypeLessons.Name,
                        Description = x.Description,
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd,
                        IsConfirmedStudent = x.SingleLesson.IsConfirmedForStudent,
                        IsConfirmedTeacher = x.SingleLesson.IsConfirmedForTeacher,
                        IsFinish = x.GroupLesson.IsFinish,
                        IsCancel = x.GroupLesson.IsCancel
                    })
                    .ToListAsync();
                
                schedulersList.AddRange(groupScheduler);

                return new BaseResponse<List<SchedulerDto>>(schedulersList);
            
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить расписание студента, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}
