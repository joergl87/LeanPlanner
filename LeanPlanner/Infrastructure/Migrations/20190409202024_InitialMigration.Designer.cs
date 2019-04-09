﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LPContext))]
    [Migration("20190409202024_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Projekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnName("adresse");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnName("bezeichnung");

                    b.Property<string>("Kostenstelle")
                        .HasColumnName("kostenstelle");

                    b.Property<string>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("projekt");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Vorgang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Anfang")
                        .HasColumnName("anfang");

                    b.Property<DateTime>("Ende")
                        .HasColumnName("ende");

                    b.Property<int>("ProjektId")
                        .HasColumnName("projekt_id");

                    b.Property<string>("Zug")
                        .IsRequired()
                        .HasColumnName("zug");

                    b.HasKey("Id");

                    b.HasIndex("ProjektId");

                    b.ToTable("vorgang");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Vorgang", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Projekt", "Projekt")
                        .WithMany("Vorgänge")
                        .HasForeignKey("ProjektId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
