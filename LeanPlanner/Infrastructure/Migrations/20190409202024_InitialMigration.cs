using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projekt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bezeichnung = table.Column<string>(nullable: false),
                    kostenstelle = table.Column<string>(nullable: true),
                    adresse = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vorgang",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    projekt_id = table.Column<int>(nullable: false),
                    zug = table.Column<string>(nullable: false),
                    anfang = table.Column<DateTime>(nullable: false),
                    ende = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vorgang", x => x.id);
                    table.ForeignKey(
                        name: "FK_vorgang_projekt_projekt_id",
                        column: x => x.projekt_id,
                        principalTable: "projekt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vorgang_projekt_id",
                table: "vorgang",
                column: "projekt_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vorgang");

            migrationBuilder.DropTable(
                name: "projekt");
        }
    }
}
