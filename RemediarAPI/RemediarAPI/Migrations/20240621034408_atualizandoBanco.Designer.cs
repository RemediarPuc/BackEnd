﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RemediarAPI.Context;

#nullable disable

namespace RemediarAPI.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20240621034408_atualizandoBanco")]
    partial class atualizandoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RemediarAPI.Models.Doacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dtRetirada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("nomeMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtdCaixas")
                        .HasColumnType("int");

                    b.Property<int>("qtdMg")
                        .HasColumnType("int");

                    b.Property<string>("statusDoacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.Property<double>("valorDoacao")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("usuarioId");

                    b.ToTable("Doacoes");
                });

            modelBuilder.Entity("RemediarAPI.Models.EmissaoRelatorios", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double?>("valorTotalDoacao")
                        .HasColumnType("float");

                    b.Property<double?>("valorTotalMes")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("emissaoRelatorios");
                });

            modelBuilder.Entity("RemediarAPI.Models.HistoricoDeDoadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtdTotal")
                        .HasColumnType("int");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("historicoDeDoadores");
                });

            modelBuilder.Entity("RemediarAPI.Models.Medicamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dtVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nomeMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<string>("unidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("RemediarAPI.Models.MedicamentoDescartado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("EmissaoRelatoriosid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dtDescarte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dtVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nomeMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qtdDescartada")
                        .HasColumnType("int");

                    b.Property<double>("valorDescartado")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("EmissaoRelatoriosid");

                    b.ToTable("MedicamentosDescartados");
                });

            modelBuilder.Entity("RemediarAPI.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<string>("dosagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeMedicamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<string>("statusPedido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usoContinuo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.Property<double>("valorPedido")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("usuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RemediarAPI.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("escolaridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("faixaEtaria")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numPessoaCasa")
                        .HasColumnType("int");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("regiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rendaFamiliar")
                        .HasColumnType("float");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("RemediarAPI.Models.Doacao", b =>
                {
                    b.HasOne("RemediarAPI.Models.Usuario", "Usuario")
                        .WithMany("Doacoes")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RemediarAPI.Models.MedicamentoDescartado", b =>
                {
                    b.HasOne("RemediarAPI.Models.EmissaoRelatorios", null)
                        .WithMany("medicamentoDescartados")
                        .HasForeignKey("EmissaoRelatoriosid");
                });

            modelBuilder.Entity("RemediarAPI.Models.Pedido", b =>
                {
                    b.HasOne("RemediarAPI.Models.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RemediarAPI.Models.EmissaoRelatorios", b =>
                {
                    b.Navigation("medicamentoDescartados");
                });

            modelBuilder.Entity("RemediarAPI.Models.Usuario", b =>
                {
                    b.Navigation("Doacoes");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}