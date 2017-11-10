using System;
namespace HEA.WebAPIDemo.Common
{
	public class LoggerHelper
	{
		private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
		private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
		private static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("logmonitor");

		public static void Error(string ErrorMsg, Exception ex = null)
		{
			if (ex != null)
			{
				logerror.Error(ErrorMsg, ex);
			}
			else
			{
				logerror.Error(ErrorMsg);
			}
		}

		public static void Info(string Msg)
		{
			loginfo.Info(Msg);
		}

		public static void Monitor(string Msg)
		{
			logmonitor.Info(Msg);
		}
	}
}