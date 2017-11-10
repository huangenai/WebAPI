using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCE.Dapper.Attributes;

namespace HEA.Model {
	public class Users : IUser<int> {

		/// <summary>
		/// User构造函数
		/// </summary>
	    public Users()
	    {
	    }

	    public Users(IDataReader dr)
	    {
			this.UserId = Convert.ToInt32(dr["UserId"]);
			this.UserName = Convert.ToString(dr["UserName"]);
			this.Password = Convert.ToString(dr["Password"]);
			this.TrueName = Convert.ToString(dr["TrueName"]);
			this.Sex = Convert.ToString(dr["Sex"]);
			this.Phone = Convert.ToString(dr["Phone"]);
		    this.IsActive = Convert.ToBoolean(dr["IsActive"]);
		    this.Permissions = Convert.ToInt32(dr["Permissions"]);
	    }
		[Id(true)]
		public int UserId { get; set; }
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string TrueName { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex { get; set; }
		/// <summary>
		/// 电话
		/// </summary>
		public string Phone { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
		public bool IsActive { get; set; }
		/// <summary>
		/// 用户权限
		/// </summary>
		public int Permissions { get; set; }
	}
}
