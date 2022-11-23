using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Produtos");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Codigo)
                .IsRequired()
                .HasColumnName("Codigo")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.HasOne(x => x.Empresa)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdEmpresa)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
