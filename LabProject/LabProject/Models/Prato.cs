using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Prato")]
    public partial class Prato
    {
        public Prato()
        {
            RestaurantePratos = new HashSet<RestaurantePrato>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(300)]
        public string Nome { get; set; }
        [Column("preco")]
        public double Preco { get; set; }

        [Required]
        [Column("foto")]
        [StringLength(150)]
        public string Foto { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Column("Tipo_PratoId")]
        public int? TipoPratoId { get; set; }

        [ForeignKey(nameof(TipoPratoId))]
        [InverseProperty("Pratos")]
        public virtual TipoPrato TipoPrato { get; set; }
        [InverseProperty(nameof(RestaurantePrato.Prato))]
        public virtual ICollection<RestaurantePrato> RestaurantePratos { get; set; }
    }
}
