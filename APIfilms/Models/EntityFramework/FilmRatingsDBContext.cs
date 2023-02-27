using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace APIfilms.Models.EntityFramework
{
    public partial class FilmRatingsDBContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public FilmRatingsDBContext()
        {
        }

        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notation> Notes { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseNpgsql("Server=localhost;port=5432;Database=FilmsRatingsDB; uid= postgres; password=postgres;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {

                entity.HasOne(d => d.NotesFilm)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_flm_not");
            });


            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasOne(d => d.NotesUtilisateur)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_utl_not");
            });

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.FilmId })
                                    .HasName("pk_not");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_utl");

                entity.HasOne(d => d.FilmNote)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_flm");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
