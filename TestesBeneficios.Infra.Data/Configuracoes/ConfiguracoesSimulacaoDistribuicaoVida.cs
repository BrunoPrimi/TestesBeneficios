using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesSimulacaoDistribuicaoVida : IEntityTypeConfiguration<SimulacaoDistribuicaoVida>
    {
        public void Configure(EntityTypeBuilder<SimulacaoDistribuicaoVida> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("SimulacaoDistribuicaoVida");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.AlcanceInicial)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.AlcanceFinal  )
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Quantidade)
               .IsRequired()
               .HasColumnName("Cpf")
               .HasColumnType($"Varchar({14})");


            entityTypeBuilder.HasOne(x => x.Simulacao)
                    .WithMany(x => x.SimulacaoDistribuicaoVida)
                    .HasForeignKey(x => x.IdSimulacao)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
