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

            entityTypeBuilder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Cpf)
               .IsRequired()
               .HasColumnName("Cpf")
               .HasColumnType($"Varchar({14})");

            entityTypeBuilder.Property(x => x.AbrangenciaProduto)
               .IsRequired(false)
               .HasColumnName("AbrangenciaProduto")
               .HasColumnType($"int");

            entityTypeBuilder.HasOne(x => x.Profissao)
                .WithMany(x => x.Simulacoes)
                .HasForeignKey(x => x.IdProfissao)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            entityTypeBuilder.HasOne(x => x.EntidadeDeClasse)
                .WithMany(x => x.Simulacoes)
                .HasForeignKey(x => x.IdEntidadeDeClasse)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
