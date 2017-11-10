using HEA.BFL;
using HEA.Model;
using HEA.WebAPIDemo.API.Interface;

namespace HEA.WebAPIDemo.API {
	public class AuthenticationService :IAuthenticationService
	{
		/// <summary>
		/// 根据用户手机号获得用户信息
		/// </summary>
		/// <param name="phone"></param>
		/// <returns></returns>
		public Users GetUserByPhone(string phone)
		{
			return UsersController.GetUserByPhone(phone);
		}

		/// <summary>
		/// 获得UserDevice
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="deviceType"></param>
		/// <returns></returns>
		public  UserDevice GetUserDevice(int userId, int deviceType)
		{
			return UsersController.GetUserDevice(userId, deviceType);
		}

		/// <summary>
		/// 添加UserDevice
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public bool AddUserDevice(UserDevice model)
		{
			return UsersController.AddUserDevice(model);
		}

		/// <summary>
		/// 更新UserDevice
		/// </summary>
		/// <param name="userSession"></param>
		/// <returns></returns>
		public bool UpdateUserDevice(UserDevice userSession)
		{
			return UsersController.UpdateUserDevice(userSession);
		}

		/// <summary>
		/// 根据sessionKey获得UserDevice
		/// </summary>
		/// <param name="sessionKey"></param>
		/// <returns></returns>
		public UserDevice GetUserDevice(string sessionKey)
		{
			return UsersController.GetUserDevice(sessionKey);
		}

		/// <summary>
		/// 根据userid 获得users
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public Users GetUser(int userId)
		{
			return UsersController.GetUserByUsersId(userId);
		}

		/// <summary>
		/// 根据IP地址获得GetUserDevice
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="deviceType"></param>
		/// <returns></returns>
		public UserDevice GetUserDevice(string ip, int deviceType)
		{
			return UsersController.GetUserDevice(ip, deviceType);
		}
	}
}