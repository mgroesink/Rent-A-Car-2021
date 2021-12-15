using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent_A_Car_2021.Migrations
{
    public partial class Factuurregelidupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factuurregels_Facturen_Factuurnummer",
                table: "Factuurregels");

            migrationBuilder.RenameColumn(
                name: "FactuurID",
                table: "Factuurregels",
                newName: "FactuurRegelID");

            migrationBuilder.AlterColumn<int>(
                name: "Factuurnummer",
                table: "Factuurregels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Factuurregels_Facturen_Factuurnummer",
                table: "Factuurregels",
                column: "Factuurnummer",
                principalTable: "Facturen",
                principalColumn: "Factuurnummer",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factuurregels_Facturen_Factuurnummer",
                table: "Factuurregels");

            migrationBuilder.RenameColumn(
                name: "FactuurRegelID",
                table: "Factuurregels",
                newName: "FactuurID");

            migrationBuilder.AlterColumn<int>(
                name: "Factuurnummer",
                table: "Factuurregels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factuurregels_Facturen_Factuurnummer",
                table: "Factuurregels",
                column: "Factuurnummer",
                principalTable: "Facturen",
                principalColumn: "Factuurnummer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
