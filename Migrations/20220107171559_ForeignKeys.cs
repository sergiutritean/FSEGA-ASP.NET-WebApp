using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectWeb.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Comanda_ComandaID",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Foodtruck_Comanda_ComandaID",
                table: "Foodtruck");

            migrationBuilder.DropIndex(
                name: "IX_Foodtruck_ComandaID",
                table: "Foodtruck");

            migrationBuilder.DropIndex(
                name: "IX_Client_ComandaID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ComandaID",
                table: "Foodtruck");

            migrationBuilder.DropColumn(
                name: "ComandaID",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Comanda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodtruckID",
                table: "Comanda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_ClientID",
                table: "Comanda",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FoodtruckID",
                table: "Comanda",
                column: "FoodtruckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Client_ClientID",
                table: "Comanda",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Foodtruck_FoodtruckID",
                table: "Comanda",
                column: "FoodtruckID",
                principalTable: "Foodtruck",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Client_ClientID",
                table: "Comanda");

            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Foodtruck_FoodtruckID",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_ClientID",
                table: "Comanda");

            migrationBuilder.DropIndex(
                name: "IX_Comanda_FoodtruckID",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "FoodtruckID",
                table: "Comanda");

            migrationBuilder.AddColumn<int>(
                name: "ComandaID",
                table: "Foodtruck",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComandaID",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foodtruck_ComandaID",
                table: "Foodtruck",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ComandaID",
                table: "Client",
                column: "ComandaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Comanda_ComandaID",
                table: "Client",
                column: "ComandaID",
                principalTable: "Comanda",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Foodtruck_Comanda_ComandaID",
                table: "Foodtruck",
                column: "ComandaID",
                principalTable: "Comanda",
                principalColumn: "ID");
        }
    }
}
