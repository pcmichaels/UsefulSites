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
                bool success = resourceTypeDataAccess.AddResourceType(
                    new ResourceType() { Name = "Test" });

                // Assert
                Assert.True(success);
            }
        }

    }
}
