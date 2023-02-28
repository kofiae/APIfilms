using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        [Key]
        [Required]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Required]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("not_note")]
        [Required]
        public int Note { get; set; }

        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; }

        [InverseProperty("NotesFilm")]
        public virtual Film FilmNote { get; set; }
    }
}
