using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Administrador")]
    public partial class Administrador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? UtilizadorId { get; set; }

        [ForeignKey(nameof(UtilizadorId))]
        [InverseProperty("Administradors")]
        public virtual Utilizador Utilizador { get; set; }
    }
}
