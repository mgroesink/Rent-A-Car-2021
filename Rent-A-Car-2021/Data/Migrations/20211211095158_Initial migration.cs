using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car_2021.Data.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Kenteken = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Merk = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Dagprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Kenteken);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Klantcode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    Voorletters = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tussenvoegsels = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Postcode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: true),
                    Woonplaats = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    AspNetUserNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Klantcode);
                    table.ForeignKey(
                        name: "FK_Klanten_AspNetUsers_AspNetUserNavigationId",
                        column: x => x.AspNetUserNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Medewerkerscode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tussenvoegsels = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AspNetUserNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Medewerkerscode);
                    table.ForeignKey(
                        name: "FK_Medewerkers_AspNetUsers_AspNetUserNavigationId",
                        column: x => x.AspNetUserNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Factuurnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Klantcode = table.Column<string>(type: "char(6)", nullable: true),
                    Medewerkerscode = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Factuurnummer);
                    table.ForeignKey(
                        name: "FK_Facturen_Klanten_Klantcode",
                        column: x => x.Klantcode,
                        principalTable: "Klanten",
                        principalColumn: "Klantcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturen_Medewerkers_Medewerkerscode",
                        column: x => x.Medewerkerscode,
                        principalTable: "Medewerkers",
                        principalColumn: "Medewerkerscode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factuurregels",
                columns: table => new
                {
                    Factuurnummer = table.Column<int>(type: "int", nullable: false),
                    Kenteken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Begindatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dagprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Factuurnummer1 = table.Column<int>(type: "int", nullable: true),
                    AutoKenteken = table.Column<string>(type: "nvarchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factuurregels", x => new { x.Factuurnummer, x.Kenteken });
                    table.ForeignKey(
                        name: "FK_Factuurregels_Autos_AutoKenteken",
                        column: x => x.AutoKenteken,
                        principalTable: "Autos",
                        principalColumn: "Kenteken",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factuurregels_Facturen_Factuurnummer1",
                        column: x => x.Factuurnummer1,
                        principalTable: "Facturen",
                        principalColumn: "Factuurnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_Klantcode",
                table: "Facturen",
                column: "Klantcode");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_Medewerkerscode",
                table: "Facturen",
                column: "Medewerkerscode");

            migrationBuilder.CreateIndex(
                name: "IX_Factuurregels_AutoKenteken",
                table: "Factuurregels",
                column: "AutoKenteken");

            migrationBuilder.CreateIndex(
                name: "IX_Factuurregels_Factuurnummer1",
                table: "Factuurregels",
                column: "Factuurnummer1");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_AspNetUserNavigationId",
                table: "Klanten",
                column: "AspNetUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AspNetUserNavigationId",
                table: "Medewerkers",
                column: "AspNetUserNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factuurregels");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Medewerkers");
        }
    }
}
