using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Restaurante.Models
{ 
    public class Restaurante
    {
        public long id { get; set; }
        public string nome { get; set; }

        public List<Prato> pratos { get; set; }
    }
}
