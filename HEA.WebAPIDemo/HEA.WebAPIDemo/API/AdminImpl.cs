using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HEA.Model;
using HEA.WebAPIDemo.API.Interface;

namespace HEA.WebAPIDemo.API {
	public class AdminImpl:IAdmin
	{
		/// <summary>
		/// 根据用户ID用户改变用户状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="statu"></param>
		/// <returns></returns>
		public ApiResult<Users> UpdataUser(int id, bool statu) {
			return BFL.UsersController.UpdataUser(id, statu);
		}

		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="id">用户id</param>
		/// <returns>True or False</returns>
		public ApiResult<bool> DeleteUser(int id) {
			return BFL.UsersController.DeleteUser(id);
		}
	}
}