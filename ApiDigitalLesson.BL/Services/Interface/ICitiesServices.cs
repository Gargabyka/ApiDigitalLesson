using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto.Ofther;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса <see cref="CitiesServices"/>
    /// </summary>
    public interface ICitiesServices
    {
        /// <summary>
        /// Получить список городов
        /// </summary>
        Task<BaseResponse<List<EntityWithIdAndNameDto>>> GetCitiesAsync();

        /// <summary>
        /// Получить город по ID
        /// </summary>
        Task<string?> GetCitiesByIdAsync(string cityId);
    }
}