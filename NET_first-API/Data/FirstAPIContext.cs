using Microsoft.EntityFrameworkCore;
using NET_first_API.Models;
namespace NET_first_API.Data
{
    public class FirstAPIContext : DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Midnight Library",
                    Author = "Matt Haing",
                    YearPublished = 2023
                },
                new Book
                {
                    Id = 2,
                    Title = "Inside the Magic Bookstore",
                    Author = "Dr. James R.Doty",
                    YearPublished = 2016
                },
                new Book
                {
                    Id = 3,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    YearPublished = 1960
                }
            );
        }
        public DbSet<Book> Books { get; set; }
    }
}
