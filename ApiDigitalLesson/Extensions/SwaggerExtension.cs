using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiDigitalLesson.Extensions
{
    /// <summary>
    /// Класс расширения для Swagger
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Добавление авторизации в Swagger
        /// </summary>
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiDigitalLesson", Version = "v1" });
                AddCustomBearerSwagger(c);
                AddCustomVkSwagger(c);
                AddSwaggerGoogleConfiguration(c);
            });
        }

        /// <summary>
        /// Настройка конфигурации Bearer
        /// </summary>
        /// <param name="options"></param>
        private static void AddCustomBearerSwagger(SwaggerGenOptions options)
        {
            var bearer = new OpenApiSecurityScheme
            {
                Description = @"JWT Аутентификация через Bearer
                Для ввода данных введите Bearer(пробел)(токен)",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            };
            
            options.AddSecurityDefinition("Bearer", bearer);

            var security = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            };

            options.AddSecurityRequirement(security);
        }

        /// <summary>
        /// Настройка конфигурации Vk
        /// </summary>
        private static void AddCustomVkSwagger(SwaggerGenOptions options)
        {
            var vk = new OpenApiSecurityScheme
            {
                 Name = "Authorization",
                 In = ParameterLocation.Header,
                 Type = SecuritySchemeType.OAuth2,
                 Flows = new OpenApiOAuthFlows
                 {
                     Implicit = new OpenApiOAuthFlow
                     {
                         AuthorizationUrl = new Uri("https://oauth.vk.com/authorize"),
                         Scopes = new Dictionary<string, string> {{"email", "email"}}
                     }
                 }
            };
            options.AddSecurityDefinition("Vkontakte", vk);
            var security = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Vkontakte"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            };
            options.AddSecurityRequirement(security);
            options.OperationFilter<AddResponseHeadersFilter>();
        }
        
        /// <summary>
        /// Конфигурация swagger под Google
        /// </summary>
        private static void AddSwaggerGoogleConfiguration(SwaggerGenOptions swaggerGenOptions) 
        {
    
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                        Scopes = new Dictionary<string, string> {{"email", "email"}, {"profile", "profile"}, {"openid", "openid"}}
                    }
                }
            };
        
            swaggerGenOptions.AddSecurityDefinition("Google", securityScheme) ;

            var securityRequirements = new OpenApiSecurityRequirement 
            {
                {
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Google" 
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                } 
            };
            
            swaggerGenOptions.AddSecurityRequirement(securityRequirements);
        }
    }
}
