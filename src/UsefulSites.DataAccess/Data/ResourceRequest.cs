using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UsefulSites.DataAccess.Data
{
    public class ResourceRequest : BaseDataEntity
    {
        [Key]
        public int Id { get; set; }

        public int ResourceTypeId { get; set; }

        [ForeignKey("ResourceTypeId")]
        public ResourceType ResourceType { get; set; }


    }
}
