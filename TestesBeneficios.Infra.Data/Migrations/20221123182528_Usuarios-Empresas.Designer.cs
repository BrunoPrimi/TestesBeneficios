﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestesBeneficios.Infra.Data.Context;

#nullable disable

namespace TestesBeneficios.Infra.Data.Migrations
{
    [DbContext(typeof(TesteContext))]
    [Migration("20221123182528_Usuarios-Empresas")]
    partial class UsuariosEmpresas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Beneficiario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("Varchar(14)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeMae")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("NomeMae");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("Varchar(30)")
                        .HasColumnName("Rg");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Beneficiarios", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("NomeFantasia");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("RazaoSocial");

                    b.HasKey("Id");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
