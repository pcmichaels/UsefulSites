﻿using System;
using System.Collections.Generic;
using System.Text;
using UsefulSites.DataAccess.Data;

namespace UsefulSites.DataAccess.Api
{
    public interface ICategoryDataAccess
    {
        IEnumerable<ResourceCategory> GetCategories();
    }
}
