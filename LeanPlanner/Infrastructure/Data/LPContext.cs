using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class LPContext : DbContext
    {
        public LPContext(DbContextOptions<LPContext> options) : base(options)
        {
        }

        public DbSet<Projekt> Projekte { get; set; }
        public DbSet<Vorgang> Vorgänge { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Projekt>(ConfigureProjekt);
            builder.Entity<Vorgang>(ConfigureVorgang);

        }

        private void ConfigureProjekt(EntityTypeBuilder<Projekt> builder)
        {
            builder.ToTable("projekt");

            builder.Property(c => c.Id).HasColumnName("id");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Bezeichnung)
                .IsRequired()
                .HasColumnName("bezeichnung");
            builder.Property(p => p.Adresse)
                .IsRequired(false)
                .HasColumnName("adresse");
            builder.Property(p => p.Kostenstelle)
                .IsRequired(false)
                .HasColumnName("kostenstelle");
            builder.Property(p => p.Status)
                .IsRequired(false)
                .HasColumnName("status");
        }

        private void ConfigureVorgang(EntityTypeBuilder<Vorgang> builder)
        {
            builder.ToTable("vorgang");

            builder.Property(c => c.Id).HasColumnName("id");
            builder.HasKey(c => c.Id);
            builder.Property(p => p.ProjektId)
                .IsRequired()
                .HasColumnName("projekt_id");
            builder.Property(p => p.Zug)
                .IsRequired()
                .HasColumnName("zug");
            builder.Property(p => p.Anfang)
                .IsRequired()
                .HasColumnName("anfang");
            builder.Property(p => p.Ende)
                .IsRequired()
                .HasColumnName("ende");
            builder.HasOne(c => c.Projekt).WithMany(c => c.Vorgänge).HasForeignKey(c=>c.ProjektId);
        }
    }
}
