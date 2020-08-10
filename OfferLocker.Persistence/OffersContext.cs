using Microsoft.EntityFrameworkCore;
using OfferLocker.Entities.Offers;
using OfferLocker.Entities.Identity;
using OfferLocker.Entities.Commons;
using OfferLocker.Entities.Meetup;
using OfferLocker.Entities.Category;

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
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CampusCommunity> CampusCommunities { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Meetup> Meetups { get; set; }     
        public DbSet<Follow> Follow { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationsToUsers> NotificationToUsers { get; set; }
        public DbSet<SavedOffer> SavedOffers { get; set; }

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

            modelBuilder.Entity<OfferComment>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Photo>()
                .Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<University>()
                .HasMany<Faculty>(p => p.Faculties)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Faculty>()
                .HasMany<CampusCommunity>(p => p.CampusCommunities)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(p => p.Students)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<CampusCommunity>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<UserType>()
                .HasMany(p => p.Users)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Meetup>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Follow>()
                .HasOne(u => u.Followed)
                .WithMany(u => u.Followers)
                .HasForeignKey(u => u.IdUserFollowed)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Follow>()
               .HasOne(u => u.Follower)
               .WithMany(u => u.Following)
               .HasForeignKey(u => u.IdUserFollower)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasMany(u => u.ToUsers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notifications)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Offer>()
                .HasMany(u => u.Notifications)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Offer>()
                .HasMany(u => u.SavedOffers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.SavedOffers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
