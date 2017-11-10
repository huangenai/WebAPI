using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEA.Model.Request {
	public class AddUserRq 
	{
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// 用户密码
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex { get; set; }
		/// <summary>
		/// 手机号
		/// </summary>
		public string Phone{get; set; }
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string TrueName { get; set; }
	}
}
