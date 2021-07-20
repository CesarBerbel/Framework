using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using Framework.Base;
using Framework.Config;
using Framework.Tools;

namespace Framework
{
	partial class ExamplePage : BasePage
	{
		public void GoToThePage(string url)
		{
			DriverContext.Driver.Url = url;
		}

		public void FillSearchInput(string term)
		{
			EnterTextInto(FindByXPath(SearchInput), term);
		}

		public void PressEnter()
		{
			FindByXPath(SearchInput).SendKeys(Keys.Enter);
		}

		public void CheckActualPage(string term)
		{
			Assert.IsTrue(DriverContext.Driver.Url.Contains(term), DriverContext.Driver.Url);
		}
	}
}