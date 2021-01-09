using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Restaurante")]
    public partial class Restaurante
    {
        public Restaurante()
        {
            RestauranteClientes = new HashSet<RestauranteCliente>();
            RestaurantePratos = new HashSet<RestaurantePrato>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int? UtilizadorId { get; set; }
        [Column("telefone")]
        public int? Telefone { get; set; }
        [Required(ErrorMessage = "Indique a sua morada")]
        [Column("morada")]
        [StringLength(300)]
        public string Morada { get; set; }
        [Required(ErrorMessage = "Indique a hora de abertura")]
        [Column("hora_abertura")]
        [StringLength(250)]
        public string HoraAbertura { get; set; }
        [Required(ErrorMessage = "Indique a hora de fecho")]
        [Column("hora_fecho")]
        [StringLength(250)]
        public string HoraFecho { get; set; }
        [Column("dia_descanso")]
        [StringLength(250)]
        public string DiaDescanso { get; set; }
        [Column("aprovado")]
        public bool Aprovado { get; set; }

        [ForeignKey(nameof(UtilizadorId))]
        [InverseProperty("Restaurantes")]
        public virtual Utilizador Utilizador { get; set; }
        [InverseProperty(nameof(RestauranteCliente.Restaurante))]
        public virtual ICollection<RestauranteCliente> RestauranteClientes { get; set; }
        [InverseProperty(nameof(RestaurantePrato.Restaurante))]
        public virtual ICollection<RestaurantePrato> RestaurantePratos { get; set; }
    }
}
