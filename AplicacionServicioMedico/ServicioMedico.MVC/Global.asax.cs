﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServicioMedico.MVC.Controllers;

namespace ServicioMedico.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_End()
        {
            //Application["Usuarios"] = (int) Application["Usuarios"] - 1;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["user"] = null;
        }
    }
}
