using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HEA.Model;
using HEA.WebAPIDemo.API;
using HEA.WebAPIDemo.API.Interface;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/Admin"), SessionValidateAdmin, WebApiTracker] 
    public class AdminController : ApiController
    {
		private readonly IAdmin _admin = new AdminImpl();
		/// <summary>
		/// 根据用户ID改变用户状态(更新数据)
		/// </summary>
		/// <param name="sessionKey">sessionKey</param>
		/// <param name="id">用户id</param>
		/// <param name="state">用户状态</param>
		/// <returns>Users</returns>
		[HttpPost, Route("api/UpdataUserstatu")]
		public ApiResult<Users> UpdataUser(string sessionKey, int id, bool state) {
			 return _admin.UpdataUser(id, state);
		}

		/// <summary>
		/// 删除用户（删除数据）
		/// </summary>
		/// <param name="sessionKey"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, Route("api/DeleteUser")]
		public ApiResult<bool> DeletcUser(string sessionKey, int id) {
			return  _admin.DeleteUser(id);
		}

    }
}
