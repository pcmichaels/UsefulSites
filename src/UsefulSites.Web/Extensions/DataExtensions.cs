using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.DataAccess.Data;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.Extensions
{
    public static class DataExtensions
    {
        public static IEnumerable<CategoryModel> ToCategoryModels(this IEnumerable<ResourceCategory> resourceCategories)
        {
            var categoryModels = resourceCategories
                .Select(a => new CategoryModel()
                {
                    CategoryName = a.Name,
                    Id = a.Id
                });

            return categoryModels;
        }

        public static ResourceModel ToResourceModel(this Resource resource)
        {
            var resourceModel = new ResourceModel()
            {
                Name = resource.Name,
                Description = resource.Description
            };

            return resourceModel;
        }

    }
}
