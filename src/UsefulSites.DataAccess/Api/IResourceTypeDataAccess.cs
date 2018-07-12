using System.Collections.Generic;
using UsefulSites.DataAccess.Data;

namespace UsefulSites.DataAccess.Api
{
    public interface IResourceTypeDataAccess
    {
        IEnumerable<ResourceType> GetAllResourceTypes();
        bool AddResourceType(ResourceType resourceType);
    }
}
