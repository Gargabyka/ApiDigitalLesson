using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.AboutTeacher;
using ApiDigitalLesson.Model.Dto.Moderator;
using ApiDigitalLesson.Model.Dto.Settings;
using ApiDigitalLesson.Model.Dto.Teacher;
using ApiDigitalLesson.Model.Dto.TypeLesson;
using ApiDigitalLesson.Model.Dto.Violators;
using ApiDigitalLesson.Model.Entity;
using AutoMapper;

namespace ApiDigitalLesson.Model.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AboutTeacher, AboutTeacherDto>();
            CreateMap<Students, StudentsDto>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TypeLessons, TypeLessonDto>();
            CreateMap<Moderator, ModeratorDto>();
            CreateMap<Violators, ViolatorsDto>();
            CreateMap<SettingsStudent, SettingsStudentDto>();
            CreateMap<SettingsTeacher, SettingsTeacherDto>();
        }
    }
}