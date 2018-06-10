using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Restaurante.Models
{ 
    /// <summary>
    /// Objeto que descreve um restaurante
    /// </summary>
    public class Restaurante
    {
        /// <summary>
        /// Id atribuido ao restaurante
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do restaurante
        /// </summary>
        [JsonRequired]
        public string Nome { get; set; }

        /// <summary>
        /// Lista com os pratos que o restaurante possui
        /// </summary>
        public List<Prato> Pratos { get; set; }
    }
}
