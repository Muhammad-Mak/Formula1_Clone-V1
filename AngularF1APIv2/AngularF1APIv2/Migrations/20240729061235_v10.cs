using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularF1APIv2.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverPostition",
                table: "Drivers",
                newName: "DriverPosition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverPosition",
                table: "Drivers",
                newName: "DriverPostition");
        }
    }
}
