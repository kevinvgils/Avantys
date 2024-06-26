using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectureService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ClassId",
                table: "Lectures",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_StudyMaterialId",
                table: "Lectures",
                column: "StudyMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Classes_ClassId",
                table: "Lectures",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_StudyMaterials_StudyMaterialId",
                table: "Lectures",
                column: "StudyMaterialId",
                principalTable: "StudyMaterials",
                principalColumn: "StudyMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Classes_ClassId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_StudyMaterials_StudyMaterialId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_ClassId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_StudyMaterialId",
                table: "Lectures");
        }
    }
}
