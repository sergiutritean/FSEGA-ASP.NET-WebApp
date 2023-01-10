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
                name: "Factura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    suma = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IDUtilizator = table.Column<int>(type: "int", nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factura_Utilizator_IDUtilizator",
                        column: x => x.IDUtilizator,
                        principalTable: "Utilizator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    Nume = table.Column<string>(type: "text", nullable: true),
                    Nr_tel = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FacturaID = table.Column<int>(type: "int", nullable: true),
                    IDUtilizator = table.Column<int>(type: "int", nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contact_Factura_FacturaID",
                        column: x => x.FacturaID,
                        principalTable: "Factura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Utilizator_IDUtilizator",
                        column: x => x.IDUtilizator,
                        principalTable: "Utilizator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proprietate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy", 
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.SerialColumn
                        ),
                    Tip_oferta = table.Column<string>(type: "text", nullable: true),
                    Zona = table.Column<string>(type: "text", nullable: true),
                    Nr_camere = table.Column<int>(type: "int", nullable: false),
                    Suprafata = table.Column<int>(type: "int", nullable: false),
                    Amplasament = table.Column<string>(type: "text", nullable: true),
                    Adresa = table.Column<string>(type: "text", nullable: true),
                    FacturaID = table.Column<int>(type: "int", nullable: true),
                    IDUtilizator = table.Column<int>(type: "int", nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proprietate_Factura_FacturaID",
                        column: x => x.FacturaID,
                        principalTable: "Factura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Utilizator_IDUtilizator",
                        column: x => x.IDUtilizator,
                        principalTable: "Utilizator",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_FacturaID",
                table: "Contact",
                column: "FacturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietate_FacturaID",
                table: "Proprietate",
                column: "FacturaID");
            
            migrationBuilder.CreateIndex(
                name: "IX_Factura_IDUtilizator",
                table: "Factura",
                column: "IDUtilizator");
            
            migrationBuilder.CreateIndex(
                name: "IX_Contact_IDUtilizator",
                table: "Contact",
                column: "IDUtilizator");
            
            migrationBuilder.CreateIndex(
                name: "IX_Proprietate_IDUtilizator",
                table: "Proprietate",
                column: "IDUtilizator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Proprietate");

            migrationBuilder.DropTable(
                name: "Factura");
            
            migrationBuilder.DropTable(
                name: "Utilizator");
        }
    }
}
