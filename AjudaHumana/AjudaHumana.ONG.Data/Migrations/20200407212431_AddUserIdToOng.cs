using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AjudaHumana.ONG.Data.Migrations
{
    public partial class AddUserIdToOng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "ONGs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ONGs");
        }
    }
}
