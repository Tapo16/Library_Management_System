using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library_Management_System.Models
{
    public class ProjectContext : DbContext
    {

        public ProjectContext(DbContextOptions<ProjectContext> option): base(option)
        {

        }

        public DbSet<Admin> tblad { get; set; }

        public DbSet<Book> tblbook { get; set; }

        public DbSet<User> tbluser { get; set; }

        public DbSet<Category> tblcat { get; set; }
        public DbSet<BorrowedBooks> tblBorrwedBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Admin>().HasData(

                new Admin
                {
                    Email = "admin123@gmail.com",
                    Password = "Ad@123"
                },
                new Admin
                {
                    Email = "adminer456@gmail.com",
                    Password = "Ad@456"
                }
                );

            //// Category /////////
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CatName = "History"
                },
                new Category
                {
                    CategoryId = 2,
                    CatName = "Cultural"
                },
                new Category
                {
                    CategoryId = 3,
                    CatName = "Mythology"
                },
                 new Category
                {
                    CategoryId = 4,
                    CatName = "Self Improvement"
                }
                );
        }




    }
}
