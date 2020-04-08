using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AjudaHumana.ONG.Data.Migrations
{
    public partial class AddedRequestAndGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ONGId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", nullable: false),
                    Finished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_ONGs_ONGId",
                        column: x => x.ONGId,
                        principalTable: "ONGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RequestId = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(type: "varchar(128)", nullable: false),
                    CurrentGoal = table.Column<int>(nullable: false),
                    FinishedGoal = table.Column<int>(nullable: false),
                    Finished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_RequestId",
                table: "Goals",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ONGId",
                table: "Requests",
                column: "ONGId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
