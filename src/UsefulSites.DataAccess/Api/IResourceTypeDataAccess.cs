using System.Collections.Generic;
using UsefulSites.DataAccess.Data;

namespace UsefulSites.DataAccess.Api
{
    public interface IResourceTypeDataAccess
    {
        IEnumerable<ResourceType> GetAllResourceTypes();
    }
}
