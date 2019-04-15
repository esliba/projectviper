using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectViper.Models
{
    public partial class ProyectoViperContext : DbContext
    {
        public ProyectoViperContext()
        {
        }

        public ProyectoViperContext(DbContextOptions<ProyectoViperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Board { get; set; }
        public virtual DbSet<QContainer> QContainer { get; set; }
        public virtual DbSet<QOption> QOption { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KEKO-PC\\SQLEXPRESS;Database=ProyectoViper;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Board)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_Board_Theme");
            });

            modelBuilder.Entity<QContainer>(entity =>
            {
                entity.ToTable("QContainer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.QContainer)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_QContainer_Theme");
            });

            modelBuilder.Entity<QOption>(entity =>
            {
                entity.ToTable("QOption");

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.QContainerId).HasColumnName("QContainerId");

                entity.Property(e => e.QOptionId).HasColumnName("QOptionId");

                entity.Property(e => e._Question)
                    .IsRequired()
                    .HasColumnName("Question")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.QContainer)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QContainerId)
                    .HasConstraintName("FK_Question_QContainer");

                entity.HasOne(d => d.QOption)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QOptionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Question_QOption");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
