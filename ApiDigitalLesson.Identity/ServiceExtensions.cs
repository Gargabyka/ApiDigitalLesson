using System.Text;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Contexts;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Entity;
using ApiDigitalLesson.Identity.Services.Impl;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ApiDigitalLesson.Identity
{
    /// <summary>
    /// Сервис для добавление Identity
    /// </summary>
    public static class ServiceExtensions
    {
        public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAccountService, AccountService>();

            services.Configure<JwtSettings>(configuration.GetSection("JWTSettings"));

            services.AddDbContext<IdentityContext>();

            services.AddIdentity<UserIdentity, RoleIdentity>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider("MyApp", typeof(DataProtectorTokenProvider<UserIdentity>));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddCookie()
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       ValidIssuer = configuration["JWTSettings:Issuer"],
                       ValidAudience = configuration["JWTSettings:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                   };
                   o.Events = new JwtBearerEvents()
                   {
                       OnChallenge = context =>
                       {
                           context.HandleResponse();
                           context.Response.StatusCode = 401;
                           context.Response.ContentType = "application/json";
                           var result = JsonConvert.SerializeObject(new BaseResponse<string>("Вы не авторизованы"));
                           return context.Response.WriteAsync(result);
                       },
                       OnForbidden = context =>
                       {
                           context.Response.StatusCode = 403;
                           context.Response.ContentType = "application/json";
                           var result = JsonConvert.SerializeObject(new BaseResponse<string>("У вас нет доступа к данному ресурсу"));
                           return context.Response.WriteAsync(result);
                       },
                   };
               })
               .AddVkontakte("Vkontakte", options =>
               {
                   options.ClientId = configuration["VkAuthentication:ClientId"];
                   options.ClientSecret = configuration["VkAuthentication:ClientSecret"];
                   options.Scope.Add("email");
               })
               .AddGoogle("Google", options =>
               {
                   options.ClientId = configuration["GoogleAuthentication:ClientId"];
                   options.ClientSecret = configuration["GoogleAuthentication:ClientSecret"];
               });
        }
    }
}
