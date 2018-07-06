using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UsefulSites.DataAccess.Data
{
    public class Resource : BaseDataEntity
    {
        public Resource()
        {

        }

        public Resource(string name, string description,
            ResourceType resourceType,
            ResourceCategory resourceCategory)
        {
            ResourceType = resourceType;
            Name = name;
            Description = description;
            ResourceCategory = resourceCategory;
        }

        public int ResourceTypeId { get; set; }

        [ForeignKey("ResourceTypeId")]
        public ResourceType ResourceType { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public int ResourceCategoryId { get; set; }

        [ForeignKey("ResourceCategoryId")]
        public ResourceCategory ResourceCategory { get; set; }
    }
}
