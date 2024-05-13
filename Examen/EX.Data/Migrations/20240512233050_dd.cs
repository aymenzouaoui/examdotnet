using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EX.Data.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conseillers",
                columns: table => new
                {
                    conseillerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conseillrName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ConseillerFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conseillers", x => x.conseillerId);
                });

            migrationBuilder.CreateTable(
                name: "packs",
                columns: table => new
                {
                    packId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nbPlaces = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    intitulePack = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packs", x => x.packId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ConseillerFK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.identifiant);
                    table.ForeignKey(
                        name: "FK_Clients_Conseillers_ConseillerFK",
                        column: x => x.ConseillerFK,
                        principalTable: "Conseillers",
                        principalColumn: "conseillerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activites",
                columns: table => new
                {
                    activiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zone_ville = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    zone_pays = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    prix = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    typeService = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    packId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activites", x => x.activiteId);
                    table.ForeignKey(
                        name: "FK_activites_packs_packId",
                        column: x => x.packId,
                        principalTable: "packs",
                        principalColumn: "packId");
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nbPersonnes = table.Column<int>(type: "int", nullable: false),
                    CLientId = table.Column<int>(type: "int", nullable: false),
                    packId = table.Column<int>(type: "int", nullable: false),
                    CLientidentifiant = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_reservations_Clients_CLientId",
                        column: x => x.CLientId,
                        principalTable: "Clients",
                        principalColumn: "identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Clients_CLientidentifiant",
                        column: x => x.CLientidentifiant,
                        principalTable: "Clients",
                        principalColumn: "identifiant");
                    table.ForeignKey(
                        name: "FK_reservations_packs_packId",
                        column: x => x.packId,
                        principalTable: "packs",
                        principalColumn: "packId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activites_packId",
                table: "activites",
                column: "packId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ConseillerFK",
                table: "Clients",
                column: "ConseillerFK");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_CLientId",
                table: "reservations",
                column: "CLientId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_CLientidentifiant",
                table: "reservations",
                column: "CLientidentifiant");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_packId",
                table: "reservations",
                column: "packId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activites");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "packs");

            migrationBuilder.DropTable(
                name: "Conseillers");
        }
    }
}
