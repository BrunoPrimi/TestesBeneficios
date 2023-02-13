using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class TesteContext :IdentityDbContext<Usuario>
    {
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<DeclaracaoDeSaude> DeclaracaoDeSaudes { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        public DbSet<EntidadeDeClasse> EntidadeDeClasses { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<Contratacao> Contratacoes { get; set; }

        public DbSet<SimulacaoAbrangencia> Abrangencias { get; set; }

        public DbSet<SimulacaoDistribuicaoVida> DistribuicaoVidas { get; set; }

        public DbSet<ProdutoFaixaEtaria> FaixaEtaria { get; set; }
        public DbSet<ProdutoAbrangencia> Abrangencia { get; set; }

        public TesteContext()
        {

        }

        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=TesteDB.mssql.somee.com;database=TesteDB;user id=Primi_SQLLogin_1;password=6ul8yeadfr;trust server certificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Beneficiario>(new ConfiguracoesBeneficiario().Configure);
                       
            modelBuilder.Entity<Empresa>(new ConfiguracoesEmpresa().Configure);

            modelBuilder.Entity<Profissao>(new ConfiguracoesProfissao().Configure);

            modelBuilder.Entity<EntidadeDeClasse>(new ConfiguracoesEntidadeDeClasse().Configure);

            modelBuilder.Entity<Produto>(new ConfiguracoesProduto().Configure);

            modelBuilder.Entity<Contratacao>(new ConfiguracoesContratacao().Configure);

            modelBuilder.Entity<Simulacao>(new ConfiguracoesSimulacao().Configure);

            modelBuilder.Entity<SimulacaoAbrangencia>(new ConfiguracoesSimulacaoAbrangencia().Configure);

            modelBuilder.Entity<SimulacaoDistribuicaoVida>(new ConfiguracoesSimulacaoDistribuicaoVida().Configure);

            modelBuilder.Entity<ProdutoFaixaEtaria>(new ConfiguracoesProdutoFaixaEtaria().Configure);

            modelBuilder.Entity<ProdutoAbrangencia>(new ConfiguracoesProdutoAbrangencia().Configure);

        }
    }
}
