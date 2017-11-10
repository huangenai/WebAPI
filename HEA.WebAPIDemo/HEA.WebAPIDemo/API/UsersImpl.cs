using System.Web.Http;
using HEA.Model;
using HEA.WebAPIDemo.API.Interface;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo.API {
	[RoutePrefix("api/Users"), SessionValidate]
	public class UsersImpl:IUsers
	{
		/// <summary>
		/// 根据用户ID获得用户信息
		/// </summary>
		/// <param name="id">用户id</param>
		/// <returns>Users</returns>
		public Users GetUserByUsersId(int id)
		{
			return BFL.UsersController.GetUserByUsersId(id);
		}

		/// <summary>
		/// 新用户注册
		/// </summary>
		/// <param name="modelUsers">Users</param>
		/// <returns>True or False</returns>
		public ApiResult<bool>  RegistrationNewUsers(Users modelUsers)
		{
			return BFL.UsersController.RegistrationNewUsers(modelUsers);
		}

	}
}