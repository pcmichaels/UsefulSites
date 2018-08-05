using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Interfaces;

namespace UsefulSites.Web.Models
{
    public class WebSiteModel : ResourceModel, ISearchResult
    {
        [Display(Name = "Address")]
        public string Url { get; set; }

        [Display(Name = "Description")]
        public override string Description { get; set; }

        public override string Name
        {
            get { return Url; }
            set { Url = value; }
        }
    }
}
