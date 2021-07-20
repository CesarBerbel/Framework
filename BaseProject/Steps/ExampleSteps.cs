using System;
using TechTalk.SpecFlow;
using Framework.Base;

namespace Framework
{
	[Binding]
	public class ExamplePageSteps : BaseSteps
	{
		[Given(@"I navigate to the search page (.*)")]
		public void GivenINavigateToTheSearchPage(string url)
		{
			GetInstance<ExamplePage>().GoToThePage(url);
		}

		[Given(@"I fill the search input with (.*)")]
		public void GivenIFillTheSearchInputWith(string term)
		{
			GetInstance<ExamplePage>().FillSearchInput(term);
		}

		[When(@"I press ok")]
		public void WhenIPressOk()
		{
			GetInstance<ExamplePage>().PressEnter();
		}

		[Then(@"I should be directed to result page for (.*)")]
		public void ThenIShouldBeDirectedToResultPageFor(string term)
		{
			GetInstance<ExamplePage>().CheckActualPage(term);
		}
	}
}