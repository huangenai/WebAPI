using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo {
	public class WebApiApplication : System.Web.HttpApplication {
		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			GlobalConfiguration.Configuration.Filters.Add(new WebApiTrackerAttribute());
		   // log4net.Config.XmlConfigurator.Configure(
		   //	new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\log4net.config")
		   //);
		}

	}
}
