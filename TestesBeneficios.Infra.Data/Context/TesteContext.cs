using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Configuracoes;

namespace TestesBeneficios.Infra.Data.Context
{
    public class TesteContext : DbContext
    {
        public DbSet<Beneficiario> Beneficiarios { get; set; }

        public TesteContext()
        {

        }

        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\Local;Database=TesteDB;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Beneficiario>(new ConfiguracoesBeneficiario().Configure);
        
        }
    }
}
