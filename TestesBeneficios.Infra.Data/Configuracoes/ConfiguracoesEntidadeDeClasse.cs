using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesEntidadeDeClasse : IEntityTypeConfiguration<EntidadeDeClasse>
    {
        public void Configure(EntityTypeBuilder<EntidadeDeClasse> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("EntidadeDeClasses");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Cnpj)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.RazaoSocial)
                .IsRequired()
                .HasColumnName("RazaoSocial")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.NomeFantasia)
               .IsRequired()
               .HasColumnName("NomeFantasia")
               .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Apelido)
               .IsRequired()
               .HasColumnName("Apelido")
               .HasColumnType($"Varchar({100})");

        }
    }
}
