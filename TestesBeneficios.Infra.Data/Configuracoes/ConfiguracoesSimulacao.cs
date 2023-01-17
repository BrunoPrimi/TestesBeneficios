using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesSimulacao : IEntityTypeConfiguration<Simulacao>
    {
        public void Configure(EntityTypeBuilder<Simulacao> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Simulacoes");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

           

            

        }
    }
}
