
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabProject.Models
{
    public class RestaurantePratosPertence
    {
        public Restaurante Restaurante { get; set; }
        public List<PratoIndividual> Pratos = new List<PratoIndividual>();
    }
}
