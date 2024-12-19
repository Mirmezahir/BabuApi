using Babu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Babu.DAL
{
    public class BabuDbContext : DbContext
    {
        public DbSet<Categories> categories { get; set; }
        public BabuDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
