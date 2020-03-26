using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AjudaHumana.ONG.Data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ONGs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ResponsibleId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONGs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ONGs_Responsibles_Id",
                        column: x => x.Id,
                        principalTable: "Responsibles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    City = table.Column<string>(type: "varchar(64)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(9)", nullable: false),
                    Street = table.Column<string>(type: "varchar(256)", nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Complement = table.Column<string>(type: "varchar(128)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(128)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_ONGs_Id",
                        column: x => x.Id,
                        principalTable: "ONGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ONGs");

            migrationBuilder.DropTable(
                name: "Responsibles");
        }
    }
}
