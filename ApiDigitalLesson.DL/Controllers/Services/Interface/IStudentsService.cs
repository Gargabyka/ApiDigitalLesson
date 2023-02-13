using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.DL.Model.Dto;

namespace ApiDigitalLesson.DL.Controllers.Services.Interface
{
    /// <summary>
    /// Интерфейс для работы со студентом
    /// </summary>
    public interface IStudentsService
    {
        /// <summary>
        /// Получение конкретного студента
        /// </summary>
        Task<BaseResponse<StudentsDto>> GetStudentsAsync(string id);

        /// <summary>
        /// Создать студента
        /// </summary>
        Task<BaseResponse<string>> CreateStudentsAsync(StudentsDto students, string id);
    }
}
