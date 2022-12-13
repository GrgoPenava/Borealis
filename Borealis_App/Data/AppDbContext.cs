using Borealis_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Borealis_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Zapisi> zapisi { get; set; }
    }
}
