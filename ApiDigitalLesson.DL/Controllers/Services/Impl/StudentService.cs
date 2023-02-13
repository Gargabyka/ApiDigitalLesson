using System.Security.Claims;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.DL.Controllers.Context;
using ApiDigitalLesson.DL.Controllers.Services.Interface;
using ApiDigitalLesson.DL.Model.Dto;
using ApiDigitalLesson.DL.Model.Entity;
using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiDigitalLesson.DL.Controllers.Services.Impl
{
    /// <summary>
    /// Класс для работы со студентами
    /// </summary>
    public class StudentService : BaseService, IStudentsService
    {
        private readonly IGenericRepository<Students> _studentsRepository;

        public StudentService(UserManager<UserIdentity> userManager, ApplicationContext applicationContext, IGenericRepository<Students> studentsRepository, ClaimsPrincipal userPrincipal)
        : base(userPrincipal, userManager)
        {
            _studentsRepository = studentsRepository;
        }

        /// <summary>
        /// Получить студента по Id
        /// </summary>
        public async Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id) ?? CurrentUser;
            var students = _studentsRepository.GetAll();

            var student = await students.SingleOrDefaultAsync(x => x.UserId == Guid.Parse(user.Id));

            if (student == null)
            {
                throw new ApiException("Не удалось найти студента");
            }

            var result = new StudentsDto()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                MiddleName = student.MiddleName,
                Phone = student.Phone,
                Email = student.Email,
                Telegram = student.Telegram,
                Discription = student.Discription,
                UserId = student.UserId,
            };

            return new BaseResponse<StudentsDto>(result);
        }

        /// <summary>
        /// Создание студента
        /// </summary>
        public async Task<BaseResponse<string>> CreateStudentsAsync(StudentsDto student, string id)
        {
            var user = await _userManager.FindByIdAsync(id) ?? CurrentUser;

            var newStudent = new Students()
            {
                Id = Guid.NewGuid(),
                Name = student.Name,
                Surname = student.Surname,
                MiddleName = student.MiddleName,
                Phone = student.Phone,
                Email = student.Email,
                Telegram = student.Telegram,
                Discription = student.Discription,
                UserId = Guid.Parse(user.Id)
            };
            
            _studentsRepository.AddAsync(newStudent);

            return new BaseResponse<string>(newStudent.Id.ToString());

        }
    }
}
