using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.DL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDigitalLesson.BL
{
    /// <summary>
    /// Класс регистрации зависимостей
    /// </summary>
    public static class Module
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
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
            services.AddTransient<ClaimsPrincipal>(
                s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IStudentsService, StudentService>();
            services.AddScoped<IAboutTeacherService, AboutTeacherService>();
        }

    }
}
