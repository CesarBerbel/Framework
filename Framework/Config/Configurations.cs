using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Base;

namespace Framework.Config
{
	public class Configurations
	{
		public static int Timeout { get; set; }

		public static string IsReporting { get; set; }

		public static string TestType { get; set; }

		public static string URL { get; set; }

		public static string BuildName { get; set; }

		public static BrowserType BrowserType { get; set; }
		
		public static string IsLog { get; set; }

		public static string LogPath { get; set; }

		private static bool _fileCreated = false;

		public static bool FileCreated
		{
			get
			{
				return _fileCreated;
			}
			set
			{
				_fileCreated = value;
			}
		}
	}
}
