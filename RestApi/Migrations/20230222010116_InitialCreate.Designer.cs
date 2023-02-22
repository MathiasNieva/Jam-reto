﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RestApi.Migrations
{
    [DbContext(typeof(ArtistContext))]
    [Migration("20230222010116_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestApi.Models.ArtistModel", b =>
                {
                    b.Property<Guid>("ArtistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ArtistaId");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("RestApi.Models.ArtistaDiscoModel", b =>
                {
                    b.Property<Guid>("ArtistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiscoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistaId", "DiscoId");

                    b.HasIndex("DiscoId");

                    b.ToTable("ArtistaDisco");
                });

            modelBuilder.Entity("RestApi.Models.DiscoModel", b =>
                {
                    b.Property<Guid>("DiscoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscoId");

                    b.ToTable("Discos");
                });

            modelBuilder.Entity("RestApi.Models.ArtistaDiscoModel", b =>
                {
                    b.HasOne("RestApi.Models.ArtistModel", "Artista")
                        .WithMany("ArtistaDiscoModel")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestApi.Models.DiscoModel", "Disco")
                        .WithMany("ArtistaDiscoModel")
                        .HasForeignKey("DiscoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");

                    b.Navigation("Disco");
                });

            modelBuilder.Entity("RestApi.Models.ArtistModel", b =>
                {
                    b.Navigation("ArtistaDiscoModel");
                });

            modelBuilder.Entity("RestApi.Models.DiscoModel", b =>
                {
                    b.Navigation("ArtistaDiscoModel");
                });
#pragma warning restore 612, 618
        }
    }
}
