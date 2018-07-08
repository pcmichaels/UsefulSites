using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.DataAccess.Api
{
    public class ResourceCategoryDataAccess : IResourceCategoryDataAccess
    {
        private ApplicationDbContext applicationDbContext;

        public ResourceCategoryDataAccess(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int AddCategory(string v)
        {
            throw new NotImplementedException();
        }
    }
}
