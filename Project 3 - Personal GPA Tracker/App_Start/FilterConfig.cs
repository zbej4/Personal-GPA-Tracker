﻿using System.Web;
using System.Web.Mvc;

namespace Project_3___Personal_GPA_Tracker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters (GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
