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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateBirthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
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
                name: "AboutTeacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
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
                    Description = table.Column<string>(type: "text", nullable: false),
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
                name: "GroupLesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: false),
                    TeacherTypeLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCancel = table.Column<bool>(type: "boolean", nullable: false),
                    IsFinish = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    MaxQuantityStudents = table.Column<int>(type: "integer", nullable: false)
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
                    TypeLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCancel = table.Column<bool>(type: "boolean", nullable: false),
                    IsFinish = table.Column<bool>(type: "boolean", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TeacherTypeLessonId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("00d9588d-ac9c-4e99-80da-0db29f8c0e90"), 3, null, "Естественные науки", null },
                    { new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6"), 1, null, "ОГЭ", null },
                    { new Guid("58f69d5c-85ea-4496-aaa5-3aa41c55c89f"), 7, null, "Музыка", null },
                    { new Guid("7521011a-53a2-4d1c-88ed-625fc2c9e038"), 5, null, "Программирование", null },
                    { new Guid("7ef44aff-1929-4f1a-9994-b05f3c8699b5"), 6, null, "Школьная программа", null },
                    { new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b"), 0, null, "ЕГЭ", null },
                    { new Guid("c51a82b4-d961-4b61-8508-f750e1eb592a"), 4, null, "Гуманитарные науки", null },
                    { new Guid("d7f42acb-34ea-4bca-9d27-6bb98c4802c2"), 8, null, "Искусство", null },
                    { new Guid("f18125d6-84ad-4584-9721-9913ffca8a97"), 2, null, "Технические науки", null }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("07fbd819-0543-4881-a962-8f4e30ab956a"), null, null, "Биология", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("0be6c1fc-f3e0-45c2-a2bb-e1ad7febc574"), null, null, "История", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("0dc22604-d501-4066-9e76-bff2333183d6"), null, null, "История", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("1ef7e62a-6197-401f-9280-c2678234fd94"), null, null, "Литература", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("20850d2d-4486-4dda-8489-c664818c4525"), null, null, "Физика", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("258d4f34-a58c-42ab-aa95-d60146f22989"), null, null, "Китайский язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("2eadd22c-a0fd-4f39-ab47-b3fab5f835d5"), null, null, "Английский язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("34fb6a90-b2da-4a79-b397-10b0d73b445c"), null, null, "География", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("49d0413e-1067-4b87-9e60-b5404ee8eee2"), null, null, "Русский язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("61e44645-ed80-4e7f-b005-c290ec2f4110"), null, null, "Испанский язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("631e9573-5b58-4402-80f7-11b4c0220f6c"), null, null, "Китайский язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("6e69d1db-37ea-4a9a-9a27-fd9931ebf9e3"), null, null, "География", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("72a93f00-b5b4-4eb1-bf98-cc73dad10345"), null, null, "Химия", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("9060609d-65fa-4849-bda5-b166c6527238"), null, null, "Литература", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("9095ec51-8fbb-45ad-b09e-5a30fccd2c51"), null, null, "Физика", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("a0a061c4-6c33-479c-8e9b-1bcb32cc7de8"), null, null, "Биология", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("b40245ab-6803-4436-822b-8cf4053e7c7c"), null, null, "Французский язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("b545038d-d16b-4364-bace-65bbbcfc0deb"), null, null, "Обществознание", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("b93e2c77-5faa-4031-9c11-a41819594845"), null, null, "География", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("c0e822b6-6cf8-4e1c-9c12-8ba8a4e1eda7"), null, null, "География", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("cc5ec599-f42a-4ce2-a990-5525d01d4aee"), null, null, "Французский язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("d0888e04-1f93-4af2-88e7-976207f5fe5e"), null, null, "Испанский язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("d1dad1bc-20d5-47c8-b576-0512e9efa87f"), null, null, "Математика (профильный уровень)", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("d23edcd5-5897-4f64-b6d3-86a400d84b5d"), null, null, "Немецкий язык", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("d8cf60a7-21df-4ed9-9608-5e2a324c2d85"), null, null, "Обществознание", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("dafb304e-d531-4292-8884-3d523fcfdb6a"), null, null, "Математика", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("e1d729d8-eec3-41b6-8a93-632c484d2e68"), null, null, "Немецкий язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("e4203c90-1397-40cd-94c6-ecf6602d96e4"), null, null, "Английский язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("e8f93937-7210-4dba-badc-8ba1e3ba7cb0"), null, null, "Математика (базовый уровень)", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("ed8b6ede-894c-4eb4-ab4c-2459dcafe8f7"), null, null, "Русский язык", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("f5f754d7-d3f2-4db9-9ad4-670dad44af84"), null, null, "Химия", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") },
                    { new Guid("f7fbd719-690d-4805-a8c0-fa5f1183173b"), null, null, "Информатика", new Guid("7fe64d6f-556b-45f5-846e-5fd51f117b3b") },
                    { new Guid("fa52b414-1df0-407c-8dfc-a1d0dca9647a"), null, null, "Информатика", new Guid("21732d98-5a9b-45d6-8ac8-9cd8eea852e6") }
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
                name: "IX_SingleLesson_StudentsId",
                table: "SingleLesson",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleLesson_TeacherTypeLessonId",
                table: "SingleLesson",
                column: "TeacherTypeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TeacherId",
                table: "TeacherTypeLesson",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTypeLesson_TypeLessonsId",
                table: "TeacherTypeLesson",
                column: "TypeLessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeLessons_ParentId",
                table: "TypeLessons",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutTeacher");

            migrationBuilder.DropTable(
                name: "GroupLessonStudents");

            migrationBuilder.DropTable(
                name: "SingleLesson");

            migrationBuilder.DropTable(
                name: "GroupLesson");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherTypeLesson");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "TypeLessons");
        }
    }
}
