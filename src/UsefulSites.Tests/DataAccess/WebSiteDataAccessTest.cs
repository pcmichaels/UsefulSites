using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;
using Xunit;

namespace UsefulSites.Tests
{
    public class WebSiteDataAccessTest
    {
        [Fact]
        public void GetAllWebSites_ReturnsWebSites()
        {
            // Arrange
            var options = 
                new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            var context = new ApplicationDbContext(options);            
            context.ResourceType.AddRange(
                new ResourceType() { Id = 1, Name = "website" },
                new ResourceType() { Id = 2, Name = "utility" }
            );
            context.SaveChanges();

            context.Resource.AddRange(
                new Resource { Id = 1, Name = "test", Description = "test",
                    ResourceType = context.ResourceType.First(a => a.Id == 1) },
                new Resource { Id = 2, Name = "test2", Description = "test2",
                    ResourceType = context.ResourceType.First(a => a.Id == 1) },
                new Resource { Id = 3, Name = "test3", Description = "test2",
                    ResourceType = context.ResourceType.First(a => a.Id == 1) },
                new Resource { Id = 4, Name = "test4", Description = "test3",
                    ResourceType = context.ResourceType.First(a => a.Id == 2)}
            );
            context.SaveChanges();

            var webSiteDataAccess = new WebSiteDataAccess(context);

            // Act
            var webSites = webSiteDataAccess.GetAllWebSites();

            // Assert
            Assert.Equal(3, webSites.Count());
            Assert.Equal(1, webSites.First().Id);

        }
    }
}
