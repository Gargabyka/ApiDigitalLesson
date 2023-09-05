using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto.Violators;
using ApiDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис нарушений
    /// </summary>
    public class ViolatorsService : IViolatorsService
    {
        private readonly IGenericRepository<Violators> _violatorsGenericRepository;
        private readonly IGenericRepository<Students> _studentsGenericRepository;
        private readonly IGenericRepository<Teacher> _teacherGenericRepository;
        private readonly IUserIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly ILogger<ViolatorsService> _logger;

        public ViolatorsService(
            IGenericRepository<Violators> violatorsGenericRepository, 
            IGenericRepository<Students> studentsGenericRepository,
            IGenericRepository<Teacher> teacherGenericRepository,
            IUserIdentityService identityService,
            ILogger<ViolatorsService> logger,
            IMapper mapper)
        {
            _violatorsGenericRepository = violatorsGenericRepository;
            _studentsGenericRepository = studentsGenericRepository;
            _teacherGenericRepository = teacherGenericRepository;
            _identityService = identityService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Получить список нарушений
        /// </summary>
        public async Task<BaseResponse<List<ViolatorsDto>>> GetViolatorsListAsync()
        {
            try
            {
                var violators = await _violatorsGenericRepository
                    .GetAll()
                    .OrderBy(x=> x.DateCreatedViolator)
                    .ToListAsync();

                var result = _mapper.Map<List<ViolatorsDto>>(violators);

                return new BaseResponse<List<ViolatorsDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список нарушений, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание жалобы 
        /// </summary>
        public async Task<Guid> CreateViolatorAsync(ViolatorsDto violatorsDto)
        {
            try
            {
                var currentUser = await _identityService.GetCurrentUserAsync();
                var createdUser = await _identityService.GetUserForIdAsync(violatorsDto.UserId);

                if (currentUser.Id != createdUser.Id)
                {
                    throw new Exception("Нельзя написать жалобу от другого пользователя");
                }

                var teacher = await _teacherGenericRepository
                    .GetAll()
                    .SingleOrDefaultAsync(x => x.Id.ToString() == violatorsDto.TeacherId);

                var student = await _studentsGenericRepository
                    .GetAll()
                    .SingleOrDefaultAsync(x => x.Id.ToString() == violatorsDto.StudentId);

                if (currentUser.Id == teacher?.UserId.ToString() || currentUser.Id == student?.UserId.ToString())
                {
                    throw new Exception("Нельзя написать жалобу от самого себя");
                }

                if (violatorsDto.Comment.IsNull())
                {
                    throw new Exception("Комментарий нарушения не может быть пустым");
                }

                if (teacher == null && student == null)
                {
                    throw new Exception("Не объявлен нарушитель");
                }

                var violator = new Violators
                {
                    Id = Guid.NewGuid(),
                    Comment = violatorsDto.Comment,
                    DateCreatedViolator = DateTime.UtcNow,
                    StudentId = student?.Id,
                    TeacherId = teacher?.Id,
                    UserId = Guid.Parse(createdUser.Id)
                };

                var result = await _violatorsGenericRepository.AddAsync(violator);
                return result;
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать жалобу пользователю, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Бан нарушителя
        /// </summary>
        public async Task BannedViolatorsAsync(string id, DateTime dateBan)
        {
            try
            {
                var violators = await _violatorsGenericRepository.GetAsync(Guid.Parse(id));

                if (dateBan < DateTime.UtcNow)
                {
                    throw new Exception("Дата бана не может быть меньше текущей даты");
                }
                
                violators.IsBanned = true;
                violators.DateBan = dateBan;

                await _violatorsGenericRepository.UpdateAsync(violators);
            }
            catch (Exception e)
            {
                var message = $"Не удалось забанить пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Отмена жалобы пользователя
        /// </summary>
        public async Task CancelViolatorsAsync(string id)
        {
            try
            {
                var violators = await _violatorsGenericRepository.GetAsync(Guid.Parse(id));

                violators.IsCancel = true;

                await _violatorsGenericRepository.UpdateAsync(violators);
            }
            catch (Exception e)
            {
                var message = $"Не удалось отменить жалобу пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Разбанить нарушителя
        /// </summary>
        public async Task UnbanViolatorsAsync(string id)
        {
            try
            {
                var violators = await _violatorsGenericRepository.GetAsync(Guid.Parse(id));

                violators.IsBanned = false;
                violators.DateBan = null;

                await _violatorsGenericRepository.UpdateAsync(violators);
            }
            catch (Exception e)
            {
                var message = $"Не удалось разбанить пользователя. {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Проверка пользователя на бан
        /// </summary>
        public async Task<bool> IsBannedAsync(string? teacherId, string? studentId)
        {
            try
            {
                var violators = await _violatorsGenericRepository.GetAll().ToListAsync();
                
                if (teacherId.IsNull() && studentId.IsNull())
                {
                    throw new Exception("Не удалось проверить бан пользователя. Все параметры пусты");
                }
                
                if (teacherId != null && !teacherId.IsNull())
                {
                    var teacherIsBan = violators
                        .Any(x => x.TeacherId.ToString() == teacherId && x.IsBanned && x.DateBan > DateTime.UtcNow);

                    return teacherIsBan;
                }
                
                if (studentId != null && !studentId.IsNull())
                {
                    var studentIsBan = violators
                        .Any(x => x.StudentId.ToString() == studentId && x.IsBanned && x.DateBan > DateTime.UtcNow);

                    return studentIsBan;
                }

                return false;
            }
            catch (Exception e)
            {
                var message = $"Не удалось проверить бан пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        
        /// <summary>
        /// Проверка текущего пользователя на бан
        /// </summary>
        public async Task<bool> IsBannedCurrentUserAsync()
        {
            try
            {
                var user = await _identityService.GetCurrentUserAsync();
                
                var teacher = await _teacherGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x=>x.UserId.ToString() == user.Id);
                
                var student = await _studentsGenericRepository.GetAll()
                   .SingleOrDefaultAsync(x=>x.UserId.ToString() == user.Id);

                if (student == null && teacher == null)
                {
                    throw new Exception("Не объявлен нарушитель");
                }
                
                var isBanned = await _violatorsGenericRepository.GetAll()
                    .Where(x=> teacher != null && x.TeacherId == teacher.Id)
                    .Where(x=> student != null && x.StudentId == student.Id)
                    .AnyAsync(x=>x.IsBanned && x.DateBan > DateTime.UtcNow);
                
                return isBanned;
            }
            catch (Exception e)
            {
                var message = $"Не удалось проверить бан пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}