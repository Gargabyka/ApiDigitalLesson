using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto.Ofther;
using ApiDigitalLesson.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Сервис работы с сущностью <see cref="Cities"/>
    /// </summary>
    public class CitiesServices : ICitiesServices
    {
        private readonly IGenericRepository<Cities> _citiesGenericRepository;
        private readonly IDistributedCache _cache;
        private readonly ILogger<CitiesServices> _logger;
        
        private const string CitiesCacheKey = "CitiesCacheKey";

        public CitiesServices(
            IGenericRepository<Cities> citiesGenericRepository, 
            IDistributedCache cache, 
            ILogger<CitiesServices> logger)
        {
            _citiesGenericRepository = citiesGenericRepository;
            _cache = cache;
            _logger = logger;
        }

        /// <summary>
        /// Получить список городов
        /// </summary>
        public async Task<BaseResponse<List<EntityWithIdAndNameDto>>> GetCitiesAsync()
        {
            try
            {
                var citiesCache = await _cache.GetStringAsync(CitiesCacheKey);
                if (!string.IsNullOrEmpty(citiesCache))
                {
                    var citiesCacheResult =  JsonConvert.DeserializeObject<List<EntityWithIdAndNameDto>>(citiesCache);
                    if (citiesCacheResult != null)
                    {
                        return new BaseResponse<List<EntityWithIdAndNameDto>>(citiesCacheResult);
                    }
                }
                
                var cities = await _citiesGenericRepository.GetAll()
                    .Select(x => new EntityWithIdAndNameDto
                      {
                          Id = x.Id,
                          Name = x.Name
                      })
                    .ToListAsync();

                var cache = JsonConvert.SerializeObject(cities);
                await _cache.SetStringAsync(CitiesCacheKey, cache, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                });

                return new BaseResponse<List<EntityWithIdAndNameDto>>(cities);
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить список городов, {e.Message}.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить город по ID
        /// </summary>
        public async Task<string?> GetCitiesByIdAsync(string cityId)
        {
            try
            {
                var citiesCache = await _cache.GetStringAsync(CitiesCacheKey);
                if (!string.IsNullOrEmpty(citiesCache))
                {
                    var citiesCacheResult = JsonConvert.DeserializeObject<List<EntityWithIdAndNameDto>>(citiesCache);
                    var cityCache = citiesCacheResult?.SingleOrDefault(x => x.Id.ToString() == cityId);

                    if (cityCache != null)
                    {
                        return cityCache.Name;
                    }
                }

                var city = await _citiesGenericRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Id.ToString() == cityId);

                return city?.Name;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить город по Id, {e.Message}.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        
    }
}