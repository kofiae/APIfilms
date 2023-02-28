using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace APIfilms.Models.EntityFramework
{
    [Index(nameof(Mail), IsUnique = true, Name = "uq_utl_mail")]
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [MaxLength(50)]
        [AllowNull]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [MaxLength(50)]
        [AllowNull]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [AllowNull]
        public string? Mobile { get; set; }
        
        [Required]
        [Column("utl_mail")]
        [StringLength(100)]
        public string? Mail { get; set; }

        [Required]
        [Column("utl_pwd")]
        [MaxLength(64)]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        [MaxLength(200)]
        [AllowNull]
        public string? Rue { get; set; }

        [Column("utl_cp")]
        [MaxLength(5)]
        [AllowNull]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [MaxLength(50)]
        [AllowNull]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        [MaxLength(50)]
        [DefaultValue("France")]
        [AllowNull]
        public string? Pays { get; set; }

        [Column("utl_latitude")]
        [AllowNull]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        [AllowNull]
        public float? Longitude { get; set; }

        [Column("utl_datecreation", TypeName = "date")]
        [Required]
        public DateTime DateCreation { get; set; }


        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation> NotesUtilisateur { get; set; }

    }
}
