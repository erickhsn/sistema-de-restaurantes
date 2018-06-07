using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Restaurante.Models
{
    public class Context : DbContext
    {
        public DbSet<Prato> pratos { get; set; }
        public DbSet<Restaurante> restaurantes { get; set; }

        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prato>()
                .HasOne(p => p.restaurante)
                .WithMany(r => r.pratos);
        }
    }
}
