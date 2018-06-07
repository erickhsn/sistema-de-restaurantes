using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Restaurante.Models
{
    public class Prato
    {
        public long id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }

        public Restaurante restaurante { get; set; }
    }
}
