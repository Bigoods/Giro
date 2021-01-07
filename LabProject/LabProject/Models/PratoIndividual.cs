using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Prato")]
    public partial class PratoIndividual
    {
        public PratoIndividual()
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

        public double Preco { get; set; }

        public string Descricao { get; set; }

        [Required]
        [Column("foto")]
        [StringLength(150)]
        public string Foto { get; set; }
        [Column("Tipo_PratoId")]
        public int? TipoPratoId { get; set; }

        [ForeignKey(nameof(TipoPratoId))]
        [InverseProperty("Pratos")]
        public virtual TipoPrato TipoPrato { get; set; }
        [InverseProperty(nameof(RestaurantePrato.Prato))]
        public virtual ICollection<RestaurantePrato> RestaurantePratos { get; set; }



        public PratoIndividual(Prato prato, double _preco, string Desc,string _foto)
        {
            Id = prato.Id;
            Nome = prato.Nome;
            Preco = _preco;
            TipoPratoId = prato.TipoPratoId;
            TipoPrato = prato.TipoPrato;
            RestaurantePratos = prato.RestaurantePratos;
            Descricao = Desc;
            Foto = _foto;
        }

    }
}
