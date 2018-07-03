using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
                Id = (int)ResourceTypeEnum.WebSite,
                Name = "Web Site",                
                CreatedDate = new DateTime(2018, 07, 03),
                UpdatedDate = new DateTime(2018, 07, 03)
            });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseDataEntity))))
            {
                modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        x.Property("CreatedDate")
                            .HasDefaultValueSql("getutcdate()");
                        x.Property("UpdatedDate")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }
        }
    }
}
