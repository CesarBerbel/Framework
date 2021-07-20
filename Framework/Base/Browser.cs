using OpenQA.Selenium;

namespace Framework.Base
{
	public class Browser
	{
		private readonly IWebDriver _driver;

		public Browser(IWebDriver driver)
		{
			_driver = driver;
		}

		public BrowserType Type { get; set; }

		public void GotToUrl(string url)
		{
			DriverContext.Driver.Url = url;
		}
	}
	
	public enum BrowserType
	{
		Chrome,
		Firefox,
		IPhone,
		Android
	}
}
