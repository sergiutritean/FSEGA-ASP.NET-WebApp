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
                    Descriere = table.Column<string>(type: "text")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                });

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
                    ComandaID = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_Comanda_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
/*                    table.ForeignKey(
                        name: "FK_Comanda_Utilizator_IDUtilizator",
                        column: x => x.IDUtilizator,
                        principalTable: "Utilizator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);*/
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
                    ComandaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodtruck", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foodtruck_Comanda_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ComandaID",
                table: "Client",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_Foodtruck_ComandaID",
                table: "Foodtruck",
                column: "ComandaID");
            
/*            migrationBuilder.CreateIndex(
                name: "IX_Comanda_IDUtilizator",
                table: "Comanda",
                column: "IDUtilizator");
            
            migrationBuilder.CreateIndex(
                name: "IX_Client_IDUtilizator",
                table: "Client",
                column: "IDUtilizator");
            
            migrationBuilder.CreateIndex(
                name: "IX_Foodtruck_IDUtilizator",
                table: "Foodtruck",
                column: "IDUtilizator");*/
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
