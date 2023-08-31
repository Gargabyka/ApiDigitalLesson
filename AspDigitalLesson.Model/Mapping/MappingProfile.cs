using AspDigitalLesson.Model.Dto;
using AspDigitalLesson.Model.Entity;
using AutoMapper;

namespace AspDigitalLesson.Model.Mapping
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
        }
    }
}