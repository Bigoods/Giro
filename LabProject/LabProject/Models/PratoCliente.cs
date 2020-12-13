using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Prato_Cliente")]
    public partial class PratoCliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? PratoId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("PratoClientes")]
        public virtual Cliente Cliente { get; set; }
    }
}
