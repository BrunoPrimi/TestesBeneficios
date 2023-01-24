using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesSimulacaoAbrangencia : IEntityTypeConfiguration<SimulacaoAbrangencia>
    {
        public void Configure(EntityTypeBuilder<SimulacaoAbrangencia> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("SimulacaoAbrangencia");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("Cidade");


            entityTypeBuilder.Property(x => x.Uf)
                .IsRequired()
                .HasColumnName("UF");
          
            entityTypeBuilder.HasOne(x => x.Simulacao)
                .WithMany(x => x.SimulacaoAbrangencia)
                .HasForeignKey(x => x.IdSimulacao)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
