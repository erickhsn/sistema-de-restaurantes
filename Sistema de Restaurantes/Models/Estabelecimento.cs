using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Restaurantes.Models
{
    public class Estabelecimento
    {
        public DbSet<Restaurante> restaurantes { get; set; }
    }
}
