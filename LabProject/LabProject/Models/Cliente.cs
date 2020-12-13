using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            PratoClientes = new HashSet<PratoCliente>();
            RestauranteClientes = new HashSet<RestauranteCliente>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? UtilizadorId { get; set; }

        [ForeignKey(nameof(UtilizadorId))]
        [InverseProperty("Clientes")]
        public virtual Utilizador Utilizador { get; set; }
        [InverseProperty(nameof(PratoCliente.Cliente))]
        public virtual ICollection<PratoCliente> PratoClientes { get; set; }
        [InverseProperty(nameof(RestauranteCliente.Cliente))]
        public virtual ICollection<RestauranteCliente> RestauranteClientes { get; set; }
    }
}
