using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.DataContext;
using Xunit;

namespace UsefulSites.Tests.DataAccess
{
    public class ResourceTypeDataAccessTest : BaseDataAccessTest
    {        
        
        [Fact]
        public void GetAllResourceTypes_ReturnsWebSites()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();

                IResourceTypeDataAccess resourceTypeDataAccess = new ResourceTypeDataAccess(context);

                // Act
                var resourceTypes = resourceTypeDataAccess.GetAllResources();

                // Assert
                Assert.Equal(3, resourceTypes.Count());                
            }
        }

    }
}
