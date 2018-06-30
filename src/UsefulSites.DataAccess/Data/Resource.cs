using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UsefulSites.DataAccess.Data
{
    public class Resource
    {        
        public int Id { get; set; }

        public int ResourceTypeId { get; set; }

        [ForeignKey("ResourceTypeId")]
        public ResourceType ResourceType { get; set; } 

        public string Name { get; set; }
    }
}
