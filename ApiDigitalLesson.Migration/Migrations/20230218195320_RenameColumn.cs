using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migration.Migrations
{
    public partial class RenameColumn : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Teacher");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "TypeLessons",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Students",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                table: "Teacher",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Teacher",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teacher",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teacher");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TypeLessons",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Students",
                newName: "Discription");

            migrationBuilder.AlterColumn<string>(
                name: "Telegram",
                table: "Teacher",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Teacher",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Teacher",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
