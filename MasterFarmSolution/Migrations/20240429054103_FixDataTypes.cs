using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterFarmSolution.Migrations
{
    /// <inheritdoc />
    public partial class FixDataTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "OperationXGames",
                newName: "is_active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "OperationXGames",
                newName: "isActive");
        }
    }
}
