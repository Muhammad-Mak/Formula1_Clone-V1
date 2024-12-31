using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularF1APIv2.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_TeamID",
                table: "users",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamID",
                table: "Drivers",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Teams_TeamID",
                table: "Drivers",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_users_UserID",
                table: "Posts",
                column: "UserID",
                principalTable: "users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Teams_TeamID",
                table: "users",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Teams_TeamID",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_users_UserID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Teams_TeamID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_TeamID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TeamID",
                table: "Drivers");
        }
    }
}
