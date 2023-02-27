﻿// <auto-generated />
using System;
using APIfilms.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIfilms.Migrations
{
    [DbContext(typeof(FilmRatingsDBContext))]
    partial class FilmRatingsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FilmId"));

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("date")
                        .HasColumnName("flm_datesortie");

                    b.Property<decimal>("Duree")
                        .HasColumnType("numeric")
                        .HasColumnName("flm_duree");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("flm_genre");

                    b.Property<int>("NotesFilmFilmId")
                        .HasColumnType("integer");

                    b.Property<int>("NotesFilmUtilisateurId")
                        .HasColumnType("integer");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("flm_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("flm_titre");

                    b.HasKey("FilmId");

                    b.HasIndex("NotesFilmUtilisateurId", "NotesFilmFilmId");

                    b.ToTable("t_e_film_flm");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    b.Property<int>("Note")
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.HasKey("UtilisateurId", "FilmId")
                        .HasName("pk_not");

                    b.HasIndex("FilmId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("date")
                        .HasColumnName("utl_datecreation");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_nom");

                    b.Property<int>("NotesUtilisateurFilmId")
                        .HasColumnType("integer");

                    b.Property<int>("NotesUtilisateurUtilisateurId")
                        .HasColumnType("integer");

                    b.Property<string>("Pays")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("utl_rue");

                    b.Property<int>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("NotesUtilisateurUtilisateurId", "NotesUtilisateurFilmId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Film", b =>
                {
                    b.HasOne("APIfilms.Models.EntityFramework.Notation", "NotesFilm")
                        .WithMany("Films")
                        .HasForeignKey("NotesFilmUtilisateurId", "NotesFilmFilmId")
                        .IsRequired();

                    b.Navigation("NotesFilm");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("APIfilms.Models.EntityFramework.Film", "FilmNote")
                        .WithMany("Notes")
                        .HasForeignKey("FilmId")
                        .IsRequired()
                        .HasConstraintName("fk_not_flm");

                    b.HasOne("APIfilms.Models.EntityFramework.Utilisateur", "UtilisateurNotant")
                        .WithMany("Notes")
                        .HasForeignKey("UtilisateurId")
                        .IsRequired()
                        .HasConstraintName("fk_not_utl");

                    b.Navigation("FilmNote");

                    b.Navigation("UtilisateurNotant");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Utilisateur", b =>
                {
                    b.HasOne("APIfilms.Models.EntityFramework.Notation", "NotesUtilisateur")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("NotesUtilisateurUtilisateurId", "NotesUtilisateurFilmId")
                        .IsRequired();

                    b.Navigation("NotesUtilisateur");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Film", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Notation", b =>
                {
                    b.Navigation("Films");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("APIfilms.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
