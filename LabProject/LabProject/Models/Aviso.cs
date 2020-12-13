using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Table("Aviso")]
    public partial class Aviso
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("titulo")]
        [StringLength(300)]
        public string Titulo { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Column("foto")]
        [StringLength(300)]
        public string Foto { get; set; }
        [Column("data", TypeName = "date")]
        public DateTime Data { get; set; }
    }
}
