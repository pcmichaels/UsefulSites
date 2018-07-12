using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.Tests.DataAccess
{
    public class BaseDataAccessTest
    {
        protected DbContextOptions<ApplicationDbContext> _options;

        public BaseDataAccessTest()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()                
                .Options;
        }
    }
}
