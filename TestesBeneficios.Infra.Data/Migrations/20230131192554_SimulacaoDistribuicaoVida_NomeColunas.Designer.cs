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
    [Migration("20230131192554_SimulacaoDistribuicaoVida_NomeColunas")]
    partial class SimulacaoDistribuicaoVida_NomeColunas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

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

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.EntidadeDeClasse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Apelido");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("NomeFantasia");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("RazaoSocial");

                    b.HasKey("Id");

                    b.ToTable("EntidadeDeClasses", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Abrangencia")
                        .HasColumnType("int")
                        .HasColumnName("Abrangencia");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Codigo");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.ProdutoAbrangencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("Abrangencia", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.ProdutoFaixaEtaria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FaixaAte")
                        .HasColumnType("int")
                        .HasColumnName("FaixaAte");

                    b.Property<int>("FaixaDe")
                        .HasColumnType("int")
                        .HasColumnName("FaixaDe");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Preco")
                        .HasColumnType("real")
                        .HasColumnName("Preco");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("FaixaEtaria", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Profissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Profissoes", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Simulacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AbrangenciaProduto")
                        .HasColumnType("int")
                        .HasColumnName("AbrangenciaProduto");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("Varchar(14)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Email");

                    b.Property<Guid?>("IdEntidadeDeClasse")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdProfissao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("IdEntidadeDeClasse");

                    b.HasIndex("IdProfissao");

                    b.ToTable("Simulacoes", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.SimulacaoAbrangencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<Guid>("IdSimulacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.HasIndex("IdSimulacao");

                    b.ToTable("SimulacaoAbrangencia", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.SimulacaoDistribuicaoVida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlcanceFinal")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("AlcanceFinal");

                    b.Property<string>("AlcanceInicial")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("AlcanceInicial");

                    b.Property<Guid>("IdSimulacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasColumnType("Varchar(14)")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("IdSimulacao");

                    b.ToTable("SimulacaoDistribuicaoVida", (string)null);
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestesBeneficios.Domain.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Produto", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Empresa", "Empresa")
                        .WithMany("Produtos")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.ProdutoAbrangencia", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Produto", "Produto")
                        .WithMany("Abrangencias")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.ProdutoFaixaEtaria", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Produto", "Produto")
                        .WithMany("FaixaEtaria")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Simulacao", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.EntidadeDeClasse", "EntidadeDeClasse")
                        .WithMany("Simulacoes")
                        .HasForeignKey("IdEntidadeDeClasse")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TestesBeneficios.Domain.Entidades.Profissao", "Profissao")
                        .WithMany("Simulacoes")
                        .HasForeignKey("IdProfissao")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("EntidadeDeClasse");

                    b.Navigation("Profissao");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.SimulacaoAbrangencia", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Simulacao", "Simulacao")
                        .WithMany("SimulacaoAbrangencia")
                        .HasForeignKey("IdSimulacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Simulacao");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.SimulacaoDistribuicaoVida", b =>
                {
                    b.HasOne("TestesBeneficios.Domain.Entidades.Simulacao", "Simulacao")
                        .WithMany("SimulacaoDistribuicaoVida")
                        .HasForeignKey("IdSimulacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Simulacao");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Empresa", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.EntidadeDeClasse", b =>
                {
                    b.Navigation("Simulacoes");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Produto", b =>
                {
                    b.Navigation("Abrangencias");

                    b.Navigation("FaixaEtaria");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Profissao", b =>
                {
                    b.Navigation("Simulacoes");
                });

            modelBuilder.Entity("TestesBeneficios.Domain.Entidades.Simulacao", b =>
                {
                    b.Navigation("SimulacaoAbrangencia");

                    b.Navigation("SimulacaoDistribuicaoVida");
                });
#pragma warning restore 612, 618
        }
    }
}