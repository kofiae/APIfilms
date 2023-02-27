using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIfilms.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [MaxLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [MaxLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        public string? Mobile { get; set; }

        [Column("utl_mail")]
        [MaxLength(100)]
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        [MaxLength(64)]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        [MaxLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp")]
        [MaxLength(5)]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [MaxLength(50)]
        public int Ville { get; set; }

        [Column("utl_pays")]
        [MaxLength(50)]
        public string? Pays { get; set; }

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation", TypeName = "date")]
        public DateTime DateCreation { get; set; }


        [InverseProperty("Utilisateurs")]
        public virtual Notation NotesUtilisateur { get; set; }


        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation> Notes { get; set; }
    }
}
