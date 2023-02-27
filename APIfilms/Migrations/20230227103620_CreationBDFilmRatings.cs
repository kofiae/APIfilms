using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIfilms.Migrations
{
    public partial class CreationBDFilmRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false),
                    flm_id = table.Column<int>(type: "integer", nullable: false),
                    not_note = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_not", x => new { x.utl_id, x.flm_id });
                });

            migrationBuilder.CreateTable(
                name: "t_e_film_flm",
                columns: table => new
                {
                    flm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    flm_titre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    flm_resume = table.Column<string>(type: "text", nullable: false),
                    flm_datesortie = table.Column<DateTime>(type: "date", nullable: false),
                    flm_duree = table.Column<decimal>(type: "numeric", nullable: false),
                    flm_genre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NotesFilmUtilisateurId = table.Column<int>(type: "integer", nullable: false),
                    NotesFilmFilmId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_film_flm", x => x.flm_id);
                    table.ForeignKey(
                        name: "FK_t_e_film_flm_Notes_NotesFilmUtilisateurId_NotesFilmFilmId",
                        columns: x => new { x.NotesFilmUtilisateurId, x.NotesFilmFilmId },
                        principalTable: "Notes",
                        principalColumns: new[] { "utl_id", "flm_id" });
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_mobile = table.Column<string>(type: "char(10)", nullable: true),
                    utl_mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    utl_pwd = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    utl_rue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    utl_cp = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    utl_ville = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    utl_pays = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    utl_latitude = table.Column<float>(type: "real", nullable: true),
                    utl_longitude = table.Column<float>(type: "real", nullable: true),
                    utl_datecreation = table.Column<DateTime>(type: "date", nullable: false),
                    NotesUtilisateurUtilisateurId = table.Column<int>(type: "integer", nullable: false),
                    NotesUtilisateurFilmId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.utl_id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Notes_NotesUtilisateurUtilisateurId_NotesUtili~",
                        columns: x => new { x.NotesUtilisateurUtilisateurId, x.NotesUtilisateurFilmId },
                        principalTable: "Notes",
                        principalColumns: new[] { "utl_id", "flm_id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_flm_id",
                table: "Notes",
                column: "flm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_film_flm_NotesFilmUtilisateurId_NotesFilmFilmId",
                table: "t_e_film_flm",
                columns: new[] { "NotesFilmUtilisateurId", "NotesFilmFilmId" });

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_NotesUtilisateurUtilisateurId_NotesUtilisateur~",
                table: "Utilisateurs",
                columns: new[] { "NotesUtilisateurUtilisateurId", "NotesUtilisateurFilmId" });

            migrationBuilder.AddForeignKey(
                name: "fk_not_flm",
                table: "Notes",
                column: "flm_id",
                principalTable: "t_e_film_flm",
                principalColumn: "flm_id");

            migrationBuilder.AddForeignKey(
                name: "fk_not_utl",
                table: "Notes",
                column: "utl_id",
                principalTable: "Utilisateurs",
                principalColumn: "utl_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_not_flm",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "fk_not_utl",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "t_e_film_flm");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
