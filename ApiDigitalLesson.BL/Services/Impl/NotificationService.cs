using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Services.Impl.Telegram;
using ApiDigitalLesson.Common.Services.Interface.SMTP;
using ApiDigitalLesson.Identity.Models.Request;
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
    /// Сервис отправки уведомлений
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly IGenericRepository<Teacher> _teacherGenericRepository;
        private readonly IGenericRepository<Students> _studentsGenericRepository;
        private readonly IGenericRepository<Scheduler> _schedulerGenericRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonGenericRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonGenericRepository;
        private readonly IGenericRepository<SettingsTeacher> _settingsTeacherGenericRepository;
        private readonly IGenericRepository<SettingsStudent> _settingsStudentGenericRepository;
        private readonly IGenericRepository<TypeLessons> _typeLessonsGenericRepository;
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonsRepository;
        private readonly IUserIdentityService _identityService;
        private readonly IEmailService _emailService;
        private readonly ITelegramService _telegramService;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IGenericRepository<Teacher> teacherGenericRepository, 
            IGenericRepository<Students> studentsGenericRepository, 
            IGenericRepository<Scheduler> schedulerGenericRepository,
            IGenericRepository<SingleLesson> singleLessonGenericRepository,
            IGenericRepository<GroupLesson> groupLessonGenericRepository,
            IEmailService emailService, 
            ITelegramService telegramService, 
            ILogger<NotificationService> logger, 
            IUserIdentityService identityService, 
            IGenericRepository<SettingsTeacher> settingsTeacherGenericRepository, 
            IGenericRepository<SettingsStudent> settingsStudentGenericRepository, 
            IGenericRepository<TypeLessons> typeLessonsGenericRepository, 
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonsRepository)
        {
            _teacherGenericRepository = teacherGenericRepository;
            _studentsGenericRepository = studentsGenericRepository;
            _schedulerGenericRepository = schedulerGenericRepository;
            _singleLessonGenericRepository = singleLessonGenericRepository;
            _groupLessonGenericRepository = groupLessonGenericRepository;
            _emailService = emailService;
            _telegramService = telegramService;
            _logger = logger;
            _identityService = identityService;
            _settingsTeacherGenericRepository = settingsTeacherGenericRepository;
            _settingsStudentGenericRepository = settingsStudentGenericRepository;
            _typeLessonsGenericRepository = typeLessonsGenericRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
        }

        /// <summary>
        /// Отправить уведомление
        /// </summary>
        public async Task<IActionResult> SendNotification(NotificationLessonDto notificationLesson)
        {
            try
            {
                var user = await _identityService.GetUserForIdAsync(notificationLesson.UserId);
                var role = await _identityService.GetRoleUserAsync(user.Id);

                var teachers = _teacherGenericRepository.GetAll();
                var students = _studentsGenericRepository.GetAll();
                
                switch (role)
                {
                    case Roles.Student:
                        var student = await students
                            .SingleOrDefaultAsync(x=>x.UserId.ToString() == user.Id);

                        if (student == null)
                        {
                            throw new Exception("Не удалось найти студента");
                        }

                        var selectStudent = new SelectNotificationDto()
                        {
                            Email = student.Email,
                            TelegramId = student.TelegramId
                        };

                        var studentsSettings =
                            await _settingsStudentGenericRepository.GetAsync(student.SettingsStudentId);
                        
                        var settingsStudent = new SettingsDto()
                        {
                            IsNotificationTelegram = studentsSettings.IsNotificationTelegram,
                            IsRequestForLessonTelegram = studentsSettings.IsRequestForLessonTelegram,
                            IsAcceptForLessonTelegram = studentsSettings.IsAcceptForLessonTelegram,
                            IsCancelLessonTelegram = studentsSettings.IsCancelLessonTelegram,
                            IsLessonComingSoonTelegram = studentsSettings.IsLessonComingSoonTelegram,
                            TimeBeforeLesson = studentsSettings.TimeBeforeLesson,
                            IsNotificationEmail = studentsSettings.IsNotificationEmail,
                            IsRequestForLessonEmail = studentsSettings.IsRequestForLessonEmail,
                            IsAcceptForLessonEmail = studentsSettings.IsAcceptForLessonEmail,
                            IsCancelLessonEmail = studentsSettings.IsCancelLessonEmail,
                            IsLessonComingSoonEmail = studentsSettings.IsLessonComingSoonEmail,
                        };
                        
                        await SelectSendNotification(notificationLesson, settingsStudent, selectStudent, role);
                        break;
                    case Roles.Teacher:

                        var teacher = await teachers
                            .SingleOrDefaultAsync(x => x.UserId.ToString() == user.Id);

                        if (teacher == null)
                        {
                            throw new Exception("Не удалось найти преподавателя");
                        }

                        var selectTeacher = new SelectNotificationDto()
                        {
                            Email = teacher.Email,
                            TelegramId = teacher.TelegramId
                        };
                        
                        var teacherSettings =
                            await _settingsTeacherGenericRepository.GetAsync(teacher.SettingsTeacherId);
                        
                        var settingsTeacher = new SettingsDto()
                        {
                            IsNotificationTelegram = teacherSettings.IsNotificationTelegram,
                            IsRequestForLessonTelegram = teacherSettings.IsRequestForLessonTelegram,
                            IsAcceptForLessonTelegram = teacherSettings.IsAcceptForLessonTelegram,
                            IsCancelLessonTelegram = teacherSettings.IsCancelLessonTelegram,
                            IsLessonComingSoonTelegram = teacherSettings.IsLessonComingSoonTelegram,
                            TimeBeforeLesson = teacherSettings.TimeBeforeLesson,
                            IsNotificationEmail = teacherSettings.IsNotificationEmail,
                            IsRequestForLessonEmail = teacherSettings.IsRequestForLessonEmail,
                            IsAcceptForLessonEmail = teacherSettings.IsAcceptForLessonEmail,
                            IsCancelLessonEmail = teacherSettings.IsCancelLessonEmail,
                            IsLessonComingSoonEmail = teacherSettings.IsLessonComingSoonEmail,
                        };
                        
                        await SelectSendNotification(notificationLesson, settingsTeacher, selectTeacher, role);
                        break;
                    default:
                        throw new Exception("Не удалось найти роль пользователя");
                }

                return new OkResult();
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при отправке уведомления, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Отправить уведомление
        /// </summary>
        private async Task SelectSendNotification(NotificationLessonDto notificationLessonDto, 
            SettingsDto settings, SelectNotificationDto select, string role)
        {
            if (select.TelegramId.HasValue && settings.IsNotificationTelegram)
            {
                await SendNotificationForTelegram(notificationLessonDto, settings, select, role);
            }

            if (settings.IsNotificationEmail)
            {
                await SendNotificationForEmail(notificationLessonDto, settings, select, role);
            }
        }
        

        /// <summary>
        /// Отправка уведомлений через Telegram
        /// </summary>
        private async Task SendNotificationForTelegram(NotificationLessonDto notificationLessonDto, 
            SettingsDto settings, SelectNotificationDto select, string role)
        {
            var lessonInformation = await GetLessonInformation(notificationLessonDto);
            var message = string.Empty;

            if (!select.TelegramId.HasValue)
            {
                return;
            }
            
            switch (notificationLessonDto.NotificationSend)
            {
                case NotificationSend.AcceptLesson:
                    if (!settings.IsAcceptForLessonTelegram)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие \"{lessonInformation.NameLesson}\" " + 
                          $"\n Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName} было подтверждено!"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие  \"{lessonInformation.NameLesson}\" " +  
                          $"\n Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName} было подтверждено!";

                    await _telegramService.SendMessageAsync(select.TelegramId.Value, message);
                    break;
                case NotificationSend.RequestLesson:
                    if (!settings.IsRequestForLessonTelegram)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, вам пришел запрос на проведение занятия: {lessonInformation.NameLesson} " + 
                          $"\n Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, вам пришел запрос на проведение занятия: {lessonInformation.NameLesson} " +
                          $"\n Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName}";

                    await _telegramService.SendMessageAsync(select.TelegramId.Value, message);
                    break;
                case NotificationSend.CancelLesson:
                    if (!settings.IsCancelLessonTelegram)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"\n Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName} было отменено.\n" +
                          $"Причина отмены: {lessonInformation.CancelMessage}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"\n Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName} было отменено.\n" +
                          $"Причина отмены: {lessonInformation.CancelMessage}";

                    await _telegramService.SendMessageAsync(select.TelegramId.Value, message);
                    break;
                case NotificationSend.ComingLesson:
                    if (!settings.IsCancelLessonTelegram)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"со студентом {lessonInformation.StudentName} скоро начнется. \n Дата занятия: {lessonInformation.StartDate}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"с преподавателем {lessonInformation.TeacherName} скоро начнется. \n Дата занятия: {lessonInformation.StartDate}";
                    
                    await _telegramService.SendMessageAsync(select.TelegramId.Value, message);
                    break;
                default:
                    throw new Exception("Не удалось получить тип уведомления");
            }
        }

        /// <summary>
        /// Отправка уведомлений на email
        /// </summary>
        private async Task SendNotificationForEmail(NotificationLessonDto notificationLessonDto,
            SettingsDto settings, SelectNotificationDto select, string role)
        {
            var lessonInformation = await GetLessonInformation(notificationLessonDto);
            var message = string.Empty;

            var request = new EmailRequest()
            {
                ToName = role == Roles.Teacher
                    ? lessonInformation.StudentName
                    : lessonInformation.TeacherName,
                ToAddress = select.Email
            };

            switch (notificationLessonDto.NotificationSend)
            {
                case NotificationSend.AcceptLesson:
                    if (!settings.IsAcceptForLessonEmail)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие \"{lessonInformation.NameLesson}\"\n" + 
                          $"Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName} было подтверждено!"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие \"{lessonInformation.NameLesson}\"\n" +  
                          $"Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName} было подтверждено!";
                    
                    request.Subject = "Уведомление о подтверждении занятия";
                    request.Body = message;

                    await _emailService.PostAsync(request);
                    break;
                case NotificationSend.RequestLesson:
                    if (!settings.IsRequestForLessonEmail)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, вам пришел запрос на проведение занятия: {lessonInformation.NameLesson}\n" + 
                          $"Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, вам пришел запрос на проведение занятия: {lessonInformation.NameLesson}\n" +
                          $"Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName}";

                    request.Subject = "Уведомление о запросе на занятие";
                    request.Body = message;

                    await _emailService.PostAsync(request);
                    break;
                case NotificationSend.CancelLesson:
                    if (!settings.IsCancelLessonEmail)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие: {lessonInformation.NameLesson}\n" +
                          $"Дата занятия: {lessonInformation.StartDate} со студентом {lessonInformation.StudentName} было отменено.\n" +
                          $"Причина отмены: {lessonInformation.CancelMessage}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие: {lessonInformation.NameLesson}\n" +
                          $"Дата занятия: {lessonInformation.StartDate} с преподавателем {lessonInformation.TeacherName} было отменено.\n" +
                          $"Причина отмены: {lessonInformation.CancelMessage}";

                    request.Subject = "Уведомление об отмене занятия";
                    request.Body = message;

                    await _emailService.PostAsync(request);
                    break;
                case NotificationSend.ComingLesson:
                    if (!settings.IsCancelLessonEmail)
                    {
                        return;
                    }

                    message = role == Roles.Teacher
                        ? $"Уважаемый(ая) {lessonInformation.TeacherName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"со студентом {lessonInformation.StudentName} скоро начнется. \nДата занятия: {lessonInformation.StartDate}"
                        : $"Уважаемый(ая) {lessonInformation.StudentName}, ваше занятие: {lessonInformation.NameLesson} " +
                          $"с преподавателем {lessonInformation.TeacherName} скоро начнется. \nДата занятия: {lessonInformation.StartDate}";

                    request.Subject = "Уведомление о скором занятии";
                    request.Body = message;

                    await _emailService.PostAsync(request);
                    break;
                default:
                    throw new Exception("Не удалось получить тип уведомления");
            }
        }

        /// <summary>
        /// Получить информацию о занятии
        /// </summary>
        private async Task<NotificationLessonInformationDto> GetLessonInformation(
            NotificationLessonDto notificationLessonDto)
        {
            switch (notificationLessonDto.LessonEnum)
            {
                case LessonEnum.Single:
                    return await GetSingleLessonInformation(notificationLessonDto);
                case LessonEnum.Group:
                    return await GetGroupLessonInformation(notificationLessonDto);
                    break;
                default:
                    throw new Exception("Не удалось найти тип урока");
            }
        }

        /// <summary>
        /// Получить информацию о индивидуальном занятии
        /// </summary>
        private async Task<NotificationLessonInformationDto> GetSingleLessonInformation(
            NotificationLessonDto notificationLessonDto)
        {
            var scheduler = _schedulerGenericRepository.GetAll();
                
            var singleLesson =
                await _singleLessonGenericRepository.GetAsync(Guid.Parse(notificationLessonDto.Id));
                    
            var schedulerSingleLesson = await scheduler
                .SingleOrDefaultAsync(x =>
                    x.SingleLessonId.HasValue && x.SingleLessonId == singleLesson.Id);

            var teacherTypeLesson = await _teacherTypeLessonsRepository.GetAsync(singleLesson.TeacherTypeLessonId);
            var typeLesson = await _typeLessonsGenericRepository.GetAsync(teacherTypeLesson.TypeLessonsId);

            if (schedulerSingleLesson == null)
            {
                throw new Exception("Не удалось найти занятие");
            }

            var teacher = schedulerSingleLesson.Teacher;
            var teacherName = $"{teacher.Surname} {teacher.Name} {teacher.MiddleName}";
            
            var typeLessonName = typeLesson.Name;

            var student = singleLesson.Students;
            var studentName = $"{student.Surname} {student.Name} {student.MiddleName}";

            var singleNotificationLesson = new NotificationLessonInformationDto
            {
                TeacherName = teacherName,
                StudentName = studentName,
                StartDate = schedulerSingleLesson.DateStart,
                CancelMessage = singleLesson.CancelMessage,
                NameLesson = typeLessonName
            };

            return singleNotificationLesson;
        }

        /// <summary>
        /// Получить информацию о групповом занятии
        /// </summary>
        private async Task<NotificationLessonInformationDto> GetGroupLessonInformation(
            NotificationLessonDto notificationLessonDto)
        {
            var scheduler = _schedulerGenericRepository.GetAll();
                
            var groupLesson =
                await _groupLessonGenericRepository.GetAsync(Guid.Parse(notificationLessonDto.Id));
                    
            var schedulerGroupLesson = await scheduler
                .SingleOrDefaultAsync(x =>
                    x.GroupLessonId.HasValue && x.GroupLessonId == groupLesson.Id);

            if (schedulerGroupLesson == null)
            {
                throw new Exception("Не удалось найти занятие");
            }

            var teacher = schedulerGroupLesson.Teacher;
            var teacherName = $"{teacher.Surname} {teacher.Name} {teacher.MiddleName}";

            var typeLesson = groupLesson.TeacherTypeLesson.TypeLessons;
            var typeLessonName = typeLesson.Name;

            var singleNotificationLesson = new NotificationLessonInformationDto
            {
                TeacherName = teacherName,
                StartDate = schedulerGroupLesson.DateStart,
                CancelMessage = groupLesson.CancelMessage,
                NameLesson = typeLessonName
            };

            return singleNotificationLesson;
        }
    }
}