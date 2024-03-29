﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestesBeneficios.Domain.Entidades;

namespace TestesBeneficios.Infra.Data.Configuracoes
{
    public class ConfiguracoesContratacao : IEntityTypeConfiguration<Contratacao>
    {
        public void Configure(EntityTypeBuilder<Contratacao> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Contratacoes");

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

            entityTypeBuilder.Property(x => x.CartaoSUS)
               .IsRequired()
               .HasColumnName("CartaoSUS")
               .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Celular)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType($"Varchar({100})");


            entityTypeBuilder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnName("Bairro")
                .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Uf)
              .IsRequired()
              .HasColumnName("Uf")
              .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Cep)
             .IsRequired()
             .HasColumnName("Cep")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Cidade)
             .IsRequired()
             .HasColumnName("Cidade")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Complemento)
             .IsRequired()
             .HasColumnName("Complemento")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.DataDeNacimento)
             .IsRequired()
             .HasColumnName("DataNacimento")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.EstadoCivil)
             .IsRequired()
             .HasColumnName("EstadoCivil")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.NomeDaMae)
             .IsRequired()
             .HasColumnName("NomeDaMae")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.DataExpedicaoRG)
             .IsRequired()
             .HasColumnName("DataExpedicaoRG")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Logradouro)
             .IsRequired()
             .HasColumnName("Logradouro")
             .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Rg)
            .IsRequired()
            .HasColumnName("Rg")
            .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.Numero)
            .IsRequired()
            .HasColumnName("Numero")
            .HasColumnType($"Varchar({100})");

            entityTypeBuilder.Property(x => x.OrgaoEmissor)
          .IsRequired()
          .HasColumnName("OrgaoEmissor")
          .HasColumnType($"Varchar({100})");

          
        }
    }
}
