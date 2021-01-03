using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Restaurante_Prato")]
    public partial class RestaurantePrato
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("dia", TypeName = "date")]
        public DateTime Dia { get; set; }
        [Required]
        [Column("foto")]
        [StringLength(150)]
        public string Foto { get; set; }
        [Column("descricao")]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Column("preco")]
        public double Preco { get; set; }
        public int? PratoId { get; set; }
        public int? RestauranteId { get; set; }

        [ForeignKey(nameof(PratoId))]
        [InverseProperty("RestaurantePratos")]
        public virtual Prato Prato { get; set; }
        [ForeignKey(nameof(RestauranteId))]
        [InverseProperty("RestaurantePratos")]
        public virtual Restaurante Restaurante { get; set; }
    }
}
