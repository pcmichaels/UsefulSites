using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.DataAccess.Api
{
    public class ResourceCategoryDataAccess : IResourceCategoryDataAccess
    {
        private ApplicationDbContext _applicationDbContext;

        public ResourceCategoryDataAccess(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public int AddCategory(string category)
        {
            ResourceCategory resourceCategory = new ResourceCategory()
            {
                Name = category
            };

            _applicationDbContext.ResourceCategories.Add(resourceCategory);
            _applicationDbContext.SaveChanges();

            return resourceCategory.Id;
        }

        public IEnumerable<ResourceCategory> GetAllCategories()
        {
            return _applicationDbContext.ResourceCategories;
        }
    }
}
