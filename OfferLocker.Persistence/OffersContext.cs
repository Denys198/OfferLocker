﻿using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Offers;
using OfferLocker.Entities.Identity;
using OfferLocker.Entities.Meetup;

namespace OfferLocker.Persistence
{
	public sealed class OffersContext : DbContext
	{
        public OffersContext(DbContextOptions<OffersContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Meetup> Meetups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .HasMany<OfferComment>(offer => offer.Comments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offer>()
                .HasMany<Photo>(offer => offer.Photos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offer>()
                .HasMany<Category>(offer => offer.Categories)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OfferComment>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Photo>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Meetup>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}