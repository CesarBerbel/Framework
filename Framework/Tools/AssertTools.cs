using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Framework.Base;
using Framework.Config;

namespace Framework.Tools
{
	public class AssertTools : ElementTools
	{
		public static void CheckForURL(string partialUrl)
		{
			string url = Configurations.URL + partialUrl;
			Assert.IsTrue(WaitTools.WaitForURL(url), $"The url should be '{url}' but still '{DriverContext.Driver.Url}' in the browser"); ;
		}

		public static void CheckElementText(IWebElement element, string text)
		{
			WaitTools.WaitForTextNotEmpty(element);
			Assert.IsTrue(element.Text == text, $"The component should show the text '{text}' but is showing '{element.Text}'"); ;
		}

		public static void CheckElementTextContains(IWebElement element, string text)
		{
			WaitTools.WaitForTextNotEmpty(element);
			Assert.IsTrue(element.Text.Contains(text), $"The component should contains '{text}' but is showing '{element.Text}'"); ;
		}

		public static void CheckIfListMatch(string[] shouldBe, IReadOnlyList<IWebElement> fromElements)
		{
			Assert.AreEqual(shouldBe.Length, fromElements.Count, $"The count of the lists are not the same. Should be {shouldBe.Length} but is coming {fromElements.Count} elements. Please check the elements locator");

			string output = "";
			for(int i = 0; i < shouldBe.Length; i++)
			{
				WaitTools.WaitForTextNotEmpty(fromElements[i]);
				if (shouldBe[i] != fromElements[i].Text)
				{
					output = $"{output} In the position {i + 1} the text should be '{shouldBe[i]}' but is '{fromElements[i].Text}'";
				}
			}
			Assert.IsTrue(output == "", output);
		}

		public static void CheckIfListContainsText(string shouldBe, IReadOnlyList<IWebElement> fromElements)
		{
			bool find = false;
			for (int i = 0; i < shouldBe.Length; i++)
			{
				WaitTools.WaitForTextNotEmpty(fromElements[i]);
				if (shouldBe == fromElements[i].Text)
				{
					find = true;
				}
			}
			Assert.IsTrue(find, $"The text {shouldBe} was not found on the list. Please verify the locator.");
		}

		public static void CheckIfListNotContainsText(string shouldBe, IReadOnlyList<IWebElement> fromElements)
		{
			bool find = false;
			for (int i = 0; i < shouldBe.Length; i++)
			{
				WaitTools.WaitForTextNotEmpty(fromElements[i]);
				if (shouldBe == fromElements[i].Text)
				{
					find = true;
				}
			}
			Assert.IsFalse(find, $"The text {shouldBe} was not found on the list. Please verify the locator.");
		}

		public static void CheckIfElementNotExists(IReadOnlyList<IWebElement> elements)
		{
			Assert.IsTrue(elements.Count == 0, $"Locator is returning {elements.Count} results. The element exists or the xpath used is wrong.");
		}
	}
}
