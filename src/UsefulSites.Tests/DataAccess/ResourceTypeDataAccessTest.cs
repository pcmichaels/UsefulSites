using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;
using Xunit;

namespace UsefulSites.Tests.DataAccess
{
    public class ResourceTypeDataAccessTest : BaseDataAccessTest
    {
        public ResourceTypeDataAccessTest() : base() { }

        [Fact]
        public void GetAllResourceTypes_NoResources_ReturnsNoResources()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                IResourceTypeDataAccess resourceTypeDataAccess = new ResourceTypeDataAccess(context);                

                // Act
                var resourceTypes = resourceTypeDataAccess.GetAllResourceTypes();

                // Assert
                Assert.Equal(0, resourceTypes.Count());                
            }
        }

        [Fact]
        public void AddResourceTypes_NoResources_AddsResource()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                IResourceTypeDataAccess resourceTypeDataAccess = new ResourceTypeDataAccess(context);

                // Act
                int count = resourceTypeDataAccess.AddResourceType(
                    new ResourceType() { Name = "Test" });

                // Assert
                Assert.Equal(1, count);
            }
        }

        [Fact]
        public void GetAllResourceTypes_ReturnsResources()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                IResourceTypeDataAccess resourceTypeDataAccess = new ResourceTypeDataAccess(context);
                resourceTypeDataAccess.AddResourceType(
                    new ResourceType() { Name = "test" });
                resourceTypeDataAccess.AddResourceType(
                    new ResourceType() { Name = "test2" });

                // Act
                var resourceTypes = resourceTypeDataAccess.GetAllResourceTypes();

                // Assert
                Assert.Equal(2, resourceTypes.Count());
                Assert.Equal("test", resourceTypes.First().Name);
            }
        }

    }
}
