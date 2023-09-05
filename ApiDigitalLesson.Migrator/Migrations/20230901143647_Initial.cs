using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migrator.Migrations
{
    public partial class Initial : Migration
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
                column: "TeacherId");

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
