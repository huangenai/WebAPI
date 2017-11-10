using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace HEA.Model
{
	/// <summary>
	/// 监控日志对象
	/// </summary>
	public class WebApiMonitorLog
	{
		public string ControllerName { get; set; }
		public string ActionName { get; set; }

		public DateTime ExecuteStartTime { get; set; }
		public DateTime ExecuteEndTime { get; set; }

		/// <summary>
		/// 请求的Action 参数
		/// </summary>
		public Dictionary<string, object> ActionParams { get; set; }

		/// <summary>
		/// Http请求头
		/// </summary>
		public string HttpRequestHeaders { get; set; }

		/// <summary>
		/// 请求方式
		/// </summary>
		public string HttpMethod { get; set; }

		/// <summary>
		/// 请求的IP地址
		/// </summary>
		public string IP { get; set; }

		/// <summary>
		/// 获取监控指标日志
		/// </summary>
		/// <param name="mtype"></param>
		/// <returns></returns>
		public string GetLoginfo()
		{
			string Msg = @"
            Action执行时间监控：
            ControllerName：{0}Controller
            ActionName:{1}
            开始时间：{2}
            结束时间：{3}
            总 时 间：{4}秒
            Action参数：{5}
            Http请求头:{6}
            客户端IP：{7},
            HttpMethod:{8}
                    ";
			return string.Format(Msg,
				ControllerName,
				ActionName,
				ExecuteStartTime,
				ExecuteEndTime,
				(ExecuteEndTime - ExecuteStartTime).TotalSeconds,
				GetCollections(ActionParams),
				HttpRequestHeaders,
				IP,
				HttpMethod);
		}

		/// <summary>
		/// 获取Action 参数
		/// </summary>
		/// <param name="Collections"></param>
		/// <returns></returns>
		public string GetCollections(Dictionary<string, object> Collections)
		{
			string Parameters = string.Empty;
			if (Collections == null || Collections.Count == 0)
			{
				return Parameters;
			}
			foreach (string key in Collections.Keys)
			{
				Parameters += string.Format("{0}={1}&", key, Collections[key]);
			}
			if (!string.IsNullOrWhiteSpace(Parameters) && Parameters.EndsWith("&"))
			{
				Parameters = Parameters.Substring(0, Parameters.Length - 1);
			}
			return Parameters;
		}

		/// <summary>
		/// 获取IP
		/// </summary>
		/// <returns></returns>
		public string GetIP()
		{
			string ip = string.Empty;
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
				ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
			if (string.IsNullOrEmpty(ip))
				ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
			return ip;
		}
	}
}