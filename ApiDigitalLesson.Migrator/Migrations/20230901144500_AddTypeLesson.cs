using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migrator.Migrations
{
    public partial class AddTypeLesson : Migration
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
        
        private readonly Guid _14Class = Guid.NewGuid();
        private readonly Guid _59Class = Guid.NewGuid();
        private readonly Guid _911Class = Guid.NewGuid();
        private readonly Guid _schoolLanguage = Guid.NewGuid();

        private readonly List<string> _egeName = new()
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
        
        private readonly List<string> _ogeName = new()
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

        private readonly List<string> _schoolLanguageName = new()
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

        private readonly List<string> _14ClassName = new()
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

        private readonly List<string> _59ClassName = new()
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

        private readonly List<string> _911ClassName = new()
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
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson",
                column: "TeacherId",
                unique: true);
            
            CreateCategory(migrationBuilder);
            CreateSubCategorySchoolProgram(migrationBuilder);
            
            FillCategory(migrationBuilder,_ege, _egeName); 
            FillCategory(migrationBuilder, _oge, _ogeName);
            FillCategory(migrationBuilder, _14Class, _14ClassName);
            FillCategory(migrationBuilder, _59Class, _59ClassName);
            FillCategory(migrationBuilder, _911Class, _911ClassName);
            FillCategory(migrationBuilder, _schoolLanguage, _schoolLanguageName);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson",
                column: "TeacherId");
        }
        
        private void CreateCategory(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { _ege, "ЕГЭ" },
                    { _oge, "ОГЭ" },
                    { _technicalSciences, "Технические науки" },
                    { _naturalSciences, "Естественные науки" },
                    { _humanitiesSciences, "Гуманитарные науки" },
                    { _programming, "Программирование" },
                    { _schoolCurriculum, "Школьная программа" },
                    { _musical, "Музыка" },
                    { _art, "Искусство" }
                });
        }

        private void CreateSubCategorySchoolProgram(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { _14Class, "1-4 класс", _schoolCurriculum },
                    { _59Class, "5-9 класс", _schoolCurriculum },
                    { _911Class, "9-11 класс", _schoolCurriculum },
                    { _schoolLanguage, "Народные языки", _schoolCurriculum }
                });
        }
        
        private static void FillCategory(MigrationBuilder migrationBuilder, Guid id, List<string> nameList)
        {
            //TODO: Подумать как сделать заполнение категорий
            foreach (var name in nameList)
            {
                migrationBuilder.InsertData(
                    table: "TypeLessons",
                    columns: new[] {"Id", "Name", "ParentId"},
                    values: new object[] {Guid.NewGuid(), name, id});
            }
        }
    }
}
