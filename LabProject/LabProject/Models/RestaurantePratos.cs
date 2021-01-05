
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabProject.Models
{
    public class RestaurantePratos
    {
        public Restaurante Restaurante { get; set; }
        public List<Prato> Pratos = new List<Prato>();
    }
}
