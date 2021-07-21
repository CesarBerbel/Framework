using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Framework.Base;

namespace Framework.Tools
{
	public class ElementTools : DriverTools
	{
		public static void Submit(IWebElement _meliante)
		{
			_meliante.Submit();
		}

		public static void Click(IWebElement _meliante)
		{
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_meliante));
			_meliante.Click();
		}

		public static void SelectDropDownOption(IWebElement _meliante, string option)
		{
			//To be implemented when necessary0
		}

		public static void SelectDropDownValue(IWebElement _meliante, string value)
		{
			SelectElement dropdown = new SelectElement(_meliante);
			dropdown.SelectByValue(value);
		}

		public static void SelectDropDownIndex(IWebElement _meliante, string index)
		{
			SelectElement dropdown = new SelectElement(_meliante);
			dropdown.SelectByIndex(int.Parse(index));
		}

		public static void EnterTextInto(IWebElement _meliante, string text)
		{
			_meliante.SendKeys(text);
		}

		public static void ReplaceTextInto(IWebElement _meliante, string text)
		{
			_meliante.Clear();
			_meliante.SendKeys(text);
		}

		public static string GetText(IWebElement _meliante)
		{
			WaitTools.WaitForTextNotEmpty(_meliante);
			return _meliante.Text;
		}

		public static void SelectRadioButton(IWebElement _meliante)
		{
			_meliante.Click();
		}

		public static void JClick(IWebElement _meliante)
		{
			ExecuteJs("arguments[0].click();", _meliante);
		}

		public static void PerformClick(IWebElement _meliante)
		{
			Thread.Sleep(TimeSpan.FromMilliseconds(200));
			Actions act = new Actions(DriverContext.Driver);
			act.MoveToElement(_meliante);
			act.Click(_meliante);
			act.Perform();
		}
	}
}