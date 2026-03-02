using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.modelos;

namespace Repositorio
{
     

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =========================
        // DbSets
        // =========================

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<PolizaCobertura> PolizaCoberturas { get; set; }

        // =========================
        // Fluent API Configuration
        // =========================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // CLIENTE
            // =========================
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(c => c.Identificacion)
                      .IsUnique();

                entity.Property(c => c.Nombre)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(c => c.Identificacion)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(c => c.Correo)
                      .HasMaxLength(150)
                      .IsRequired();
            });

            // =========================
            // MARCA
            // =========================
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasIndex(m => m.Nombre)
                      .IsUnique();

                entity.Property(m => m.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();
            });

            // =========================
            // MODELO
            // =========================
            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasIndex(m => new { m.Nombre, m.MarcaId })
                      .IsUnique();

                entity.Property(m => m.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasOne(m => m.Marca)
                      .WithMany(m => m.Modelos)
                      .HasForeignKey(m => m.MarcaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // VEHICULO
            // =========================
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasIndex(v => v.Placa)
                      .IsUnique();

                entity.Property(v => v.Placa)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(v => v.ValorComercial)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(v => v.Modelo)
                      .WithMany(m => m.Vehiculos)
                      .HasForeignKey(v => v.ModeloId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // COBERTURA
            // =========================
            modelBuilder.Entity<Cobertura>(entity =>
            {
                entity.HasIndex(c => c.Nombre)
                      .IsUnique();

                entity.Property(c => c.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(c => c.MontoCobertura)
                      .HasColumnType("decimal(18,2)");
            });

            // =========================
            // POLIZA
            // =========================
            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasIndex(p => p.NumeroPoliza)
                      .IsUnique();

                entity.Property(p => p.NumeroPoliza)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(p => p.SumaAsegurada)
                      .HasColumnType("decimal(18,2)");

                entity.Property(p => p.PrimaTotal)
                      .HasColumnType("decimal(18,2)");

                entity.Property(p => p.FechaEmision)
                      .HasColumnType("datetime2");

                entity.HasOne(p => p.Cliente)
                      .WithMany(c => c.Polizas)
                      .HasForeignKey(p => p.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Vehiculo)
                      .WithMany(v => v.Polizas)
                      .HasForeignKey(p => p.VehiculoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // POLIZA COBERTURA (N:N)
            // =========================
            modelBuilder.Entity<PolizaCobertura>(entity =>
            {
                entity.HasKey(pc => new { pc.PolizaId, pc.CoberturaId });

                entity.HasOne(pc => pc.Poliza)
                      .WithMany(p => p.PolizaCoberturas)
                      .HasForeignKey(pc => pc.PolizaId);

                entity.HasOne(pc => pc.Cobertura)
                      .WithMany(c => c.PolizaCoberturas)
                      .HasForeignKey(pc => pc.CoberturaId);
            });
        }
    }
}

