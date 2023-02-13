using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.DL.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_User_UserId1",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_UserId1",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_UserId1",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "Discription",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Teacher",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discription",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserId1",
                table: "Teacher",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId1",
                table: "Students",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_User_UserId1",
                table: "Students",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_UserId1",
                table: "Teacher",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
