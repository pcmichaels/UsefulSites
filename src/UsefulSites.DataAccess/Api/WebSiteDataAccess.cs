using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsefulSites.DataAccess.Data;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.DataAccess.Api
{
    public class WebSiteDataAccess : IWebSiteDataAccess
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WebSiteDataAccess(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public IList<Resource> GetAllWebSites()
        {
            return _applicationDbContext.Resource.Where(a => a.ResourceType.Id == 1).ToList();
        }

    }
}
