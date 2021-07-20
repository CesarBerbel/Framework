using OpenQA.Selenium;
using System;
using Framework.Tools;

namespace Framework.Base
{
	public abstract class Base : AssertTools
	{
		private IWebDriver _driver { get; set; }

		public TPage GetInstance<TPage>() where TPage : BasePage, new()
		{
			return (TPage)Activator.CreateInstance(typeof(TPage));
		}
		

	}
}
