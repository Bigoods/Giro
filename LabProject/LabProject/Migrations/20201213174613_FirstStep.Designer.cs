﻿// <auto-generated />
using System;
using LabProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabProject.Migrations
{
    [DbContext(typeof(LabProject_Context))]
    [Migration("20201213174613_FirstStep")]
    partial class FirstStep
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LabProject.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("LabProject.Models.Aviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("descricao");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("foto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("Aviso");
                });

            modelBuilder.Entity("LabProject.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LabProject.Models.ClienteAviso", b =>
                {
                    b.Property<int?>("AvisoId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.HasIndex("AvisoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cliente_aviso");
                });

            modelBuilder.Entity("LabProject.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("nome");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco");

                    b.Property<int?>("TipoPratoId")
                        .HasColumnType("int")
                        .HasColumnName("Tipo_PratoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoPratoId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("LabProject.Models.PratoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PratoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Prato_Cliente");
                });

            modelBuilder.Entity("LabProject.Models.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit")
                        .HasColumnName("aprovado");

                    b.Property<string>("DiaDescanso")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("dia_descanso");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("foto");

                    b.Property<string>("HoraAbertura")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("hora_abertura");

                    b.Property<string>("HoraFecho")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("hora_fecho");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("morada");

                    b.Property<int?>("Telefone")
                        .HasColumnType("int")
                        .HasColumnName("telefone");

                    b.Property<int?>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("LabProject.Models.RestauranteCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("RestauranteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Restaurante_Cliente");
                });

            modelBuilder.Entity("LabProject.Models.RestaurantePrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Dia")
                        .HasColumnType("date")
                        .HasColumnName("dia");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("foto");

                    b.Property<int?>("PratoId")
                        .HasColumnType("int");

                    b.Property<int?>("RestauranteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PratoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("Restaurante_Prato");
                });

            modelBuilder.Entity("LabProject.Models.TipoPrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("Tipo_Prato");
                });

            modelBuilder.Entity("LabProject.Models.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit")
                        .HasColumnName("bloqueado");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Motivo")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("motivo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.Property<bool>("Notificacao")
                        .HasColumnType("bit")
                        .HasColumnName("notificacao");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("LabProject.Models.Administrador", b =>
                {
                    b.HasOne("LabProject.Models.Utilizador", "Utilizador")
                        .WithMany("Administradors")
                        .HasForeignKey("UtilizadorId")
                        .HasConstraintName("FK__Administr__Utili__32E0915F");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("LabProject.Models.Cliente", b =>
                {
                    b.HasOne("LabProject.Models.Utilizador", "Utilizador")
                        .WithMany("Clientes")
                        .HasForeignKey("UtilizadorId")
                        .HasConstraintName("FK__Cliente__Utiliza__33D4B598");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("LabProject.Models.ClienteAviso", b =>
                {
                    b.HasOne("LabProject.Models.Aviso", "Aviso")
                        .WithMany()
                        .HasForeignKey("AvisoId")
                        .HasConstraintName("FK__Cliente_a__Aviso__4BAC3F29");

                    b.HasOne("LabProject.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Cliente_a__Clien__4AB81AF0");

                    b.Navigation("Aviso");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LabProject.Models.Prato", b =>
                {
                    b.HasOne("LabProject.Models.TipoPrato", "TipoPrato")
                        .WithMany("Pratos")
                        .HasForeignKey("TipoPratoId")
                        .HasConstraintName("FK__Prato__Tipo_Prat__628FA481");

                    b.Navigation("TipoPrato");
                });

            modelBuilder.Entity("LabProject.Models.PratoCliente", b =>
                {
                    b.HasOne("LabProject.Models.Cliente", "Cliente")
                        .WithMany("PratoClientes")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Prato_Pra__Clien__35BCFE0A");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LabProject.Models.Restaurante", b =>
                {
                    b.HasOne("LabProject.Models.Utilizador", "Utilizador")
                        .WithMany("Restaurantes")
                        .HasForeignKey("UtilizadorId")
                        .HasConstraintName("FK__Restauran__Utili__37A5467C");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("LabProject.Models.RestauranteCliente", b =>
                {
                    b.HasOne("LabProject.Models.Cliente", "Cliente")
                        .WithMany("RestauranteClientes")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Restauran__Clien__38996AB5");

                    b.HasOne("LabProject.Models.Restaurante", "Restaurante")
                        .WithMany("RestauranteClientes")
                        .HasForeignKey("RestauranteId")
                        .HasConstraintName("FK__Restauran__Resta__398D8EEE");

                    b.Navigation("Cliente");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("LabProject.Models.RestaurantePrato", b =>
                {
                    b.HasOne("LabProject.Models.Prato", "Prato")
                        .WithMany("RestaurantePratos")
                        .HasForeignKey("PratoId")
                        .HasConstraintName("FK__Restauran__Prato__693CA210");

                    b.HasOne("LabProject.Models.Restaurante", "Restaurante")
                        .WithMany("RestaurantePratos")
                        .HasForeignKey("RestauranteId")
                        .HasConstraintName("FK__Restauran__Resta__68487DD7");

                    b.Navigation("Prato");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("LabProject.Models.Cliente", b =>
                {
                    b.Navigation("PratoClientes");

                    b.Navigation("RestauranteClientes");
                });

            modelBuilder.Entity("LabProject.Models.Prato", b =>
                {
                    b.Navigation("RestaurantePratos");
                });

            modelBuilder.Entity("LabProject.Models.Restaurante", b =>
                {
                    b.Navigation("RestauranteClientes");

                    b.Navigation("RestaurantePratos");
                });

            modelBuilder.Entity("LabProject.Models.TipoPrato", b =>
                {
                    b.Navigation("Pratos");
                });

            modelBuilder.Entity("LabProject.Models.Utilizador", b =>
                {
                    b.Navigation("Administradors");

                    b.Navigation("Clientes");

                    b.Navigation("Restaurantes");
                });
#pragma warning restore 612, 618
        }
    }
}
