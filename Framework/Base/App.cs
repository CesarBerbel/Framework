using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Framework.Config;

namespace Framework.Base
{
	public abstract class App : Steps
	{
		public WebDriverWait wait;

		public static void InitializeTests()
		{
			ConfigReader.InitializeConfigurations();

			OpenBrowser(Configurations.BrowserType);

		}

		private static void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
		{
			switch (browserType)
			{
				case BrowserType.Chrome:
					DriverContext.Driver = new ChromeDriver();
					DriverContext.Browser = new Browser(DriverContext.Driver);
					break;
				case BrowserType.Firefox:
					DriverContext.Driver = new FirefoxDriver();
					DriverContext.Browser = new Browser(DriverContext.Driver);
					break;
				case BrowserType.IPhone:
					SafariOptions capability = new SafariOptions();
					capability.AddAdditionalCapability("os_version", "14");
					capability.AddAdditionalCapability("device", "iPhone 12");
					capability.AddAdditionalCapability("real_mobile", "true");
					capability.AddAdditionalCapability("project", "Testando");
					capability.AddAdditionalCapability("build", "Framework");
					capability.AddAdditionalCapability("name", "Framework");
					capability.AddAdditionalCapability("browserstack.local", "false");
					capability.AddAdditionalCapability("browserstack.user", "csarberbel1");
					capability.AddAdditionalCapability("browserstack.key", "q7krd5VsYyH7auBnpfs7");					
					DriverContext.Driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability);
					DriverContext.Browser = new Browser(DriverContext.Driver);
					break;
			}
		}

		public static void FinalizeTests()
		{
			DriverContext.Driver.Quit();
		}
	}
}
