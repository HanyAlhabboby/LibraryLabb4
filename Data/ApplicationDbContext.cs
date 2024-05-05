using LibraryLabb4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryLabb4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet <Book> Books { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <BookCustomer> BookCustomers { get; set; }
    }
}
