using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migration.Migrations
{
    public partial class Initial : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAllowCreateLesson = table.Column<bool>(type: "boolean", nullable: false),
                    IsNotificationTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequestForLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptForLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsLessonComingSoonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    TimeBeforeLesson = table.Column<int>(type: "integer", nullable: false),
                    IsNotificationEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequestForLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptForLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsLessonComingSoonEmail = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingsTeacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeCancelLesson = table.Column<int>(type: "integer", nullable: false),
                    TimeCreateLesson = table.Column<int>(type: "integer", nullable: false),
                    IsAllowCreateLesson = table.Column<bool>(type: "boolean", nullable: false),
                    IsNotificationTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequestForLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptForLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelLessonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    IsLessonComingSoonTelegram = table.Column<bool>(type: "boolean", nullable: false),
                    TimeBeforeLesson = table.Column<int>(type: "integer", nullable: false),
                    IsNotificationEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequestForLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsAcceptForLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancelLessonEmail = table.Column<bool>(type: "boolean", nullable: false),
                    IsLessonComingSoonEmail = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsTeacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: true),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeLessons_TypeLessons_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TypeLessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SettingsStudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_SettingsStudent_SettingsStudentId",
                        column: x => x.SettingsStudentId,
                        principalTable: "SettingsStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    SettingsTeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_SettingsTeacher_SettingsTeacherId",
                        column: x => x.SettingsTeacherId,
                        principalTable: "SettingsTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutTeacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTypeLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeLessonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    IsOffline = table.Column<bool>(type: "boolean", nullable: false),
                    IsGroup = table.Column<bool>(type: "boolean", nullable: false),
                    IsSingle = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTypeLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTypeLesson_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherTypeLesson_TypeLessons_TypeLessonsId",
                        column: x => x.TypeLessonsId,
                        principalTable: "TypeLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Violators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreatedViolator = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsBanned = table.Column<bool>(type: "boolean", nullable: false),
                    IsCancel = table.Column<bool>(type: "boolean", nullable: false),
                    DateBan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Violators_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Violators_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: false),
                    MaxQuantityStudents = table.Column<int>(type: "integer", nullable: false),
                    TeacherTypeLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCancel = table.Column<bool>(type: "boolean", nullable: false),
                    CancelMessage = table.Column<string>(type: "text", nullable: true),
                    IsFinish = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmedForTeacher = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmedForStudent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLesson_TeacherTypeLesson_TeacherTypeLessonId",
                        column: x => x.TeacherTypeLessonId,
                        principalTable: "TeacherTypeLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherTypeLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCancel = table.Column<bool>(type: "boolean", nullable: false),
                    CancelMessage = table.Column<string>(type: "text", nullable: true),
                    IsFinish = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmedForTeacher = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmedForStudent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleLesson_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleLesson_TeacherTypeLesson_TeacherTypeLessonId",
                        column: x => x.TeacherTypeLessonId,
                        principalTable: "TeacherTypeLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupLessonStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLessonStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLessonStudents_GroupLesson_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupLesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLessonStudents_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedulers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    SingleLessonId = table.Column<Guid>(type: "uuid", nullable: true),
                    GroupLessonId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsWeekend = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulers_GroupLesson_GroupLessonId",
                        column: x => x.GroupLessonId,
                        principalTable: "GroupLesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedulers_SingleLesson_SingleLessonId",
                        column: x => x.SingleLessonId,
                        principalTable: "SingleLesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedulers_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("17017be0-5efb-46e7-824d-ebb0beeb55f6"), 8, null, "Искусство", null },
                    { new Guid("28550ab6-d634-4713-8332-ec614736750c"), 0, null, "ЕГЭ", null },
                    { new Guid("32c656d2-645b-4a81-ac8c-0921d9f54f47"), 6, null, "Школьная программа", null },
                    { new Guid("6f9369db-2e71-46cc-96b0-2005578c06de"), 2, null, "Технические науки", null },
                    { new Guid("7f3e6e40-6602-4fd2-8295-80bccf652e2a"), 4, null, "Гуманитарные науки", null },
                    { new Guid("8eb6f981-9b28-4106-ae74-e740c290d735"), 3, null, "Естественные науки", null },
                    { new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66"), 1, null, "ОГЭ", null },
                    { new Guid("b0da7df0-615b-47cd-a452-e06f8b421870"), 5, null, "Программирование", null },
                    { new Guid("ca79d740-62e6-4027-8f08-c5fecc21af23"), 7, null, "Музыка", null }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0526434a-dd72-4ea0-a8e3-a0c3767b0974"), null, null, "Китайский язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("14dfc8b4-4c3d-439b-b623-272e3eaddf35"), null, null, "Литература", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("1a8fb7c9-6170-4f79-9930-9c70624c0901"), null, null, "Химия", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34"), null, null, "Народные языки", new Guid("32c656d2-645b-4a81-ac8c-0921d9f54f47") },
                    { new Guid("2f52d145-6893-424d-b18e-53e2ec668ca7"), null, null, "Физика", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("331482f0-0ada-4bc6-bac6-f91e8e18bc9c"), null, null, "Французский язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("336ba2a2-c56d-4bb8-acf1-c428d843ed7e"), null, null, "Обществознание", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("33f906a8-e2d1-4dba-94da-ab9905262282"), null, null, "Математика (базовый уровень)", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("3542baad-dab4-45c9-a8d9-8444f318acf0"), null, null, "История", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34"), null, null, "9-11 класс", new Guid("32c656d2-645b-4a81-ac8c-0921d9f54f47") },
                    { new Guid("39fd1fcb-474e-47b6-8036-51bd8f31ee43"), null, null, "История", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("3edf22e9-b3a8-42f7-842c-09211c5c29a9"), null, null, "Биология", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("4711ea4f-3a2b-47fe-ad2c-8654dfec817d"), null, null, "География", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("50d180cd-ffa0-488a-b7ae-fddde50fdde7"), null, null, "Французский язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("55a2e125-61ea-4e97-9616-7bb8362affa7"), null, null, "География", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("5877ed5b-f3d9-411b-a3e7-df62b5eeae55"), null, null, "Математика", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e"), null, null, "1-4 класс", new Guid("32c656d2-645b-4a81-ac8c-0921d9f54f47") },
                    { new Guid("6bc045b7-be4d-4710-8f57-92cbf8eaed04"), null, null, "География", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("70c39bf4-86e7-4cf3-b38a-653327eb8817"), null, null, "Немецкий язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("82aa4329-4e9f-4f88-851c-03daa20eb3c4"), null, null, "Русский язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("85508c8f-229f-4b6e-b14d-486426387fea"), null, null, "Английский язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("8adc9a3b-6d47-426b-b4ed-cf8771d6aae1"), null, null, "Испанский язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("8c23815a-2678-4b99-a518-d86d8ee5d409"), null, null, "Китайский язык", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("8c3750f7-7018-46ad-88ec-b9620b2102eb"), null, null, "Английский язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("977c39a4-5960-4f6a-8c29-bccc5487bf7c"), null, null, "Математика (профильный уровень)", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("d00ccd2d-007a-49d3-8af9-766c98ff48e1"), null, null, "Испанский язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("d07d91a0-d3f9-4479-b9c2-af1480ce143f"), null, null, "Обществознание", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("d1b56a1a-1128-4310-b6a7-083d73007942"), null, null, "Химия", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("d8ba5948-ebdb-472b-acd5-17c8c232b332"), null, null, "Физика", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("de4a4ce1-0711-4ea9-9894-c5436d815f7b"), null, null, "Биология", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("def05219-8541-4d40-bd3d-e68e065838c2"), null, null, "Информатика", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd"), null, null, "5-9 класс", new Guid("32c656d2-645b-4a81-ac8c-0921d9f54f47") },
                    { new Guid("ea0e583b-8f30-4721-8f24-4ccd4b72aa73"), null, null, "География", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("f48f105e-4998-4309-8aa2-f27e9c88d8c9"), null, null, "Информатика", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("f76b10c1-4d1c-4080-9abb-0b439e815f3c"), null, null, "Литература", new Guid("a5e9dbe9-7159-41be-ac7e-a061d6081c66") },
                    { new Guid("fbe62f85-75df-4b01-8568-219a72c1df34"), null, null, "Немецкий язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") },
                    { new Guid("fd49d3c5-5a69-4268-b1d5-f93c634abb16"), null, null, "Русский язык", new Guid("28550ab6-d634-4713-8332-ec614736750c") }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("04999326-f2a5-4887-a5ce-c3da624bd86e"), null, null, "Абазинский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("056a67b9-e7da-4374-9d99-f2be2689d458"), null, null, "Русский язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("0587f108-3c44-497b-9d11-bf2932b8f15b"), null, null, "Тувинский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("0ae5053f-d330-4f9d-9f5f-064e5756fec9"), null, null, "Химия", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("0e5c1570-8b12-4ade-94ac-bd64853618ab"), null, null, "История", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("1595ec49-a4e0-4439-9791-5ba955580f97"), null, null, "Технология", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("18b9c17e-5eb5-42d2-a2c7-23364ddc748e"), null, null, "Чеченский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("21c72d51-b3cc-41cb-84aa-f6a02b77fdf9"), null, null, "Черчение", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("289328f8-1739-436e-ad8f-706f08d34c2a"), null, null, "Литературное чтение", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("29a7f887-6ad9-41e9-ba2a-68b2316a1f76"), null, null, "Адыгейский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("2b507fec-af5f-460f-b668-6c86bb6287a4"), null, null, "Обществознание", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("2d55a722-9eb7-47b1-8e0f-95dd2c41331c"), null, null, "Испанский язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("33210137-05ea-480b-99a3-0c0ac3da9e93"), null, null, "География", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("35933df8-cd79-4ee2-a80a-ab6f6c26d5ee"), null, null, "Испанский язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("36f7f170-bae5-46b5-98a6-3e7334d3fc9f"), null, null, "Удмуртский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("383edfc2-eafb-4514-bf02-c2cfd5c2f56f"), null, null, "Французский язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("3dec110c-8a59-41e6-886b-eb05531d483a"), null, null, "Татарский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("42b47fb6-95fe-4ff9-8a28-9a026d4995f0"), null, null, "Биология", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("4359a675-d39a-4b4a-98b4-ec143995c7ae"), null, null, "ИЗО", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("4689d1c8-1cea-4c16-8537-d5f11edf2fd7"), null, null, "Музыка", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("4999b26d-3190-4795-a964-5ece1b3c9db5"), null, null, "Бурятский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("4ec94492-8b67-490b-b268-d2d5a20ad81b"), null, null, "Русский язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("511fa85c-6eef-4509-b3b8-195533b1f9c6"), null, null, "Немецкий язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("51b2224c-0d3b-4be0-974c-5070796cc967"), null, null, "Эрзянский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("51ca82d9-0bb2-4c49-a76f-801d44895f18"), null, null, "Русский язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("5290f86e-77c8-463a-b769-ec3140288043"), null, null, "Ингушский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("57440685-d87b-4e97-9aff-a05c67ea2e24"), null, null, "Английский язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("61bd2da4-43f6-4511-94b5-45f6f55c9a72"), null, null, "Французский язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("6539a209-f255-4f52-8c3a-16a100555856"), null, null, "Литература", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("68ee1f22-e87d-4c3b-aaae-ccab12a5b1ca"), null, null, "Английский язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("6c3a097a-4ec8-4e94-b84a-f296bdcc4061"), null, null, "География", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("6da8d0c1-bb4c-4935-8c7b-afefaddb3334"), null, null, "Ногайский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("6f01c2c6-08f2-467d-8eb5-420da0fc5814"), null, null, "Химия", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("6f0c7af2-8281-45e9-8f2f-c6e4258fa307"), null, null, "Осетинский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("6f56d5c7-e410-40a7-b46d-45f6032e287b"), null, null, "Основы духовно-нравственной культуры народов России", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("6fce4f92-2115-4b53-9d82-2532a68dcd17"), null, null, "Физика", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("75aee469-8a00-4f8b-b8a1-6d5a6e00cdd2"), null, null, "Алтайский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("795fa263-e7b1-48f5-b3b4-d7d92f358357"), null, null, "Алгебра", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("798c4af4-e750-40cd-806f-4328e3aa5b90"), null, null, "Кабардино-черкесский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("7c876f2f-fb72-4e56-bd4c-2b0fc7b4508e"), null, null, "Физическая культура", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("810a6d1b-0e5d-418e-a872-cd2b500b5633"), null, null, "Чувашский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("83d3474a-8429-42e2-9600-a1bdc71cc24f"), null, null, "Крымскотатарский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("85ea643c-1242-434b-a5a5-5b8975bbfe20"), null, null, "Французский язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("86eb1a35-b2ff-4aa0-8aae-cb6722ab48cc"), null, null, "Английский язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("870986a3-3492-483b-8fb1-f85902f390ff"), null, null, "Марийский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("889d5a7d-24f6-403c-864c-1223e1da4bd8"), null, null, "Окружающий мир", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("8ae86239-8173-4f66-a6d8-3491ebd56f56"), null, null, "Алгебра", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("8d7c2f7e-468a-42d0-a900-85bf0a137dbd"), null, null, "Всеобщая история", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("91f058a2-8589-48bf-887b-598e4f5bf413"), null, null, "Китайский язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("9288f1a3-fb0c-440f-8a4f-4ee3fd0ecc3f"), null, null, "Основы безопасности жизнедеятельности", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("97bdc359-6b82-4dfe-b00b-5684a8281a7b"), null, null, "Немецкий язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("9978f598-cd6b-489a-911f-67abf3a987c1"), null, null, "Башкирский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("99bcb1f4-9e0a-4fbf-9679-9049e0483adb"), null, null, "Геометрия", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("9a947ff7-1895-478f-98e6-bdcaebec4140"), null, null, "Китайский язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("a1a19881-d076-4ee3-bd55-371bda6be8ba"), null, null, "Коми язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("a3c29d10-3647-402f-a937-45255ea5a7fe"), null, null, "Дагестанский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("abe076c6-818f-4504-add5-339ff357727a"), null, null, "Биология", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("acb3ca64-59a8-45af-875c-aa91dae1ee34"), null, null, "Технология", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("b1301ded-97de-47ef-8b34-8259aed60463"), null, null, "Мокшанский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("ba57e2c5-6084-4778-8816-73785830c4cc"), null, null, "Информатика", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("bc65c1a1-1d97-444b-b286-d935d1e8545f"), null, null, "Карачаево-балкарский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("bf6831f7-80f1-47f8-ae0f-e06eaac841a7"), null, null, "Геометрия", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("c27411d2-e813-4500-bf29-f3e6349c5bc2"), null, null, "Испанский язык", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("c7c5e77f-1ff3-49ac-b113-0a20aaa0cac7"), null, null, "Основы безопасности и жизнедеятельности", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("ca33d986-662c-4301-8c27-a7cf9d75b2ab"), null, null, "Музыка", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("d7b7bd52-254e-42ce-95a3-82eef71c5884"), null, null, "Математика", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("d7ca591b-1edd-4e76-97ed-ae3cef1c4d5f"), null, null, "Физика", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("d7def495-e8db-4cfd-9861-dfa19899f1d2"), null, null, "Литература", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("d8084754-1165-427d-82b4-901ca401f114"), null, null, "Китайский язык", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("db611e48-d033-4015-905b-b6242394e293"), null, null, "Хакасский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("dea3e0de-b6d9-401f-8beb-c9f21c8d11b5"), null, null, "Изобразительное искусство", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("e0e8af28-3bcd-4448-b5f3-89536f3b5105"), null, null, "Калмыцкий язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("e3f3f156-fbb1-4efd-a148-12b8a6c030a8"), null, null, "Физическая культура", new Guid("590c5f85-d766-4f8e-bb20-c33d45626f7e") },
                    { new Guid("e472eeba-cee2-4de6-be57-eb6a2a75c6f6"), null, null, "Физическая культура", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("f1bbcedf-60ff-4482-bf53-f50ad1dedd85"), null, null, "Якутский язык", new Guid("200214e0-5ddb-471d-9eb7-941d7b549b34") },
                    { new Guid("f4492461-2c46-46ac-b0cd-dc6890b1bcb0"), null, null, "История России", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("f5e934c4-3186-4fe7-8fc1-1f1d2eb91377"), null, null, "Обществознание", new Guid("381fb160-244f-41b4-829e-4cce9e0ecb34") },
                    { new Guid("f95144ed-28fa-4f6f-bdf6-7292b0a5251d"), null, null, "Обществознание", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("fcc2ef09-0a1b-45cb-bd1e-c63448eb7b8f"), null, null, "Информатика", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("fe17fe8f-87a8-4d64-af77-5952f4002b14"), null, null, "Основы религиозных культур и светской этики", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") },
                    { new Guid("fffc260d-cfdc-47c9-baf4-843f153b7a1b"), null, null, "Немецкий язык", new Guid("e293c9db-1204-4ca3-a7c9-54f048ecfbbd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutTeacher_TeacherId",
                table: "AboutTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLesson_TeacherTypeLessonId",
                table: "GroupLesson",
                column: "TeacherTypeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLessonStudents_GroupId",
                table: "GroupLessonStudents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLessonStudents_StudentsId",
                table: "GroupLessonStudents",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_GroupLessonId",
                table: "Schedulers",
                column: "GroupLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_SingleLessonId",
                table: "Schedulers",
                column: "SingleLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_TeacherId",
                table: "Schedulers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleLesson_StudentsId",
                table: "SingleLesson",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleLesson_TeacherTypeLessonId",
                table: "SingleLesson",
                column: "TeacherTypeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SettingsStudentId",
                table: "Students",
                column: "SettingsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SettingsTeacherId",
                table: "Teacher",
                column: "SettingsTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TypeLessonsId",
                table: "TeacherTypeLesson",
                column: "TypeLessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeLessons_ParentId",
                table: "TypeLessons",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Violators_StudentsId",
                table: "Violators",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Violators_TeacherId",
                table: "Violators",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutTeacher");

            migrationBuilder.DropTable(
                name: "GroupLessonStudents");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropTable(
                name: "Schedulers");

            migrationBuilder.DropTable(
                name: "Violators");

            migrationBuilder.DropTable(
                name: "GroupLesson");

            migrationBuilder.DropTable(
                name: "SingleLesson");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherTypeLesson");

            migrationBuilder.DropTable(
                name: "SettingsStudent");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "TypeLessons");

            migrationBuilder.DropTable(
                name: "SettingsTeacher");
        }
    }
}
