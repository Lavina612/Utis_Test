using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utis_Test.Migrations
{
    /// <inheritdoc />
    public partial class Migration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels");

            migrationBuilder.RenameTable(
                name: "TaskModels",
                newName: "Tasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels",
                column: "Id");
        }
    }
}
