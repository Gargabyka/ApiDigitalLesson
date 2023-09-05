using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migrator.Migrations
{
    public partial class UpdateViolators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violators_Students_StudentsId",
                table: "Violators");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentsId",
                table: "Violators",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Violators_Students_StudentsId",
                table: "Violators",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violators_Students_StudentsId",
                table: "Violators");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentsId",
                table: "Violators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Violators_Students_StudentsId",
                table: "Violators",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
