using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsefulSites.Web.Models
{
    public class WebSiteModel : ResourceModel
    {
        public string Url { get; set; }

        public override string Name
        {
            get { return Url; }
            set { Url = value; }
        }
    }
}
