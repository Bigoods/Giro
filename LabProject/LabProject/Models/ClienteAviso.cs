using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LabProject.Models
{
    [Keyless]
    [Table("Cliente_aviso")]
    public partial class ClienteAviso
    {
        public int? ClienteId { get; set; }
        public int? AvisoId { get; set; }

        [ForeignKey(nameof(AvisoId))]
        public virtual Aviso Aviso { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente Cliente { get; set; }
    }
}
