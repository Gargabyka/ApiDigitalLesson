using ApiDigitalLesson.Identity.Models;
using ApiDigitalLesson.Identity.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace ApiDigitalLesson.Identity.Seeds
{
    /// <summary>
    /// Создание админа по умолчанию
    /// </summary>
    public static class DefaultAdmin
    {
        public static async Task SeedAsync(UserManager<UserIdentity> userManager)
        {
            var defaultUser = new UserIdentity
            {
                UserName = "adminTest",
                Email = "test@mail.ru",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Password!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
            }
        }
    }
}
