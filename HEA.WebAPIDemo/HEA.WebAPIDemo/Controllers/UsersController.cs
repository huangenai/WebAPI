using System;
using System.Web.Http;
using System.Web.Http.Cors;
using HEA.Model;
using HEA.Model.Request;
using HEA.WebAPIDemo.API;
using HEA.WebAPIDemo.API.Interface;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/Users"), SessionValidate, WebApiTracker] 
    public class UsersController : ApiController
    {
		private  readonly IUsers _users=new UsersImpl();
		#region 根据用户ID获得用户信息
		/// <summary>
		/// 根据用户ID获得用户信息（获得数据）
		/// </summary>
		/// <param name="sessionKey">sessionKey</param>
		/// <param name="id">用户id</param>
		/// <returns>result</returns>
		public ApiResult<Users> GetUserById( string sessionKey,int  id)
		{
			Users modelUsers = _users.GetUserByUsersId(id);
			if (modelUsers != null)
			{
				return new ApiResult<Users>("1","获取用户信息成功",modelUsers);
			}
			else return new ApiResult<Users>("0","无此用户信息",null);
		}
		#endregion

		/// <summary>
		/// 新用户注册(增加数据)
		/// </summary>
		/// <param name="modelUsers"></param>
		/// <returns>result</returns>
		[HttpPost, Route("api/UserRegistration")]
		public ApiResult<bool> UserRegistration(string sessionKey, AddUserRq modelUsers)
		{
			Users usersModel=new Users();
			usersModel.IsActive = true;
			usersModel.Password = modelUsers.Password;
			usersModel.Permissions = 2;
			usersModel.Phone = modelUsers.Phone;
			usersModel.Sex = modelUsers.Sex;
			usersModel.TrueName = modelUsers.TrueName;
			usersModel.UserName = modelUsers.UserName;
			return _users.RegistrationNewUsers(usersModel);
		}
    }
}
