using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestWebApp2.Models
{
    public partial class testbasedbContext : DbContext
    {
        public testbasedbContext()
        {
        }

        public testbasedbContext(DbContextOptions<testbasedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=den1.mssql8.gear.host;Initial Catalog=testbasedb;user id=testbasedb;password=Wn0Kb1Bd3~Q_;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Companies__Owner__3E52440B");
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
