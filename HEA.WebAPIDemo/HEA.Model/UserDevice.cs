using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCE.Dapper.Attributes;

namespace HEA.Model
{
	public class UserDevice
	{
		[Id(true)]
		public int UserDeviceID { get; set; }

		public string IP { get; set; }
		public int UserId { get; set; }
		public DateTime ActiveTime { get; set; }
		public DateTime ExpiredTime { get; set; }
		public DateTime CreateTime { get; set; }
		public int DeviceType { get; set; }
		public string SessionKey { get; set; }
	}
}