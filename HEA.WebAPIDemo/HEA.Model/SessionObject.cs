using System;
using JCE.Dapper.Attributes;


namespace HEA.Model {
	public class SessionObject {
		public string SessionKey { get; set; }
		public Users LogonUser { get; set; }
	}

	public class SessionObject1 {
		public string SessionKey { get; set; }
		public string Ip { get; set; }
	}
}