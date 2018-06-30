using Microsoft.EntityFrameworkCore;
using UsefulSites.DataAccess.Data;

namespace UsefulSites.DataAccess.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resource> Resource { get; set; }
        public DbSet<ResourceType> ResourceType { get; set; }
    }
}
