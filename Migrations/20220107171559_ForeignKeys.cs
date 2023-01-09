using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectWeb.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Factura_FacturaID",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Proprietate_Factura_FacturaID",
                table: "Proprietate");

            migrationBuilder.DropIndex(
                name: "IX_Proprietate_FacturaID",
                table: "Proprietate");

            migrationBuilder.DropIndex(
                name: "IX_Contact_FacturaID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "FacturaID",
                table: "Proprietate");

            migrationBuilder.DropColumn(
                name: "FacturaID",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Factura",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProprietateID",
                table: "Factura",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ContactID",
                table: "Factura",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ProprietateID",
                table: "Factura",
                column: "ProprietateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Contact_ContactID",
                table: "Factura",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Proprietate_ProprietateID",
                table: "Factura",
                column: "ProprietateID",
                principalTable: "Proprietate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Contact_ContactID",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Proprietate_ProprietateID",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ContactID",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ProprietateID",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ProprietateID",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "FacturaID",
                table: "Proprietate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturaID",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proprietate_FacturaID",
                table: "Proprietate",
                column: "FacturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_FacturaID",
                table: "Contact",
                column: "FacturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Factura_FacturaID",
                table: "Contact",
                column: "FacturaID",
                principalTable: "Factura",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proprietate_Factura_FacturaID",
                table: "Proprietate",
                column: "FacturaID",
                principalTable: "Factura",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
