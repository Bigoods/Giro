using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Restaurante_Cliente")]
    public partial class RestauranteCliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? RestauranteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("RestauranteClientes")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey(nameof(RestauranteId))]
        [InverseProperty("RestauranteClientes")]
        public virtual Restaurante Restaurante { get; set; }
    }
}
