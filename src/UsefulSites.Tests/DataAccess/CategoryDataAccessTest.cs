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
    public class CategoryDataAccessTest : BaseDataAccessTest
    {

        public CategoryDataAccessTest() : base() { }

        [Fact]
        public void AddCategory_AddsCategory()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                IResourceCategoryDataAccess categoryDataAccess = new ResourceCategoryDataAccess(context);

                // Act
                int result = categoryDataAccess.AddCategory("TestCategory");

                // Assert                
                Assert.Equal("TestCategory", context.ResourceCategories.First().Name);                
            }
        }
    }
}