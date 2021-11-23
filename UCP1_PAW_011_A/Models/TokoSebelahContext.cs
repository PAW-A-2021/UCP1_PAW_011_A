using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_011_A.Models
{
    public partial class TokoSebelahContext : DbContext
    {
        public TokoSebelahContext()
        {
        }

        public TokoSebelahContext(DbContextOptions<TokoSebelahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableAdmin> TableAdmins { get; set; }
        public virtual DbSet<TablePembeli> TablePembelis { get; set; }
        public virtual DbSet<TableProduk> TableProduks { get; set; }
        public virtual DbSet<TableTransaksi> TableTransaksis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TableAdmin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Table_Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Admin");
            });

            modelBuilder.Entity<TablePembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("Table_Pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pembeli");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pembeli");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            modelBuilder.Entity<TableProduk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("Table_Produk");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Produk");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Produk");

                entity.Property(e => e.QuantityProduk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Quantity_Produk");
            });

            modelBuilder.Entity<TableTransaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Table_Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdPembeli).HasColumnName("ID_Pembeli");

                entity.Property(e => e.IdProduk).HasColumnName("ID_Produk");

                entity.Property(e => e.TotalTransaksi)
                    .HasColumnType("money")
                    .HasColumnName("Total_Transaksi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
