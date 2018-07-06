﻿using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Resource> GetAllWebSites()
        {
            return _applicationDbContext.Resources
                .Where(a => a.ResourceType.Id == 1).ToList();
        }

        public IEnumerable<Resource> GetCategoryWebSites(int categoryId)
        {
            return _applicationDbContext.Resources
                .Where(a => a.ResourceType.Id == 1
                && a.ResourceCategoryId == categoryId).ToList();
        }
    }
}
