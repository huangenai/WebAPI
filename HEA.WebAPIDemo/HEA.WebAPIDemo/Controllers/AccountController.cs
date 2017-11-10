using System;
using System.Web.Http;
using HEA.Model;
using HEA.WebAPIDemo.API;
using HEA.WebAPIDemo.API.Interface;
using HEA.WebAPIDemo.Common;

namespace HEA.WebAPIDemo.Controllers {
	[RoutePrefix("api/accounts"), WebApiTracker]
	public class AccountController : ApiController {
		private readonly IAuthenticationService _authenticationService = new AuthenticationService();

		public AccountController() {
			//this._authenticationService = IocManager.Intance.Reslove<IAuthenticationService>();
		}

		#region  登录API
		/// <summary>
		/// 登录API （账号登陆）
		/// </summary>
		/// <param name="phone">登录帐号手机号</param>
		/// <param name="hashedPassword">加密后的密码，这里避免明文，客户端加密后传到API端</param>
		/// <param name="deviceType">客户端的设备类型</param>
		/// <param name="clientId">客户端识别号, 一般在APP上会有一个客户端识别号</param>
		/// <returns></returns>
		[Route("account/login")]
		public SessionObject Login(string phone, string hashedPassword, int deviceType = 0, string clientId = "") {
			if (string.IsNullOrEmpty(phone))
				throw new ApiException("用户名不能为空。", "RequireParameter_userphone");
			if (string.IsNullOrEmpty(hashedPassword))
				throw new ApiException("hashedPassword 不能为空.", "RequireParameter_hashedPassword");

			int timeout = 60;

			var nowUser = _authenticationService.GetUserByPhone(phone);
			if (nowUser == null)
				throw new ApiException("帐户不存在", "Account_NotExits");

			#region 验证密码
			if (!string.Equals(nowUser.Password, hashedPassword)) {
				throw new ApiException("错误的密码", "Account_WrongPassword");
			}
			#endregion

			if (!nowUser.IsActive)
				throw new ApiException("用户处于非活动状态.", "InactiveUser");

			UserDevice existsDevice = _authenticationService.GetUserDevice(nowUser.UserId, deviceType);
			// Session.QueryOver<UserDevice>().Where(x => x.AccountId == nowAccount.Id && x.DeviceType == deviceType).SingleOrDefault();
			if (existsDevice == null) {
				string passkey = MD5CryptoProvider.GetMD5Hash(nowUser.UserId + nowUser.Phone + DateTime.UtcNow+ Guid.NewGuid());
				existsDevice = new UserDevice() {
					UserId = nowUser.UserId,
					CreateTime = DateTime.UtcNow,
					ActiveTime = DateTime.UtcNow,
					ExpiredTime = DateTime.UtcNow.AddMinutes(timeout),
					DeviceType = deviceType,
					SessionKey = passkey
				};
				_authenticationService.AddUserDevice(existsDevice);
			}
			else {
				existsDevice.ActiveTime = DateTime.UtcNow;
				existsDevice.ExpiredTime = DateTime.UtcNow.AddMinutes(timeout);
				_authenticationService.UpdateUserDevice(existsDevice);
			}
			nowUser.Password = "";
			return new SessionObject() { SessionKey = existsDevice.SessionKey, LogonUser = nowUser };
		}
		#endregion

		#region 匿名登陆
		/// <summary>
		/// 匿名登陆
		/// </summary>
		/// <param name="ip">用户ip地址</param>
		/// <param name="deviceType">设备类型</param>
		/// <param name="clientId">客户端识别号</param>
		/// <returns></returns>
		[Route("account/AnonymousLogin")]
		public SessionObject1 AnonymousLogin(string ip, int deviceType = 0, string clientId = "")
		{
			if (string.IsNullOrEmpty(ip))throw new ApiException("ip地址不能为空。", "RequireParameter_ip");

			int timeout = 60;

			UserDevice existsDevice = _authenticationService.GetUserDevice(ip, deviceType);
			// Session.QueryOver<UserDevice>().Where(x => x.AccountId == nowAccount.Id && x.DeviceType == deviceType).SingleOrDefault();
			if (existsDevice == null) {
				string passkey = MD5CryptoProvider.GetMD5Hash(ip+DateTime.UtcNow + Guid.NewGuid());
				existsDevice = new UserDevice() {
					IP = ip,
					CreateTime = DateTime.UtcNow,
					ActiveTime = DateTime.UtcNow,
					ExpiredTime = DateTime.UtcNow.AddMinutes(timeout),
					DeviceType = deviceType,
					SessionKey = passkey
				};
				_authenticationService.AddUserDevice(existsDevice);
			}
			else {
				existsDevice.ActiveTime = DateTime.UtcNow;
				existsDevice.ExpiredTime = DateTime.UtcNow.AddMinutes(timeout);
				_authenticationService.UpdateUserDevice(existsDevice);
			}
			return new SessionObject1() { SessionKey = existsDevice.SessionKey, Ip=ip };
		}
	
		#endregion
	}
}