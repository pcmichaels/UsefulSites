using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulSites.DataAccess.Api
{
    public interface IResourceCategoryDataAccess
    {
        int AddCategory(string categoryName);
    }
}
