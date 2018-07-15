using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;
using Xunit;

namespace UsefulSites.Tests.DataAccess
{
    public class ResourceWebSiteDataAccessTest : BaseDataAccessTest
    {
        public ResourceWebSiteDataAccessTest() : base() { }

        [Fact]
        public void GetWebSite_ReturnsSite()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();

                AddResourceTypes(context);
                AddCategories(context);

                var site1 = context.Resources.Add(new Resource("test", "test",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)));
                var site2 = context.Resources.Add(new Resource("test2", "test2",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)));
                context.SaveChanges();

                IResourceDataAccess webSiteDataAccess = new ResourceDataAccess(context);

                // Act
                Resource webSite = webSiteDataAccess.GetWebSite(site1.Entity.Id);

                // Assert
                Assert.Equal("test", webSite.Name);
                Assert.Equal(site1.Entity.Id, webSite.Id);
            }
        }

        [Fact]
        public void GetAllWebSites_ReturnsWebSites()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();

                AddResourceTypes(context);
                AddCategories(context);

                context.Resources.AddRange(
                    new Resource("test", "test",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)),
                    new Resource("test2", "test2",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)),
                    new Resource("test3", "test3",
                        context.ResourceTypes.First(a => a.Id == 2),
                        context.ResourceCategories.First(a => a.Id == 1)),
                    new Resource("test3", "test3",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 2))
                );
                context.SaveChanges();

                IResourceDataAccess webSiteDataAccess = new ResourceDataAccess(context);

                // Act
                var webSites = webSiteDataAccess.GetAllWebSites();

                // Assert
                Assert.Equal(3, webSites.Count());
                Assert.Equal("test", webSites.First().Name);
            }
        }

        private static void AddResourceTypes(ApplicationDbContext context)
        {
            context.ResourceTypes.AddRange(
                new ResourceType() { Id = 1, Name = "Web Sites" },
                new ResourceType() { Id = 2, Name = "Utilities / Tools" },
                new ResourceType() { Id = 3, Name = "Videos" }
            );
            context.SaveChanges();
        }

        private static void AddCategories(ApplicationDbContext context)
        {
            context.ResourceCategories.AddRange(
                new ResourceCategory() { Id = 1, Name = "Programming / Development" },
                new ResourceCategory() { Id = 2, Name = "Social" },
                new ResourceCategory() { Id = 3, Name = "Blogs" });

            context.SaveChanges();
        }

        [Fact]
        public void GetCategoryWebSites_ReturnsWebSites()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();

                AddResourceTypes(context);
                AddCategories(context);

                context.Resources.AddRange(
                    new Resource("test", "test",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)),
                    new Resource("test2", "test2",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 1)),
                    new Resource("test3", "test2",
                        context.ResourceTypes.First(a => a.Id == 1),
                        context.ResourceCategories.First(a => a.Id == 2)),                    
                    new Resource("test4", "test3",
                        context.ResourceTypes.First(a => a.Id == 2),
                        context.ResourceCategories.First(a => a.Id == 2))                    
                );
                context.SaveChanges();

                var webSiteDataAccess = new ResourceDataAccess(context);

                // Act
                var webSites = webSiteDataAccess.GetCategoryWebSites(1);

                // Assert
                Assert.Equal(2, webSites.Count());
                Assert.Equal("Programming / Development", webSites.First().ResourceCategory.Name);
            }
        }

    }
}
