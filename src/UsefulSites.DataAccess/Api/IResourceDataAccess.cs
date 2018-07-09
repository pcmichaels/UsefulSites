using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.Data;

namespace UsefulSites.DataAccess.Api
{
    public interface IResourceDataAccess
    {
        IEnumerable<Resource> GetAllWebSites();
        IEnumerable<Resource> GetCategoryWebSites(int categoryId);
        int CreateWebSite(int category, string siteName, string webSiteAddress);
        IEnumerable<Resource> GetResourceByType(int typeId);

    }
}
