using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("flm_titre")]
        [MaxLength(100)]
        public string Titre { get; set; } = null!;

        [Column("flm_resume")]
        public string Resume { get; set; }

        [Column("flm_datesortie", TypeName = "date")]
        [DataType("date")]
        public DateTime DateSortie { get; set; }

        [Column("flm_duree")]
        public decimal Duree  { get; set; }

        [Column("flm_genre")]
        [MaxLength(30)]
        public string Genre { get; set; }

        [InverseProperty("Film")]
        public virtual Notation NotesFilm { get; set; }



        [InverseProperty("NotesUtilisateur")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
        
        [InverseProperty("FilmNote")]
        public virtual ICollection<Notation> Notes { get; set; }
    }
}
