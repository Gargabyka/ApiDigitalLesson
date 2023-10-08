using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Migrator.Context;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDigitalLesson.BL
{
    /// <summary>
    /// Класс регистрации зависимостей
    /// </summary>
    public static class Module
    {
        public static void AddModules(this IServiceCollection services)
        {
            AddContext(services);
            AddService(services);
        }

        /// <summary>
        /// Добавить контекст
        /// </summary>
        private static void AddContext(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
        }

        /// <summary>
        /// Добавить сервисы
        /// </summary>
        private static void AddService(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAboutTeacherService, AboutTeacherService>();
            services.AddScoped<ITypeLessonService, TypeLessonService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISchedulerService, SchedulerService>();
            services.AddScoped<ITeacherTypeLessonService, TeacherTypeLessonService>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();
            services.AddScoped<ISingleLessonService, SingleLessonService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IModeratorService, ModeratorService>();
            services.AddScoped<IViolatorsService, ViolatorsService>();
            services.AddScoped<ICitiesServices, CitiesServices>();
            services.AddScoped<ICleanerServices, CleanerServices>();
        }

    }
}
