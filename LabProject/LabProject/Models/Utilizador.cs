using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Utilizador")]
    public partial class Utilizador
    {
        public Utilizador()
        {
            Administradors = new HashSet<Administrador>();
            Clientes = new HashSet<Cliente>();
            Restaurantes = new HashSet<Restaurante>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [Column("email")]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [Column("username")]
        [StringLength(150)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(150)]
        public string Password { get; set; }
        [Column("Imagem")]
        [StringLength(150)]
        public string Imagem { get; set; }
        [Column("bloqueado")]
        public bool Bloqueado { get; set; }
        [Column("motivo")]
        [StringLength(300)]
        public string Motivo { get; set; }
        [Column("notificacao")]
        public bool Notificacao { get; set; }

        [InverseProperty(nameof(Administrador.Utilizador))]
        public virtual ICollection<Administrador> Administradors { get; set; }
        [InverseProperty(nameof(Cliente.Utilizador))]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [InverseProperty(nameof(Restaurante.Utilizador))]
        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}
