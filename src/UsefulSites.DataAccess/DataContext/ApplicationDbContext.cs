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

        public DbSet<ResourceRequest> ResourceRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResourceType>().HasData(new Data.ResourceType()
            {
                Id = 1,
                Name = "Web Site"                
            });
        }
    }
}
