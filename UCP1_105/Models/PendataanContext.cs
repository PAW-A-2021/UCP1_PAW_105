using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCP1_105.Models
{
    public partial class PendataanContext : DbContext
    {
        public PendataanContext()
        {
        }

        public PendataanContext(DbContextOptions<PendataanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fakultas> Fakultas { get; set; }
        public virtual DbSet<Mahasiswa> Mahasiswa { get; set; }
        public virtual DbSet<MataKuliah> MataKuliah { get; set; }
        public virtual DbSet<Prodi> Prodi { get; set; }
        public virtual DbSet<Universitas> Universitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AS5OAOK;Database=Pendataan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fakultas>(entity =>
            {
                entity.HasKey(e => e.IdFakultas);

                entity.Property(e => e.IdFakultas)
                    .HasColumnName("Id_fakultas")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaFakultas)
                    .HasColumnName("Nama_fakultas")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mahasiswa>(entity =>
            {
                entity.HasKey(e => e.IdMahasiswa);

                entity.Property(e => e.IdMahasiswa)
                    .HasColumnName("Id_Mahasiswa")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdUniv)
                    .HasColumnName("Id_Univ")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaMahasiswa)
                    .HasColumnName("Nama_Mahasiswa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NimMahasiswa)
                    .HasColumnName("Nim_Mahasiswa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUnivNavigation)
                    .WithMany(p => p.Mahasiswa)
                    .HasForeignKey(d => d.IdUniv)
                    .HasConstraintName("FK_Mahasiswa_Universitas");
            });

            modelBuilder.Entity<MataKuliah>(entity =>
            {
                entity.HasKey(e => e.IdMatkul);

                entity.Property(e => e.IdMatkul)
                    .HasColumnName("Id_matkul")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KodeMatkul)
                    .HasColumnName("Kode_matkul")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamaMatkul)
                    .HasColumnName("Nama_matkul")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prodi>(entity =>
            {
                entity.HasKey(e => e.IdProdi);

                entity.Property(e => e.IdProdi)
                    .HasColumnName("Id_Prodi")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdMatkul)
                    .HasColumnName("Id_matkul")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaProdi)
                    .HasColumnName("Nama_Prodi")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMatkulNavigation)
                    .WithMany(p => p.Prodi)
                    .HasForeignKey(d => d.IdMatkul)
                    .HasConstraintName("FK_Prodi_MataKuliah");
            });

            modelBuilder.Entity<Universitas>(entity =>
            {
                entity.HasKey(e => e.IdUniv);

                entity.Property(e => e.IdUniv)
                    .HasColumnName("Id_Univ")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdFakultas)
                    .HasColumnName("Id_Fakultas")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdProdi)
                    .HasColumnName("Id_Prodi")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NamaUniv)
                    .HasColumnName("Nama_Univ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFakultasNavigation)
                    .WithMany(p => p.Universitas)
                    .HasForeignKey(d => d.IdFakultas)
                    .HasConstraintName("FK_Universitas_Fakultas");

                entity.HasOne(d => d.IdProdiNavigation)
                    .WithMany(p => p.Universitas)
                    .HasForeignKey(d => d.IdProdi)
                    .HasConstraintName("FK_Universitas_Prodi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
