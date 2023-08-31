using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Const;
using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис модераторов
    /// </summary>
    public class ModeratorService : IModeratorService
    {
        private readonly IGenericRepository<Moderator> _moderatorGenericRepository;
        private readonly IUserIdentityService _identityService;
        private readonly ILogger<ModeratorService> _logger;
        private readonly IMapper _mapper;

        public ModeratorService(
            IGenericRepository<Moderator> moderatorGenericRepository, 
            IUserIdentityService identityService,
            ILogger<ModeratorService> logger, 
            IMapper mapper)
        {
            _moderatorGenericRepository = moderatorGenericRepository;
            _logger = logger;
            _mapper = mapper;
            _identityService = identityService;
        }

        /// <summary>
        /// Получить список модераторов
        /// </summary>
        public async Task<BaseResponse<List<ModeratorDto>>> GetModeratorListAsync()
        {
            try
            {
                var moderators = await _moderatorGenericRepository.GetAll().Where(x=>!x.IsDelete).ToListAsync();
                var result = _mapper.Map<List<ModeratorDto>>(moderators);

                return new BaseResponse<List<ModeratorDto>>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список модераторов, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить модератора пользователя
        /// </summary>
        public async Task<BaseResponse<ModeratorDto>> GetModeratorUserAsync()
        {
            try
            {
                var currentUser = await _identityService.GetCurrentUserAsync();
                var moderator = await _moderatorGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.UserId.ToString() == currentUser.Id);

                var result = _mapper.Map<ModeratorDto>(moderator);

                return new BaseResponse<ModeratorDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить модератора пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить модератора по Id
        /// </summary>
        public async Task<BaseResponse<ModeratorDto>> GetModeratorAsync(string id)
        {
            try
            {
                var moderator = await _moderatorGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id.ToString() == id);

                var result = _mapper.Map<ModeratorDto>(moderator);

                return new BaseResponse<ModeratorDto>(result);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить модератора по id:{id}, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Создание модератора
        /// </summary>
        public async Task CreateModeratorAsync(ModeratorDto moderatorDto, string userId)
        {
            try
            {
                var user = await _identityService.GetUserForIdAsync(userId);
                var role = await _identityService.GetRoleUserAsync(user.Id);

                if (role != Roles.Moderator)
                {
                    throw new Exception("Роль пользователя не модератор");
                }

                if (_moderatorGenericRepository.GetAll().Any(x => x.UserId.ToString() == user.Id))
                {
                    throw new Exception("Модератор под таким пользователем уже существует");
                }

                var moderator = new Moderator()
                {
                    Id = Guid.NewGuid(),
                    Name = moderatorDto.Name,
                    Surname = moderatorDto.Surname,
                    MiddleName = moderatorDto.MiddleName,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    UserId = Guid.Parse(user.Id),
                    DateBirthday = moderatorDto.DateBirthday,
                };
                
                await _moderatorGenericRepository.AddAsync(moderator);
            }
            catch (Exception e)
            {
                var message = $"Не удалось создать модератора, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        

        /// <summary>
        /// Удалить модератора
        /// </summary>
        public async Task DeleteModeratorAsync(string id)
        {
            try
            {
                var moderator = await _moderatorGenericRepository.GetAsync(Guid.Parse(id));

                moderator.IsDelete = true;

                await _moderatorGenericRepository.UpdateAsync(moderator);
            }
            catch (Exception e)
            {
                var message = $"Не удалось удалить модератора, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}