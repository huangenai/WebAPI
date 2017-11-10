using System.Web;
using System.Web.Mvc;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo {
	public class FilterConfig {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
			////监控引用
			//filters.Add(new WebApiTrackerAttribute());
		}
	}
}
