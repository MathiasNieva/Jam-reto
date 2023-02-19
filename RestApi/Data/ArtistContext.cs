using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

    public class ArtistContext : DbContext
    {
        public ArtistContext (DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public DbSet<RestApi.Models.ArtistModel> Artistas { get; set; } 
        public DbSet<RestApi.Models.DiscoModel> Discos { get; set; } 
        public DbSet<RestApi.Models.ArtistaDiscoModel> ArtistaDisco { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<ArtistaDiscoModel>(entity =>
            {
                entity.HasKey(ad => new {ad.ArtistaId, ad.DiscoId});

                entity.HasOne(a => a.Artista)
                    .WithMany(ad => ad.ArtistaDiscoModel)
                    .HasForeignKey(a => a.ArtistaId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(d => d.Disco)
                    .WithMany(ad => ad.ArtistaDiscoModel)
                    .HasForeignKey(d => d.DiscoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
