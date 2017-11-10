using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using HEA.Model;
using HEA.WebAPIDemo.API;
using HEA.WebAPIDemo.API.Interface;

namespace HEA.WebAPIDemo.Common
{
    public class SessionValidateAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public const string SessionKeyName = "SessionKey";
		public const string LogonUserName = "LogonUser";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var qs = HttpUtility.ParseQueryString(filterContext.Request.RequestUri.Query);
            string sessionKey = qs[SessionKeyName];

            if (string.IsNullOrEmpty(sessionKey))
            {
				throw new ApiException("无效 Session.", "InvalidSession");
            }

			IAuthenticationService authenticationService = new AuthenticationService();//IocManager.Intance.Reslove<IAuthenticationService>();

            //验证用户session
            var userSession = authenticationService.GetUserDevice(sessionKey);

            if (userSession == null)
            {
                throw new ApiException("无此 sessionKey", "RequireParameter_sessionKey");
            }
            else
            {
                //todo: 加Session是否过期的判断
                if (userSession.ExpiredTime < DateTime.UtcNow)
                    throw new ApiException("session已过期", "SessionTimeOut");

                var logonUser = authenticationService.GetUser(userSession.UserId);
                if (logonUser != null)
                {
                    filterContext.ControllerContext.RouteData.Values[LogonUserName] = logonUser;
                    SetPrincipal(new UserPrincipal<int>(logonUser));
                }
                userSession.ActiveTime = DateTime.UtcNow;
                userSession.ExpiredTime = DateTime.UtcNow.AddMinutes(60);
                authenticationService.UpdateUserDevice(userSession);
            }
        }

        public static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}