using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudyProgramId",
                table: "StudyPrograms",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudyPrograms",
                newName: "StudyProgramId");
        }
    }
}
