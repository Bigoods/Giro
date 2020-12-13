using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Tipo_Prato")]
    public partial class TipoPrato
    {
        public TipoPrato()
        {
            Pratos = new HashSet<Prato>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(300)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Prato.TipoPrato))]
        public virtual ICollection<Prato> Pratos { get; set; }
    }
}
