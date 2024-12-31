﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularF1APIv2.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamDrivers",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_TeamID",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "TeamDrivers",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Drivers");
        }
    }
}
