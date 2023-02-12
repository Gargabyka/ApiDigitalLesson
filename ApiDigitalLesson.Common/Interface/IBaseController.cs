using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.Common.Interface
{
    /// <summary>
    /// Базовый интерфейс для контроллеров
    /// </summary>
    public interface IBaseController
    {
        /// <summary>
        /// Получить список
        /// </summary>
        [HttpGet]
        public Task<IActionResult> ListAsync();

        /// <summary>
        /// Получить данные
        /// </summary>
        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(int id);

        /// <summary>
        /// Создать данные
        /// </summary>
        [HttpPost]
        public Task<IActionResult> CreateAsync<T>(T entity);

        /// <summary>
        /// Обновить данные
        /// </summary>
        [HttpPut]
        public Task<IActionResult> UpdateAsync<T>(T entity);

        /// <summary>
        /// Удалить данные
        /// </summary>
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(int id);
    }
}
