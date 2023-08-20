using ApiDigitalLesson.Migration.Extension;
using AspDigitalLesson.Model.Entity;
using AspDigitalLesson.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDigitalLesson.Migration.Configuration
{
    public class TypeLessonConfiguration : IEntityTypeConfiguration<TypeLessons>
    {
        #region  Начальные данные

        private readonly Guid _ege = Guid.NewGuid();
        private readonly Guid _oge = Guid.NewGuid();
        private readonly Guid _technicalSciences = Guid.NewGuid();
        private readonly Guid _naturalSciences = Guid.NewGuid();
        private readonly Guid _humanitiesSciences = Guid.NewGuid();
        private readonly Guid _programming = Guid.NewGuid();
        private readonly Guid _schoolCurriculum = Guid.NewGuid();
        private readonly Guid _musical = Guid.NewGuid();
        private readonly Guid _art = Guid.NewGuid();
        
        private readonly Guid _14class = Guid.NewGuid();
        private readonly Guid _59class = Guid.NewGuid();
        private readonly Guid _911class = Guid.NewGuid();
        private readonly Guid _schoolLanguage = Guid.NewGuid();

        private readonly List<string> _egeName = new List<string>()
        {
            "Математика (базовый уровень)",
            "Математика (профильный уровень)",
            "Русский язык",
            "Литература",
            "Физика",
            "Химия",
            "История",
            "Обществознание",
            "Информатика",
            "Биология",
            "География",
            "Английский язык",
            "Немецкий язык",
            "Французский язык",
            "Китайский язык",
            "Испанский язык",
            "География"
        };
        
        private readonly List<string> _ogeName = new List<string>()
        {
            "Математика",
            "Русский язык",
            "Литература",
            "Физика",
            "Химия",
            "История",
            "Обществознание",
            "Информатика",
            "Биология",
            "География",
            "Английский язык",
            "Немецкий язык",
            "Французский язык",
            "Китайский язык",
            "Испанский язык",
            "География"
        };

        private readonly List<string> _schoolLanguageName = new List<string>()
        {
            "Абазинский язык",
            "Адыгейский язык",
            "Алтайский язык",
            "Башкирский язык",
            "Бурятский язык",
            "Дагестанский язык",
            "Ингушский язык",
            "Кабардино-черкесский язык",
            "Калмыцкий язык",
            "Карачаево-балкарский язык",
            "Коми язык",
            "Крымскотатарский язык",
            "Марийский язык",
            "Мокшанский язык",
            "Ногайский язык",
            "Осетинский язык",
            "Татарский язык",
            "Тувинский язык",
            "Удмуртский язык",
            "Хакасский язык",
            "Чеченский язык",
            "Чувашский язык",
            "Эрзянский язык",
            "Якутский язык",
        };

        private readonly List<string> _14ClassName = new List<string>()
        {
            "Русский язык",
            "Литературное чтение",
            "Математика",
            "Обществознание",
            "Окружающий мир",
            "ИЗО",
            "Музыка",
            "Технология",
            "Физическая культура",
            "Английский язык",
            "Немецкий язык",
            "Французский язык",
            "Испанский язык",
            "Китайский язык"
        };

        private readonly List<string> _59ClassName = new List<string>()
        {
            "Русский язык",
            "Литература",
            "История",
            "Обществознание",
            "География",
            "Алгебра",
            "Геометрия",
            "Информатика",
            "Основы духовно-нравственной культуры народов России",
            "Основы религиозных культур и светской этики",
            "Физика",
            "Биология",
            "Химия",
            "Изобразительное искусство",
            "Музыка",
            "Технология",
            "Физическая культура",
            "Основы безопасности жизнедеятельности",
            "Английский язык",
            "Немецкий язык",
            "Французский язык",
            "Испанский язык",
            "Китайский язык"
        };

        private readonly List<string> _911ClassName = new List<string>()
        {
            "Алгебра",
            "Геометрия",
            "Русский язык",
            "Литература",
            "Всеобщая история",
            "История России",
            "Обществознание",
            "Черчение",
            "Основы безопасности и жизнедеятельности",
            "Информатика",
            "География",
            "Физическая культура",
            "Биология",
            "Физика",
            "Химия",
            "Английский язык",
            "Немецкий язык",
            "Французский язык",
            "Испанский язык",
            "Китайский язык"
        };

        #endregion

        public void Configure(EntityTypeBuilder<TypeLessons> builder)
        {
            builder.ToTable(nameof(TypeLessons));

            builder
                .HasMany(j => j.SubCategories)
                .WithOne(j => j.Parent)
                .HasForeignKey(j => j.ParentId);

            var category = CreateCategoryTypeLessonsArray();
            var ege = FillCategory(_ege, _egeName);
            var oge = FillCategory(_oge, _ogeName);
            var subCategorySchoolProgram = CreateSubCategorySchoolProgram();

            var class14 = FillCategory(_14class, _14ClassName);
            var class59 = FillCategory(_59class, _59ClassName);
            var class911 = FillCategory(_911class, _911ClassName);
            var languageSchool = FillCategory(_schoolLanguage, _schoolLanguageName);

            builder.HasData(category);
            builder.HasData(ege);
            builder.HasData(oge);
            builder.HasData(subCategorySchoolProgram);
            builder.HasData(class14);
            builder.HasData(class59);
            builder.HasData(class911);
            builder.HasData(languageSchool);
        }

        private TypeLessons[] CreateCategoryTypeLessonsArray()
        {
            TypeLessons[] result =
            {
                new TypeLessons()
                {
                    Id = _ege,
                    Name = Category.Ege.DescriptionName(),
                    Category = Category.Ege.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _oge,
                    Name = Category.Oge.DescriptionName(),
                    Category = Category.Oge.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _technicalSciences,
                    Name = Category.TechnicalSciences.DescriptionName(),
                    Category = Category.TechnicalSciences.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _naturalSciences,
                    Name = Category.NaturalSciences.DescriptionName(),
                    Category = Category.NaturalSciences.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _humanitiesSciences,
                    Name = Category.HumanitiesSciences.DescriptionName(),
                    Category = Category.HumanitiesSciences.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _programming,
                    Name = Category.Programming.DescriptionName(),
                    Category = Category.Programming.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _schoolCurriculum,
                    Name = Category.SchoolCurriculum.DescriptionName(),
                    Category = Category.SchoolCurriculum.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _musical,
                    Name = Category.Musical.DescriptionName(),
                    Category = Category.Musical.EnumToInt()
                },
                new TypeLessons()
                {
                    Id = _art,
                    Name = Category.Art.DescriptionName(),
                    Category = Category.Art.EnumToInt()
                }
            };

            return result;
        }

        public TypeLessons[] CreateSubCategorySchoolProgram()
        {
            TypeLessons[] result =
            {
                new TypeLessons()
                {
                    Id = _14class,
                    Name = "1-4 класс",
                    ParentId = _schoolCurriculum
                },
                new TypeLessons()
                {
                    Id = _59class,
                    Name = "5-9 класс",
                    ParentId = _schoolCurriculum
                },
                new TypeLessons()
                {
                    Id = _911class,
                    Name = "9-11 класс",
                    ParentId = _schoolCurriculum
                },
                new TypeLessons()
                {
                    Id = _schoolLanguage,
                    Name = "Народные языки",
                    ParentId = _schoolCurriculum
                },
            };

            return result;
        }

        /// <summary>
        /// Заполнить данные категории
        /// </summary>
        private TypeLessons[] FillCategory(Guid id, List<string> nameList)
        {
            var typeLessons = new List<TypeLessons>();
            
            foreach (var name in nameList)
            {
                typeLessons.Add(new TypeLessons()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    ParentId = id
                });
            }

            var result = typeLessons.ToArray();

            return result;
        }
    }
}