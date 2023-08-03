using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Identity.Models.Entity;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис для работы с преподавателями
    /// </summary>
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly IGenericRepository<Students> _studentsRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonsRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonsRepository;
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonsRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherService> _logger;

        public TeacherService(
            UserManager<UserIdentity> userManager,
            ClaimsPrincipal userPrincipal, 
            IGenericRepository<Students> studentsRepository, 
            IGenericRepository<SingleLesson> singleLessonsRepository, 
            IGenericRepository<GroupLesson> groupLessonsRepository, 
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonsRepository, 
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<SingleLesson> singleLessonRepository, 
            IMapper mapper, 
            ILogger<TeacherService> logger) : base(userPrincipal, userManager)
        {
            _studentsRepository = studentsRepository;
            _singleLessonsRepository = singleLessonsRepository;
            _groupLessonsRepository = groupLessonsRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
            _teacherRepository = teacherRepository;
            _singleLessonRepository = singleLessonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /*public async Task<BaseResponse<TeacherDto>> GetTeacherAsync(string? id)
        {
            var user = await UserManager.FindByIdAsync(id) ?? CurrentUser;

            if (user == null)
            {
                throw new ApiException("Не удалось найти пользователя");
            }

            var teacher = await _teacherRepository.GetByUserIdAsync<Teacher>(user.Id);
        }*/
    }
}