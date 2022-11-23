using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesEmpresa : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Empresas");

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

            

        }
    }
}
