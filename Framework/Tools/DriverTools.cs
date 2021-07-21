using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Framework.Base;

namespace Framework.Tools
{
	public abstract class DriverTools
	{
		//
		// WAIT OBJECT CREATION
		//
		public static WebDriverWait wait;
		public DriverTools()
		{

			wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(20));
		}

		//
		// SINGLE ELEMENT MANIPULATION
		//
		private static IWebElement FindIt(By by)
		{
			return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
		}

		public static IWebElement FindById(string locator)
		{
			return FindIt(By.Id(locator));
		}

		public static IWebElement FindByClass(string locator)
		{
			return FindIt(By.ClassName(locator));
		}

		public static IWebElement FindByName(string locator)
		{
			return FindIt(By.Name(locator));
		}

		public static IWebElement FindByXPath(string locator)
		{
			return FindIt(By.XPath(locator));
		}

		public static IWebElement FindByCss(string locator)
		{
			return FindIt(By.CssSelector(locator));
		}

		public static IWebElement FindByLinkText(string locator)
		{
			return FindIt(By.LinkText(locator));
		}

		public static IWebElement FindByPartialLinkText(string locator)
		{
			return FindIt(By.PartialLinkText(locator));
		}

		public static IWebElement FindInputByLabel(string labelText)
		{
			return FindIt(By.XPath($"//label[normalize-space()='{labelText}']//input"));
		}                            

		//
		// MULTIPLE ELEMENTS MANIPULATION
		//
		private static IReadOnlyList<IWebElement> FindElements(By by)
		{
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
			return DriverContext.Driver.FindElements(by);
		}

		public static IReadOnlyList<IWebElement> ElementsByXPath(string locator)
		{
			return FindElements(By.XPath(locator));
		}

		public static IReadOnlyList<IWebElement> ElementsByCss(string locator)
		{
			return FindElements(By.CssSelector(locator));
		}

		public static IReadOnlyList<IWebElement> ElementsByClass(string locator)
		{
			return FindElements(By.ClassName(locator));
		}

		public static IReadOnlyList<IWebElement> ElementsByTag(string locator)
		{
			return FindElements(By.TagName(locator));
		}

		//
		// FRAME MANIPULATION
		//
		public static void SwitchToFrame(string frame)
		{
			DriverContext.Driver.SwitchTo().Frame(frame);
		}

		public static void ParentFrame()
		{
			DriverContext.Driver.SwitchTo().ParentFrame();
		}

		//
		// WINDOW MANIPULATION
		//
		public static void SwitchToWindow(string window)
		{
			DriverContext.Driver.SwitchTo().Window(window);
		}

		//
		// AUXILIAR FUNCTIONS
		//
		public static object ExecuteJs(string script, IWebElement _meliante)
		{
			return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script, _meliante);
		}

		public static void NavigateTo(string url)
		{
			DriverContext.Driver.Navigate().GoToUrl(url);
			DriverContext.Driver.Manage().Window.Maximize();
		}
	}
}
