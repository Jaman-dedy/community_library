/// <summary>
/// Represents the database context for the Community Library system.
/// This class is responsible for configuring the database connection and mapping entities to database tables.
/// It also defines the relationships between entities using Fluent API in the OnModelCreating method.
/// </summary>

using CommunityLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options) {}

        public DbSet<Book> Books {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Reservation> Reservations {get; set;}
        public DbSet<Review> Reviews {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reservations)
            .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId);
        }
    }
}