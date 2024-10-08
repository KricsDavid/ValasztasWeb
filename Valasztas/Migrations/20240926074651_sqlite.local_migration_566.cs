﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valasztas.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_566 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partok",
                columns: table => new
                {
                    rovidnev = table.Column<string>(type: "TEXT", nullable: false),
                    hosszunev = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partok", x => x.rovidnev);
                });

            migrationBuilder.CreateTable(
                name: "Jeloltek",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Kerulet = table.Column<int>(type: "INTEGER", nullable: false),
                    szavazatszam = table.Column<int>(type: "INTEGER", nullable: false),
                    PartRovidNev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeloltek", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jeloltek_Partok_PartRovidNev",
                        column: x => x.PartRovidNev,
                        principalTable: "Partok",
                        principalColumn: "rovidnev",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeloltek_PartRovidNev",
                table: "Jeloltek",
                column: "PartRovidNev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeloltek");

            migrationBuilder.DropTable(
                name: "Partok");
        }
    }
}
