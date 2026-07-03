using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BelediyeSikayet.Models;

public partial class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cevap> Cevaps { get; set; }

    public virtual DbSet<Durum> Durums { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Sikayet> Sikayets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BelediyeSikayetDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cevap>(entity =>
        {
            entity.HasKey(e => e.CevapId).HasName("PK__Cevap__7A11B5445C3CBFDD");

            entity.ToTable("Cevap");

            entity.Property(e => e.CevapTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Sikayet).WithMany(p => p.Cevaps)
                .HasForeignKey(d => d.SikayetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cevap__SikayetId__2F10007B");
        });

        modelBuilder.Entity<Durum>(entity =>
        {
            entity.HasKey(e => e.DurumId).HasName("PK__Durum__E6B16D0493C0C045");

            entity.ToTable("Durum");

            entity.Property(e => e.Ad).HasMaxLength(50);
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC72804C8E88");

            entity.ToTable("Kategori");

            entity.Property(e => e.Ad).HasMaxLength(100);
        });

        modelBuilder.Entity<Sikayet>(entity =>
        {
            entity.HasKey(e => e.SikayetId).HasName("PK__Sikayet__5E292AE21C7F44AB");

            entity.ToTable("Sikayet");

            entity.Property(e => e.AdSoyad).HasMaxLength(100);
            entity.Property(e => e.Baslik).HasMaxLength(200);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Ilce).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(20);

            entity.HasOne(d => d.Durum).WithMany(p => p.Sikayets)
                .HasForeignKey(d => d.DurumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sikayet__DurumId__2B3F6F97");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Sikayets)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sikayet__Kategor__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
