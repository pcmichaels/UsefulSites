using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsefulSites.DataAccess.Data
{
    public class ResourceType : BaseDataEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
