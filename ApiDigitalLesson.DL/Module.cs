using ApiDigitalLesson.DL.Controllers.Context;
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

            

            #endregion
        }

    }
}
