using HEA.Model;
using HEA.Model.Request;

namespace HEA.WebAPIDemo.API.Interface {
	/// <summary>
	/// 用户接口
	/// </summary>
	public interface IUsers
	{
		/// <summary>
		/// 根据用户ID获得用户信息
		/// </summary>
		/// <param name="id">用户ID</param>
		/// <returns>Users</returns>
		Users GetUserByUsersId(int id);

		/// <summary>
		/// 新用户注册
		/// </summary>
		/// <param name="modelUsers"></param>
		/// <returns>True or False</returns>
		ApiResult<bool> RegistrationNewUsers(Users modelUsers);

	}
}