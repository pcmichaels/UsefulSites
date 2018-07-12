using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.DataAccess.Api
{
    public class ResourceTypeDataAccess : IResourceTypeDataAccess
    {
        private ApplicationDbContext _context;

        public ResourceTypeDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddResourceType(ResourceType resourceType)
        {
            _context.ResourceTypes.Add(resourceType);
            return _context.SaveChanges();

        }

        public IEnumerable<ResourceType> GetAllResourceTypes()
        {
            return _context.ResourceTypes;
        }
    }
}
