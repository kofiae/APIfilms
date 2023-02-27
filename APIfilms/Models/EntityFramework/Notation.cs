using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("not_note")]
        public int Note { get; set; }

        [InverseProperty("Notes")]
        public virtual Utilisateur UtilisateurNotant { get; set; }

        [InverseProperty("Notes")]
        public virtual Film FilmNote { get; set; }


        [InverseProperty("NotesFilm")]
        public virtual ICollection<Film> Films { get; set; }

        [InverseProperty("NotesUtilisateur")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
