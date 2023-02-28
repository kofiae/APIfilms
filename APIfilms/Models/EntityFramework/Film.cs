using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Diagnostics.CodeAnalysis;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Required]
        [Column("flm_titre")]
        [MaxLength(100)]
        public string Titre { get; set; }

        [Column("flm_resume")]
        [AllowNull]
        public string Resume { get; set; }

        [Column("flm_datesortie", TypeName = "date")]
        [DataType("date")]
        [AllowNull]
        public DateTime? DateSortie { get; set; }

        [Column("flm_duree", TypeName = "numeric(3,0)")]
        [AllowNull]
        public decimal? Duree  { get; set; }

        [Column("flm_genre")]
        [MaxLength(30)]
        [AllowNull]
        public string Genre { get; set; }



        [InverseProperty("FilmNote")]
        public virtual ICollection<Notation> NotesFilm { get; set; }
    }
}
