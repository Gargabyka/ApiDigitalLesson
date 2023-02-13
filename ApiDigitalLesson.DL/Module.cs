using System.Security.Claims;
using ApiDigitalLesson.DL.Controllers.Context;
using ApiDigitalLesson.DL.Controllers.Controller;
using ApiDigitalLesson.DL.Controllers.Services.Impl;
using ApiDigitalLesson.DL.Controllers.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDigitalLesson.DL
{
    public static class Module
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            #region Контекст
            services.AddDbContext<ApplicationContext>();
            #endregion

            #region Сервисы
            services.AddTransient<ClaimsPrincipal>(
                s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStudentsService, StudentService>();

            #endregion
        }

    }
}
