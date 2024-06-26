using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudyMaterials",
                newName: "StudyMaterialId");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Lectures",
                newName: "LectureId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudyMaterialId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                column: "LectureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "StudyMaterialId",
                table: "StudyMaterials",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "Lectures",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudyMaterialId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Lectures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                column: "Id");
        }
    }
}
