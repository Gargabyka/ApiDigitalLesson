using ApiDigitalLesson.Identity.Models.Entity;
using ApiDigitalLesson.Identity.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace ApiDigitalLesson.Identity.Seeds
{
    /// <summary>
    /// Создание админа по умолчанию
    /// </summary>
    public static class DefaultUser
    {
        public static async Task CreateDefaultUser(UserManager<UserIdentity> userManager)
        {
            await CreateAdminAsync(userManager);
            await CreateTeacherAsync(userManager);
            await CreateStudentAsync(userManager);
            await CreateModeratorAsync(userManager);
        }
        
        private static async Task CreateAdminAsync(UserManager<UserIdentity> userManager)
        {
            var admin = new UserIdentity
            {
                UserName = "adminTest",
                Email = "testAdmin@mail.ru",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(admin, "123Password!");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }

        private static async Task CreateTeacherAsync(UserManager<UserIdentity> userManager)
        {
            var teacher = new UserIdentity
            {
                UserName = "teacherTest",
                Email = "testTeacher@mail.ru",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(teacher.Email);
            if (user == null)
            {
                await userManager.CreateAsync(teacher, "123Password!");
                await userManager.AddToRoleAsync(teacher, Roles.Teacher.ToString());
            }
        }
        
        private static async Task CreateStudentAsync(UserManager<UserIdentity> userManager)
        {
            var student = new UserIdentity
            {
                UserName = "studentTest",
                Email = "testStudent@mail.ru",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(student.Email);
            if (user == null)
            {
                await userManager.CreateAsync(student, "123Password!");
                await userManager.AddToRoleAsync(student, Roles.Student.ToString());
            }
        }
        
        private static async Task CreateModeratorAsync(UserManager<UserIdentity> userManager)
        {
            var moderator = new UserIdentity
            {
                UserName = "moderatorTest",
                Email = "testModerator@mail.ru",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var user = await userManager.FindByEmailAsync(moderator.Email);
            if (user == null)
            {
                await userManager.CreateAsync(moderator, "123Password!");
                await userManager.AddToRoleAsync(moderator, Roles.Student.ToString());
            }
        }
    }
}
