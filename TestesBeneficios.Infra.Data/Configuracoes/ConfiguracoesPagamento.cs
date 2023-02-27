using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesPagameto: IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Pagamentos");

            entityTypeBuilder.HasKey(x => x.Id);

           

            

        }
    }
}
