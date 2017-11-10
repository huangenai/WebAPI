using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HEA.Model;

namespace HEA.WebAPIDemo.API.Interface {
	/// <summary>
	/// 管理员接口
	/// </summary>
	public interface IAdmin 
	{
		/// <summary>
		/// 根据用户ID用户改变用户状态
		/// </summary>
		/// <param name="id">用户id</param>
		/// <param name="statu">用户状态</param>
		/// <returns>Users</returns>
		ApiResult<Users> UpdataUser(int id, bool statu);


		/// <summary>
		/// 删除用户
		/// </summary>
		/// <param name="id">用户id</param>
		/// <returns>True or Flase</returns>
		ApiResult<bool> DeleteUser(int id);

	}
}