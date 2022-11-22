using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesBeneficiario : IEntityTypeConfiguration<Beneficiario>
    {
        public void Configure(EntityTypeBuilder<Beneficiario> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Beneficiarios");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType($"Varchar({14})");

            entityTypeBuilder.Property(x => x.NomeMae)
               .IsRequired()
               .HasColumnName("NomeMae")
               .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Rg)
              .IsRequired()
              .HasColumnName("Rg")
              .HasColumnType($"Varchar({30})");

        }
    }
}
