using LibraryPro1.Models;
using LibreryPro1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPro1.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
        public DbSet<Rack> Racks { get; set; }
    }
}