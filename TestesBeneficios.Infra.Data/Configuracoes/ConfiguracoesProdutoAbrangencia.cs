using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesProdutoAbrangencia : IEntityTypeConfiguration<ProdutoAbrangencia>
    {
        public void Configure(EntityTypeBuilder<ProdutoAbrangencia> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Abrangencia");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("Cidade");


            entityTypeBuilder.Property(x => x.UF)
                .IsRequired()
                .HasColumnName("UF");
           
          

            entityTypeBuilder.HasOne(x => x.Produto)
                .WithMany(x => x.Abrangencias)
                .HasForeignKey(x => x.IdProduto)
                .OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
