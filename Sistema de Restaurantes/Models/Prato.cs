using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Restaurante.Models
{
    /// <summary>
    /// Objeto que descreve um prato
    /// </summary>
    public class Prato
    {
        /// <summary>
        /// Id do prato, ele pode ser auto gerado
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do prato
        /// </summary>
        /// <example>Pizza</example>
        [JsonRequired]
        public string Nome { get; set; }

        /// <summary>
        /// Preço do prato
        /// </summary>
        [JsonRequired]
        public float Preco { get; set; }

        /// <summary>
        /// Id do restaurante a ele associado
        /// </summary>
        public long RestauranteId { get; set; }

        /// <summary>
        /// Referencia do restaurante a ele ligado.
        /// </summary>
        public Restaurante Restaurante { get; set; }
        
    }
}
