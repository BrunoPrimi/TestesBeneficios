﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesSimulacaoDistribuicaoVida : IEntityTypeConfiguration<SimulacaoDistribuicaoVida>
    {
        public void Configure(EntityTypeBuilder<SimulacaoDistribuicaoVida> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("SimulacaoDistribuicaoVida");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.AlcanceInicial)
                .IsRequired()
                .HasColumnName("AlcanceInicial")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.AlcanceFinal  )
                .IsRequired()
                .HasColumnName("AlcanceFinal")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Quantidade)
               .IsRequired()
               .HasColumnName("Quantidade")
               .HasColumnType($"Varchar({14})");


            entityTypeBuilder.HasOne(x => x.Simulacao)
                    .WithMany(x => x.SimulacaoDistribuicaoVida)
                    .HasForeignKey(x => x.IdSimulacao)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
