using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesProdutoFaixaEtaria : IEntityTypeConfiguration<ProdutoFaixaEtaria>
    {
        public void Configure(EntityTypeBuilder<ProdutoFaixaEtaria> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("FaixaEtaria");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.FaixaDe)
                .IsRequired()
                .HasColumnName("FaixaDe");


            entityTypeBuilder.Property(x => x.FaixaAte)
                .IsRequired()
                .HasColumnName("FaixaAte");
           
            entityTypeBuilder.Property(x => x.Preco)
             .IsRequired()
             .HasColumnName("Preco");


            entityTypeBuilder.HasOne(x => x.Produto)
                .WithMany(x => x.FaixaEtaria)
                .HasForeignKey(x => x.IdProduto)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
