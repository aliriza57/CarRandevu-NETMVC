using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GOKMENIMO.Models.DB
{
    public partial class GOKMENContext : DbContext
    {
        public GOKMENContext()
        {
        }

        public GOKMENContext(DbContextOptions<GOKMENContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-7GA78PI\\SQLEXPRESS;Database=GOKMEN;User Id=sa;Password=Password1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.Property(e => e.KullaniciAdi).HasMaxLength(50);

                entity.Property(e => e.Sifre).HasMaxLength(50);

                entity.Property(e => e.SoyAd).HasMaxLength(50);
            });

            modelBuilder.Entity<Randevu>(entity =>
            {
                entity.ToTable("Randevu");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Tell).HasMaxLength(11);

                entity.Property(e => e.WorkType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
