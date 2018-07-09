

using System.Collections.Generic;

namespace UsefulSites.Web.Models
{
    public class ResourcesByTypeModel
    {
        public ResourceTypeModel ResourceTypeModel { get; set; }
        public List<ResourceModel> Resources { get; set; }             
    }
}
