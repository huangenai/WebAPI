using HEA.Model;


namespace HEA.WebAPIDemo.API.Interface {
	public interface IAuthenticationService
	{
		bool UpdateUserDevice(UserDevice userSession);
		Users GetUserByPhone(string phone);
		UserDevice GetUserDevice(int userId, int deviceType);
		UserDevice GetUserDevice(string ip, int deviceType);
		bool AddUserDevice(UserDevice model);
		UserDevice GetUserDevice(string sessionKey);
		Users GetUser(int userId);
	}
}