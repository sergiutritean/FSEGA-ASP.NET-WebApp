using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    FirstName = table.Column<String>(type: "text", nullable:false),
                    LastName = table.Column<String>(type: "text", nullable:false),
                    Email = table.Column<String>(type: "text", nullable:false),
                    Password = table.Column<String>(type: "text", nullable:false)
                }
            );

            migrationBuilder.CreateIndex(
                name: "IXU_Utilizator_ID",
                table: "Utilizator",
                column: "ID",
                unique: true
            );
            
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    Nume = table.Column<string>(type: "text", nullable: true),
                    NrTel = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });
            
            migrationBuilder.CreateTable(
                name: "Foodtruck",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    Tip = table.Column<string>(type: "text", nullable: true),
                    Nume = table.Column<string>(type: "text", nullable: true),
                    Adresa = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodtruck", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    Suma = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descriere = table.Column<string>(type: "text"),
                    ClientID = table.Column<int>(type: "int"),
                    FoodtruckID = table.Column<int>(type: "int")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comanda_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comanda_Foodtruck_FoodtruckID",
                        column: x => x.FoodtruckID,
                        principalTable: "Foodtruck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });         

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_ClientID",
                table: "Comanda",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FoodtruckID",
                table: "Comanda",
                column: "FoodtruckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Foodtruck");

            migrationBuilder.DropTable(
                name: "Comanda");
            
            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
