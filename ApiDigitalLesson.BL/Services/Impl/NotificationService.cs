using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Services.Interface.SMTP;
using ApiDigitalLesson.Common.Services.Interface.Telegram;
using ApiDigitalLesson.Model.Dto.Notification;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Entity;
using ApiDigitalLesson.Model.Enums;
using ApiDigitalLesson.Model.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Roles = ApiDigitalLesson.Model.Const.Roles;

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
            _typeLessonsGenericRepository = typeLessonsGenericRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
        }

        /// <summary>
        /// Отправить уведомление
        /// </summary>
        public async Task SendNotification(NotificationLessonDto notificationLesson)
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
                            .Include(x=>x.SettingsStudent)
                            .SingleOrDefaultAsync(x=>x.UserId.ToString() == user.Id);
                        
                        if (student == null)
                        {
                            throw new Exception("Не удалось найти студента");
                        }

                        var selectStudent = new SelectNotificationDto
                        {
                            Email = student.Email,
                            TelegramId = student.TelegramId
                        };

                        var settingsStudent = new SettingsDto
                        {
                            IsNotificationTelegram = student.SettingsStudent.IsNotificationTelegram,
                            IsRequestForLessonTelegram = student.SettingsStudent.IsRequestForLessonTelegram,
                            IsAcceptForLessonTelegram = student.SettingsStudent.IsAcceptForLessonTelegram,
                            IsCancelLessonTelegram = student.SettingsStudent.IsCancelLessonTelegram,
                            IsLessonComingSoonTelegram = student.SettingsStudent.IsLessonComingSoonTelegram,
                            TimeBeforeLesson = student.SettingsStudent.TimeBeforeLesson,
                            IsNotificationEmail = student.SettingsStudent.IsNotificationEmail,
                            IsRequestForLessonEmail = student.SettingsStudent.IsRequestForLessonEmail,
                            IsAcceptForLessonEmail = student.SettingsStudent.IsAcceptForLessonEmail,
                            IsCancelLessonEmail = student.SettingsStudent.IsCancelLessonEmail,
                            IsLessonComingSoonEmail = student.SettingsStudent.IsLessonComingSoonEmail
                        };
                        
                        await SelectSendNotification(notificationLesson, settingsStudent, selectStudent, role);
                        break;
                    case Roles.Teacher:

                        var teacher = await teachers
                            .Include(x=>x.SettingsTeacher)
                            .SingleOrDefaultAsync(x => x.UserId.ToString() == user.Id);

                        if (teacher == null)
                        {
                            throw new Exception("Не удалось найти преподавателя");
                        }

                        var selectTeacher = new SelectNotificationDto
                        {
                            Email = teacher.Email,
                            TelegramId = teacher.TelegramId
                        };

                        var settingsTeacher = new SettingsDto
                        {
                            IsNotificationTelegram = teacher.SettingsTeacher.IsNotificationTelegram,
                            IsRequestForLessonTelegram = teacher.SettingsTeacher.IsRequestForLessonTelegram,
                            IsAcceptForLessonTelegram = teacher.SettingsTeacher.IsAcceptForLessonTelegram,
                            IsCancelLessonTelegram = teacher.SettingsTeacher.IsCancelLessonTelegram,
                            IsLessonComingSoonTelegram = teacher.SettingsTeacher.IsLessonComingSoonTelegram,
                            TimeBeforeLesson = teacher.SettingsTeacher.TimeBeforeLesson,
                            IsNotificationEmail = teacher.SettingsTeacher.IsNotificationEmail,
                            IsRequestForLessonEmail = teacher.SettingsTeacher.IsRequestForLessonEmail,
                            IsAcceptForLessonEmail = teacher.SettingsTeacher.IsAcceptForLessonEmail,
                            IsCancelLessonEmail = teacher.SettingsTeacher.IsCancelLessonEmail,
                            IsLessonComingSoonEmail = teacher.SettingsTeacher.IsLessonComingSoonEmail
                        };
                        
                        await SelectSendNotification(notificationLesson, settingsTeacher, selectTeacher, role);
                        break;
                    default:
                        throw new Exception("Не удалось найти роль пользователя");
                }
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при отправке уведомления, {e.Message}";
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
            string message;

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
            string message;

            var request = new EmailRequest
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
            return notificationLessonDto.LessonEnum switch
            {
                LessonEnum.Single => await GetSingleLessonInformation(notificationLessonDto),
                LessonEnum.Group => await GetGroupLessonInformation(notificationLessonDto),
                _ => throw new Exception("Не удалось найти тип урока")
            };
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