using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Usuarios");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Senha)
               .IsRequired()
               .HasColumnName("Senha")
               .HasColumnType($"Varchar({100})");

            

        }
    }
}
