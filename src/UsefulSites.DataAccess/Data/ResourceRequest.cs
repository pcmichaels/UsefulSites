using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UsefulSites.DataAccess.Data
{
    public class ResourceRequest : BaseDataEntity
    {

        public int ResourceTypeId { get; set; }

        [ForeignKey("ResourceTypeId")]
        public ResourceType ResourceType { get; set; }

        // ToDo: Link this to the user ID in the other context
        public int RequestorUserId { get; set; }
    }
}
