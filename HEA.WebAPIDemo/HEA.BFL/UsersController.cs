using System;
using System.Runtime.InteropServices;
using HEA.Model;
using JCE.Dapper.Sql;

namespace HEA.BFL {
	public class UsersController 
	{
		private static readonly BaseBll Bll = new BaseBll();

		#region  Account验证
		/// <summary>
		/// 根据用户ID，设备号获得UserDevice
		/// </summary>
		/// <param name="userId">用户ID</param>
		/// <param name="deviceType">设备号</param>
		/// <returns>UserDevice</returns>
		public static UserDevice GetUserDevice(int userId, int deviceType)
		{
			var getUserDevice = Bll.GetQuery<UserDevice>()
				.AndWhere(x => x.UserId, OperationMethod.Equal, userId)
				.AndWhere(x => x.DeviceType, OperationMethod.Equal, deviceType)
				.AndWhere(x => x.ExpiredTime, OperationMethod.GreaterThanEqual, DateTime.UtcNow);
			var userDeviceModle = Bll.GetModel<UserDevice>(getUserDevice);
			if (userDeviceModle == null) { return null; }
			else return userDeviceModle;
		}

		/// <summary>
		/// 根据ip，设备号获得UserDevice
		/// </summary>
		/// <param name="ip">ip</param>
		/// <param name="deviceType">设备号</param>
		/// <returns>result</returns>
		public static UserDevice GetUserDevice(string ip, int deviceType) {
			var getUserDevice = Bll.GetQuery<UserDevice>()
				.AndWhere(x => x.IP, OperationMethod.Equal, ip)
				.AndWhere(x => x.DeviceType, OperationMethod.Equal, deviceType)
				.AndWhere(x => x.ExpiredTime, OperationMethod.GreaterThanEqual, DateTime.UtcNow);
			var userDeviceModle = Bll.GetModel<UserDevice>(getUserDevice);
			if (userDeviceModle == null) { return null; }
			else return userDeviceModle;
		}

		/// <summary>
		/// 新增UserDevice信息
		/// </summary>
		/// <param name="model">UserDevice</param>
		/// <returns>True or False</returns>
		public static bool AddUserDevice(UserDevice model)
		{
			return Bll.Add(model);
		}

		/// <summary>
		/// 更新UserDevice信息
		/// </summary>
		/// <param name="userSession">UserDevice</param>
		/// <returns>True or False</returns>
		public static bool UpdateUserDevice(UserDevice userSession)
		{
			return Bll.Update(userSession);
		}

		/// <summary>
		/// 根据sessionKey获得UserDevice
		/// </summary>
		/// <param name="sessionKey">sessionKey</param>
		/// <returns>UserDevice</returns>
		public static UserDevice GetUserDevice(string sessionKey)
		{
			var getUserDevicesql = Bll.GetQuery<UserDevice>().AndWhere(x => x.SessionKey, OperationMethod.Equal, sessionKey);
			var userDevicesqlModel = Bll.GetModel<UserDevice>(getUserDevicesql);
			if (userDevicesqlModel == null) { return null; }
			else return userDevicesqlModel;
		}

		/// <summary>
		/// 根据用户ID获得用户信息
		/// </summary>
		/// <param name="id">用户Id</param>
		/// <returns>Users</returns>
		public static Users GetUserByUsersId(int id)
		{
			var getUsers = Bll.GetQuery<Users>().AndWhere(x => x.UserId, OperationMethod.Equal, id);
			var usersModel = Bll.GetModel<Users>(getUsers);
			if (usersModel == null){return null;}
			else return usersModel;
		}
		/// <summary>
		/// 获得用户信息根据用户phone
		/// </summary>
		/// <param name="phone">用户手机号</param>
		/// <returns>用户表</returns>
		public static Users GetUserByPhone(string phone)
		{
			var getUser = Bll.GetQuery<Users>().AndWhere(x => x.Phone, OperationMethod.Equal, phone);
			var userModel = Bll.GetModel<Users>(getUser);
			return userModel;
		}
		#endregion


		/// <summary>
		/// 新用户注册
		/// </summary>
		/// <param name="modelUsers">Users</param>
		/// <returns>True or False</returns>
		public static ApiResult<bool> RegistrationNewUsers(Users modelUsers)
		{
			if (Bll.Add(modelUsers))
			{
				return new ApiResult<bool>("0", "用户注册结果", true);
			}
			else
			{
				return new ApiResult<bool>("0", "用户注册结果", false);
			}
		}

		/// <summary>
		/// 删除用户根据用户ID
		/// </summary>
		/// <param name="id">用户id</param>
		/// <returns>True or False</returns>
		public static ApiResult<bool> DeleteUser(int id)
		{
			var delectUser = Bll.GetQuery<Users>().AndWhere(x => x.UserId, OperationMethod.Equal, id);
			if (Bll.Delete<Users>(delectUser))
			{
				return new ApiResult<bool>("0", "删除用户成功", true);
			}
			else 
			{
				return new ApiResult<bool>("0", "删除用户失败", false);
			}
		}

		/// <summary>
		/// 根据用户ID用户改变用户状态
		/// </summary>
		/// <param name="id">用户id</param>
		/// <param name="statu">用户状态</param>
		/// <returns>users</returns>
		public static ApiResult<Users> UpdataUser(int id, bool statu)
		{
			var getusersModel=Bll.GetQuery<Users>().AndWhere(x=>x.UserId,OperationMethod.Equal, id);
			var usersModel = Bll.GetModel<Users>(getusersModel);
			usersModel.IsActive = statu;

			if (Bll.Update(usersModel))
			{
				var getUserModel = Bll.GetQuery<Users>().AndWhere(x=>x.UserId,OperationMethod.Equal, id);
				var userModel = Bll.GetModel<Users>(getUserModel);
				return  new ApiResult<Users>("1", "改变用户状态成功",usersModel);
			}
			else
			{
				return new ApiResult<Users>("1", "改变用户状态失败", null);
			}
		}



	}
}
