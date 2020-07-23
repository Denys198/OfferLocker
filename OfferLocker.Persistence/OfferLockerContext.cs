using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfferLocker.Persistence
{
    public partial class OfferLockerContext : DbContext
    {
        public OfferLockerContext()
        {
        }

        public OfferLockerContext(DbContextOptions<OfferLockerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CampusCommunity> CampusCommunity { get; set; }
        public virtual DbSet<CampusCommunityReview> CampusCommunityReview { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<Meetup> Meetup { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<OfferReview> OfferReview { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCampusCommunity> UserCampusCommunity { get; set; }
        public virtual DbSet<UserMeetup> UserMeetup { get; set; }
        public virtual DbSet<UserReview> UserReview { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=OfferLocker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampusCommunity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Link).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.StudentsNumber).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.CampusCommunity)
                    .HasForeignKey(d => d.IdFaculty)
                    .HasConstraintName("FK_CampusCommunity_Faculty");

                entity.HasOne(d => d.IdUniversityNavigation)
                    .WithMany(p => p.CampusCommunity)
                    .HasForeignKey(d => d.IdUniversity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampusComunity_User");
            });

            modelBuilder.Entity<CampusCommunityReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Rate).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.IdCampusCommunityNavigation)
                    .WithMany(p => p.CampusCommunityReview)
                    .HasForeignKey(d => d.IdCampusCommunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampusCommunityReview_CampusCommunity");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.CampusCommunityReview)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampusCommunityReview_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdUniversityNavigation)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.IdUniversity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_University");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdUserFollowedNavigation)
                    .WithMany(p => p.FollowIdUserFollowedNavigation)
                    .HasForeignKey(d => d.IdUserFollowed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follow_User1");

                entity.HasOne(d => d.IdUserFollowerNavigation)
                    .WithMany(p => p.FollowIdUserFollowerNavigation)
                    .HasForeignKey(d => d.IdUserFollower)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follow_User");
            });

            modelBuilder.Entity<Meetup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCampusCommunityNavigation)
                    .WithMany(p => p.Meetup)
                    .HasForeignKey(d => d.IdCampusCommunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meetup_CampusCommunity");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Meetup)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meetup_User");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCampusCommunityNavigation)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.IdCampusCommunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_CampusCommunity");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_Category");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_User");
            });

            modelBuilder.Entity<OfferReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Rate).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.IdOfferNavigation)
                    .WithMany(p => p.OfferReview)
                    .HasForeignKey(d => d.IdOffer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferReview_Offer");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.OfferReview)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferReview_User");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnType("numeric(2, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Specialization).HasMaxLength(100);

                entity.Property(e => e.Year).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Faculty");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_User_Student");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserCampusCommunity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdCampusCommunityNavigation)
                    .WithMany(p => p.UserCampusCommunity)
                    .HasForeignKey(d => d.IdCampusCommunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCampusCommunity_CampusCommunity");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserCampusCommunity)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCampusCommunity_User");
            });

            modelBuilder.Entity<UserMeetup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdMeetupNavigation)
                    .WithMany(p => p.UserMeetup)
                    .HasForeignKey(d => d.IdMeetup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMeetup_Meetup");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserMeetup)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMeetup_User");
            });

            modelBuilder.Entity<UserReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Rate).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdReviewedNavigation)
                    .WithMany(p => p.UserReviewIdReviewedNavigation)
                    .HasForeignKey(d => d.IdReviewed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserReview_User1");

                entity.HasOne(d => d.IdReviewerNavigation)
                    .WithMany(p => p.UserReviewIdReviewerNavigation)
                    .HasForeignKey(d => d.IdReviewer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserReview_User");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
