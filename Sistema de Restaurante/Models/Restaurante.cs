using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Restaurante.models
{
    public class Restaurante : DbContext
{
    public long id { get; set; }
    public string name { get; set; }
    public DbSet<Prato> pratos { get; set; }

    public Restaurante(DbContextOptions<Restaurante> options) : base(options) { }

}
}
