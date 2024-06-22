using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GradeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Tests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudyPoints",
                table: "Tests",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "StudyPoints",
                table: "Tests");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
