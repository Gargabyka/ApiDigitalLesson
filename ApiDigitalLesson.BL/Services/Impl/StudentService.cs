using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Entity;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Класс для работы со студентами
    /// </summary>
    public class StudentService : BaseService, IStudentsService
    {
        private readonly IGenericRepository<Students> _studentsRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonsRepository;
        private readonly IGenericRepository<GroupLesson> _groupLessonsRepository;
        private readonly IGenericRepository<GroupLessonStudents> _groupLessonsStudentsRepository;
        private readonly IGenericRepository<TeacherTypeLesson> _teacherTypeLessonsRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<SingleLesson> _singleLessonRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(UserManager<UserIdentity> userManager, 
            IGenericRepository<Students> studentsRepository,
            ClaimsPrincipal userPrincipal, 
            IGenericRepository<SingleLesson> singleLessonsRepository, 
            IGenericRepository<GroupLesson> groupLessonsRepository, 
            IGenericRepository<TeacherTypeLesson> teacherTypeLessonsRepository, 
            IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<SingleLesson> singleLessonRepository, 
            IMapper mapper, 
            ILogger<StudentService> logger, 
            IGenericRepository<GroupLessonStudents> groupLessonsStudentsRepository)
        : base(userPrincipal, userManager)
        {
            _studentsRepository = studentsRepository;
            _singleLessonsRepository = singleLessonsRepository;
            _groupLessonsRepository = groupLessonsRepository;
            _teacherTypeLessonsRepository = teacherTypeLessonsRepository;
            _teacherRepository = teacherRepository;
            _singleLessonRepository = singleLessonRepository;
            _mapper = mapper;
            _logger = logger;
            _groupLessonsStudentsRepository = groupLessonsStudentsRepository;
        }

        /// <summary>
        /// Получить студента по Id
        /// </summary>
        public async Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id студента");
                }

                var students = _studentsRepository.GetAll();

                var student = await students.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студента");
                }

                var result = _mapper.Map<StudentsDto>(student);
            
                return new BaseResponse<StudentsDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Не удалось получить студента по id: {id}, {e.InnerException}");
                throw new Exception($"Не удалось получить студента по id: {id}, {e.InnerException}");
            }
        }

        /// <summary>
        /// Создание студента по UserId
        /// </summary>
        public async Task<IActionResult> CreateStudentsAsync(StudentsDto student, string? id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id) ?? CurrentUser;

                if (user == null)
                {
                    throw new ApiException("Не удалось найти пользователя");
                }

                var newStudent = new Students()
                {
                    Id = Guid.NewGuid(),
                    Name = student.Name,
                    Surname = student.Surname,
                    MiddleName = student.MiddleName,
                    Phone = student.Phone,
                    Email = student.Email,
                    Telegram = student.Telegram,
                    Description = student.Description,
                    UserId = Guid.Parse(user.Id),
                    DateBirthday = student.DateBirthday
                };
            
                await _studentsRepository.AddAsync(newStudent);

                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogError($"Не удалось создать нового студента по id: {id}, {e.InnerException}");
                throw new Exception($"Не удалось создать нового студента по id: {id}, {e.InnerException}");
            }
        }

        /// <summary>
        /// Обновить данные студента
        /// </summary>
        public async Task<IActionResult> UpdateStudentsAsync(StudentsDto studentsDto, string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id студента");
                }

                var allStudents = _studentsRepository.GetAll();
                var student = await allStudents.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студена");
                }

                student.Phone = studentsDto.Phone;
                student.Email = studentsDto.Email;
                student.Telegram = studentsDto.Telegram;
                student.Description = studentsDto.Description;

                await _studentsRepository.UpdateAsync(student);

                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogError($"Не удалось обновить информацию о студенте по id: {id}, {e.InnerException}");
                throw new Exception($"Не удалось обновить информацию о студенте по id: {id}, {e.InnerException}");
            }
        }

        /// <summary>
        /// Получить всех преподавателей студента
        /// </summary>
        public async Task<BaseResponse<List<TeacherDto>>> GetListTeacherForStudentAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new ApiException("Не передан Id студента");
                }
                
                var typeLessonList = new List<TeacherTypeLesson>();

                var students = _studentsRepository.GetAll();
                var student = await students.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студента");
                }

                var singleLesson = await _singleLessonsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x => x.TeacherTypeLesson)
                    .ToListAsync();

                typeLessonList.AddRange(singleLesson);

                var groupLessonStudents = await _groupLessonsStudentsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x=> x.GroupId)
                    .ToListAsync();

                var groupLesson = await _groupLessonsRepository.GetAll()
                    .Where(x => groupLessonStudents.Contains(x.Id))
                    .Select(x => x.TeacherTypeLesson)
                    .ToListAsync();

                typeLessonList.AddRange(groupLesson);

                var teacher = typeLessonList
                    .Select(x => x.Teacher)
                    .Distinct()
                    .ToList();

                var result = _mapper.Map<List<TeacherDto>>(teacher);

                return new BaseResponse<List<TeacherDto>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Не удалось получить всех преподавателей студента, {e.InnerException}");
                throw new Exception($"Не удалось получить всех преподавателей студента, {e.InnerException}");
            }
        }
        
        /// <summary>
        /// Получить расписание студента
        /// </summary>
        public async Task<BaseResponse<List<SchedulerDto>>> GetScheduleStudentsAsync(string studentId)
        {
            try
            {
                var schedulers = new List<SchedulerDto>();
                var students = _studentsRepository.GetAll();
                var student = await students.SingleOrDefaultAsync(x => x.Id == Guid.Parse(studentId));

                if (student == null)
                {
                    throw new ApiException("Не удалось найти студента");
                }
                
                var singleLesson = await _singleLessonsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .ToListAsync();

                foreach (var lesson in singleLesson)
                {
                    var schedule = new SchedulerDto()
                    {
                        SingleLessonId = lesson.Id,
                        DateStart = lesson.DateStart,
                        DateEnd = lesson.DateEnd,
                        NameLesson = lesson.TeacherTypeLesson.TypeLessons.Name,
                        Description = lesson.TeacherTypeLesson.Description,
                        IsCancel = lesson.IsCancel,
                        IsFinish = lesson.IsFinish,
                        IsConfirmed = lesson.IsConfirmed
                    };
                    
                    schedulers.Add(schedule);
                }
                
                var groupLessonStudents = await _groupLessonsStudentsRepository.GetAll()
                    .Where(x => x.Students.Id == student.Id)
                    .Select(x=> x.GroupId)
                    .ToListAsync();

                var groupLesson = await _groupLessonsRepository.GetAll()
                    .Where(x => groupLessonStudents.Contains(x.Id))
                    .ToListAsync();
                
                foreach (var lesson in groupLesson)
                {
                    var schedule = new SchedulerDto()
                    {
                        GroupLessonId = lesson.Id,
                        DateStart = lesson.DateStart,
                        DateEnd = lesson.DateEnd,
                        NameLesson = lesson.TeacherTypeLesson.TypeLessons.Name,
                        Description = lesson.TeacherTypeLesson.Description,
                        IsCancel = lesson.IsCancel,
                        IsFinish = lesson.IsFinish,
                        IsConfirmed = lesson.IsConfirmed
                    };
                    
                    schedulers.Add(schedule);
                }

                return new BaseResponse<List<SchedulerDto>>(schedulers);

            }
            catch (Exception e)
            {
                _logger.LogError($"Не удалось получить расписание студента, {e.InnerException}");
                throw new Exception($"Не удалось получить расписание студента, {e.InnerException}");
            }
        }
    }
}
