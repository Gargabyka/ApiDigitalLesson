using ApiDigitalLesson.Identity.Models.Entity;
using ApiDigitalLesson.Identity.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace ApiDigitalLesson.Identity.Seeds
{
    /// <summary>
    /// Создание ролей по умолчанию
    /// </summary>
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<RoleIdentity> roleManager)
        {
            if (!roleManager.Roles.Any(x=>x.Name == Roles.Admin.ToString()))
            {
                await roleManager.CreateAsync(new RoleIdentity()
                {
                    Name = Roles.Admin.ToString()
                });
            }
            if (!roleManager.Roles.Any(x => x.Name == Roles.Teacher.ToString()))
            {
                await roleManager.CreateAsync(new RoleIdentity()
                {
                    Name = Roles.Teacher.ToString()
                });
            }
            if (!roleManager.Roles.Any(x => x.Name == Roles.Student.ToString()))
            {
                await roleManager.CreateAsync(new RoleIdentity()
                {
                    Name = Roles.Student.ToString()
                });
            }

            if (!roleManager.Roles.Any(x => x.Name == Roles.Moderator.ToString()))
            {
                await roleManager.CreateAsync(new RoleIdentity()
                {
                    Name = Roles.Moderator.ToString()
                });
            }
        }
    }
}
