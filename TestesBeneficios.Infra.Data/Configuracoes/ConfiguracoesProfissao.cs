using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesProfissao : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Profissoes");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

           

            

        }
    }
}
