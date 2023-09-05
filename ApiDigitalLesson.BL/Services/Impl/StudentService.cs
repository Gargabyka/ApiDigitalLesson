using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Common.Services.Interface.Telegram;
using ApiDigitalLesson.Model.Const;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Scheduler;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Student;
using ApiDigitalLesson.Model.Dto.Teacher;
using ApiDigitalLesson.Model.Entity;
using AutoMapper;
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
        private readonly IViolatorsService _violatorsService;

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
            IUserIdentityService identityService, 
            IViolatorsService violatorsService)
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
            _violatorsService = violatorsService;
            _settingsStudentGenericRepository = settingsStudentGenericRepository;
        }
        
        /// <summary>
        /// Проверка пользователя на бан
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsBanned() => await _violatorsService.IsBannedCurrentUserAsync();

        /// <summary>
        /// Получить студента пользователя
        /// </summary>
        public async Task<BaseResponse<StudentsDto>> GetStudentUserAsync()
        {
            try
            {
                var user = await _identityService.GetCurrentUserAsync();
                
                var student = await _studentsRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.UserId.ToString() == user.Id);

                if (student == null)
                {
                    throw new Exception("Не удалось получить студента пользователя.");
                }

                var result = _mapper.Map<StudentsDto>(student);
            
                return new BaseResponse<StudentsDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить студента пользователя, {e.Message}.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
                
        /// <summary>
        /// Получить настройки студента
        /// </summary>
        public async Task<BaseResponse<SettingsStudentDto>> GetStudentSettingsAsync()
        {
            try
            {
                var students = _studentsRepository.GetAll();
                var currentUser = await _identityService.GetCurrentUserAsync();

                var student = await students
                    .Include(x=>x.SettingsStudent)
                    .SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);

                if (student == null)
                {
                    throw new Exception("Не удалось найти студента");
                }
                
                var result = _mapper.Map<SettingsStudentDto>(student.SettingsStudent);
                
                return new BaseResponse<SettingsStudentDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить настройки студента, {e.Message}";
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
                var message = $"Не удалось получить студента по id: {id}, {e.Message}";
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

                if (studentsList.Any(x => x.UserId.ToString() == user.Id))
                {
                    throw new Exception("Пользователь под таким пользователем уже существует");
                }

                if (studentsList.Any(x => x.TelegramId == student.TelegramId) ||
                    teacherList.Any(x=>x.TelegramId == student.TelegramId))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует");
                }

                var settingsStudent = new SettingsStudent
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
                    IsLessonComingSoonEmail = true
                };

                var settingsId = await _settingsStudentGenericRepository.AddAsync(settingsStudent);

                var newStudent = new Students
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
                var message = $"Не удалось создать нового студента по id: {id}, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить настройки студента
        /// </summary>
        public async Task UpdateStudentSettingsAsync(SettingsStudentDto dto, string studentId)
        {
            try
            {
                if (await IsBanned())
                {
                    throw new Exception("Пользователь заблокирован.");
                }
                
                var allStudents = _studentsRepository.GetAll();
                var currentUser = await _identityService.GetCurrentUserAsync();
                var student = await allStudents.SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студена.");
                }

                var settings = student.SettingsStudent;
                settings.IsAllowCreateLesson = dto.IsAllowCreateLesson != settings.IsAllowCreateLesson ? dto.IsAllowCreateLesson : settings.IsAllowCreateLesson;
                settings.IsNotificationTelegram = dto.IsAllowCreateLesson != settings.IsAllowCreateLesson ? dto.IsAllowCreateLesson : settings.IsAllowCreateLesson;
                settings.IsRequestForLessonTelegram = dto.IsRequestForLessonTelegram != settings.IsRequestForLessonTelegram ? dto.IsRequestForLessonTelegram : settings.IsRequestForLessonTelegram;
                settings.IsAcceptForLessonTelegram = dto.IsAcceptForLessonTelegram != settings.IsAcceptForLessonTelegram ? dto.IsAcceptForLessonTelegram : settings.IsAcceptForLessonTelegram;
                settings.IsLessonComingSoonTelegram = dto.IsLessonComingSoonTelegram != settings.IsLessonComingSoonTelegram ? dto.IsLessonComingSoonTelegram : settings.IsLessonComingSoonTelegram;
                settings.IsCancelLessonTelegram = dto.IsCancelLessonTelegram != settings.IsCancelLessonTelegram ? dto.IsCancelLessonTelegram : settings.IsCancelLessonTelegram;
                settings.TimeBeforeLesson = dto.TimeBeforeLesson != settings.TimeBeforeLesson ? dto.TimeBeforeLesson : settings.TimeBeforeLesson;
                settings.IsNotificationEmail = dto.IsNotificationEmail != settings.IsNotificationEmail ? dto.IsNotificationEmail : settings.IsNotificationEmail;
                settings.IsRequestForLessonEmail = dto.IsRequestForLessonEmail != settings.IsRequestForLessonEmail ? dto.IsRequestForLessonEmail : settings.IsRequestForLessonEmail;
                settings.IsAcceptForLessonEmail = dto.IsAcceptForLessonEmail != settings.IsAcceptForLessonEmail ? dto.IsAcceptForLessonEmail : settings.IsAcceptForLessonEmail;
                settings.IsLessonComingSoonEmail = dto.IsLessonComingSoonEmail != settings.IsLessonComingSoonEmail ? dto.IsLessonComingSoonEmail : settings.IsLessonComingSoonEmail;
                settings.IsCancelLessonEmail = dto.IsCancelLessonEmail != settings.IsCancelLessonEmail ? dto.IsCancelLessonEmail : settings.IsCancelLessonEmail;

                await _settingsStudentGenericRepository.UpdateAsync(settings);
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить настройки студента по id: {studentId}, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Обновить данные студента
        /// </summary>
        public async Task UpdateStudentsAsync(UpdateStudentsDto studentsDto)
        {
            try
            {
                if (await IsBanned())
                {
                    throw new Exception("Пользователь заблокирован.");
                }
                
                var allStudents = _studentsRepository.GetAll();
                var teacherList = _teacherRepository.GetAll();

                var currentUser = await _identityService.GetCurrentUserAsync();
                var student = await allStudents.SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студена.");
                }

                if (student.TelegramId != studentsDto.TelegramId &&
                    (allStudents.Any(x => x.TelegramId == studentsDto.TelegramId) ||
                     teacherList.Any(x=>x.TelegramId == studentsDto.TelegramId)))
                {
                    throw new Exception("Пользователь с таким TelegramId уже существует.");
                }

                student.Phone = studentsDto.Phone ?? student.Phone;
                student.TelegramId = studentsDto.TelegramId ?? student.TelegramId;
                student.Description = studentsDto.Description ?? student.Description;
                student.Email = studentsDto.Email ?? student.Email;

                await _studentsRepository.UpdateAsync(student);

                if (student.TelegramId.HasValue && student.TelegramId.Value != 0)
                {
                    var message =
                        $"Уважаемый(ая) {student.Surname} {student.Name} {student.MiddleName}, вы успешно привязали телеграмм к своему аккаунту.";
                    await _telegramService.SendMessageAsync(student.TelegramId.Value, message);
                }
            }
            catch (Exception e)
            {
                var message = $"Не удалось обновить информацию о студенте по id. {e.Message}.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        public async Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync()
        {
            try
            {
                var typeLessonList = new List<TeacherTypeLesson>();

                var allStudents = _studentsRepository.GetAll();
                var currentUser = await _identityService.GetCurrentUserAsync();
                var student = await allStudents.SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студена.");
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
                var message = $"Не удалось получить всех преподавателей студента, {e.Message}";
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
                    .Select(x => new SchedulerDto
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
                    .Select(x => new SchedulerDto
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
                var message = $"Не удалось получить расписание студента, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}
