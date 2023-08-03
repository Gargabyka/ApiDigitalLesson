using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migration.Migrations
{
    public partial class UpdateDbColumn : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLesson_Students_StudentsId",
                table: "GroupLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLesson_TeacherTypeLesson_TypeLessonId",
                table: "GroupLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleLesson_TeacherTypeLesson_TypeLessonId",
                table: "SingleLesson");

            migrationBuilder.DropIndex(
                name: "IX_SingleLesson_TypeLessonId",
                table: "SingleLesson");

            migrationBuilder.DropIndex(
                name: "IX_GroupLesson_StudentsId",
                table: "GroupLesson");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "GroupLesson");

            migrationBuilder.RenameColumn(
                name: "TypeLessonId",
                table: "GroupLesson",
                newName: "TeacherTypeLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLesson_TypeLessonId",
                table: "GroupLesson",
                newName: "IX_GroupLesson_TeacherTypeLessonId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TeacherTypeLesson",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                table: "Teacher",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Teacher",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirthday",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "SingleLesson",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherTypeLessonId",
                table: "SingleLesson",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "GroupLesson",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "GroupLesson",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SingleLesson_TeacherTypeLessonId",
                table: "SingleLesson",
                column: "TeacherTypeLessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLesson_TeacherTypeLesson_TeacherTypeLessonId",
                table: "GroupLesson",
                column: "TeacherTypeLessonId",
                principalTable: "TeacherTypeLesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleLesson_TeacherTypeLesson_TeacherTypeLessonId",
                table: "SingleLesson",
                column: "TeacherTypeLessonId",
                principalTable: "TeacherTypeLesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupLesson_TeacherTypeLesson_TeacherTypeLessonId",
                table: "GroupLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleLesson_TeacherTypeLesson_TeacherTypeLessonId",
                table: "SingleLesson");

            migrationBuilder.DropIndex(
                name: "IX_SingleLesson_TeacherTypeLessonId",
                table: "SingleLesson");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TeacherTypeLesson");

            migrationBuilder.DropColumn(
                name: "DateBirthday",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "SingleLesson");

            migrationBuilder.DropColumn(
                name: "TeacherTypeLessonId",
                table: "SingleLesson");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "GroupLesson");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "GroupLesson");

            migrationBuilder.RenameColumn(
                name: "TeacherTypeLessonId",
                table: "GroupLesson",
                newName: "TypeLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupLesson_TeacherTypeLessonId",
                table: "GroupLesson",
                newName: "IX_GroupLesson_TypeLessonId");

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                table: "Teacher",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Teacher",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsId",
                table: "GroupLesson",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SingleLesson_TypeLessonId",
                table: "SingleLesson",
                column: "TypeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLesson_StudentsId",
                table: "GroupLesson",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLesson_Students_StudentsId",
                table: "GroupLesson",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLesson_TeacherTypeLesson_TypeLessonId",
                table: "GroupLesson",
                column: "TypeLessonId",
                principalTable: "TeacherTypeLesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleLesson_TeacherTypeLesson_TypeLessonId",
                table: "SingleLesson",
                column: "TypeLessonId",
                principalTable: "TeacherTypeLesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
