using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LabProject.Models;

#nullable disable

namespace LabProject.Data
{
    public partial class LabProject_Database : DbContext
    {
        public LabProject_Database()
        {
        }

        public LabProject_Database(DbContextOptions<LabProject_Database> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Aviso> Avisos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteAviso> ClienteAvisos { get; set; }
        public virtual DbSet<Prato> Pratos { get; set; }
        public virtual DbSet<PratoCliente> PratoClientes { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<RestauranteCliente> RestauranteClientes { get; set; }
        public virtual DbSet<RestaurantePrato> RestaurantePratos { get; set; }
        public virtual DbSet<TipoPrato> TipoPratos { get; set; }
        public virtual DbSet<Utilizador> Utilizadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=LabProject_Database");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.Administradors)
                    .HasForeignKey(d => d.UtilizadorId)
                    .HasConstraintName("FK__Administr__Utili__32E0915F");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UtilizadorId)
                    .HasConstraintName("FK__Cliente__Utiliza__33D4B598");
            });

            modelBuilder.Entity<ClienteAviso>(entity =>
            {
                entity.HasOne(d => d.Aviso)
                    .WithMany()
                    .HasForeignKey(d => d.AvisoId)
                    .HasConstraintName("FK__Cliente_a__Aviso__4BAC3F29");

                entity.HasOne(d => d.Cliente)
                    .WithMany()
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Cliente_a__Clien__4AB81AF0");
            });

            modelBuilder.Entity<Prato>(entity =>
            {
                entity.HasOne(d => d.TipoPrato)
                    .WithMany(p => p.Pratos)
                    .HasForeignKey(d => d.TipoPratoId)
                    .HasConstraintName("FK__Prato__Tipo_Prat__628FA481");
            });

            modelBuilder.Entity<PratoCliente>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.PratoClientes)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Prato_Pra__Clien__35BCFE0A");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasOne(d => d.Utilizador)
                    .WithMany(p => p.Restaurantes)
                    .HasForeignKey(d => d.UtilizadorId)
                    .HasConstraintName("FK__Restauran__Utili__37A5467C");
            });

            modelBuilder.Entity<RestauranteCliente>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.RestauranteClientes)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Restauran__Clien__38996AB5");

                entity.HasOne(d => d.Restaurante)
                    .WithMany(p => p.RestauranteClientes)
                    .HasForeignKey(d => d.RestauranteId)
                    .HasConstraintName("FK__Restauran__Resta__398D8EEE");
            });

            modelBuilder.Entity<RestaurantePrato>(entity =>
            {
                entity.HasOne(d => d.Prato)
                    .WithMany(p => p.RestaurantePratos)
                    .HasForeignKey(d => d.PratoId)
                    .HasConstraintName("FK__Restauran__Prato__693CA210");

                entity.HasOne(d => d.Restaurante)
                    .WithMany(p => p.RestaurantePratos)
                    .HasForeignKey(d => d.RestauranteId)
                    .HasConstraintName("FK__Restauran__Resta__68487DD7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
