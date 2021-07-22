using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Framework.Base;
using Framework;

namespace BaseProject.Hooks
{
	[Binding]
	public class Hooks : BaseHooks
	{
		private static ExtentTest _currentScenarioName;
		private static ExtentTest featureName;
		private static ExtentReports extent;
		private static IDictionary<string, ExtentTest> Features = new Dictionary<string, ExtentTest>();

		public static ExtentTest CurrentScenarioName { get => _currentScenarioName; set => _currentScenarioName = value; }

		[BeforeScenario]
		public static void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
		{
			InitializeTests();
			if (Features.TryGetValue(featureContext.FeatureInfo.Title, out ExtentTest feature) == false)
			{
				featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
				Features.Add(featureContext.FeatureInfo.Title, featureName);
			}
			else
			{
				featureName = feature;
			}

			_currentScenarioName = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
		}

		[AfterScenario]
		public static void AfterScenario()
		{
			FinalizeTests();
		}

		[BeforeTestRun]
		public static void InitReport()
		{
			var htmlReporter = new ExtentHtmlReporter(@"..\..\..\TestResults\index.html");
			htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

			extent = new ExtentReports();

			extent.AttachReporter(htmlReporter);
		}
		
		[AfterTestRun]
		public static void TearDownReport()
		{
			extent.Flush();
		}

		[AfterStep]
		public static void StepFinished(ScenarioContext scenarioContext)
		{
			string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

			if (scenarioContext.TestError == null)
			{
				if (stepType == "Given")
					CurrentScenarioName.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
				else if (stepType == "When")
					CurrentScenarioName.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
				else if (stepType == "Then")
					CurrentScenarioName.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
				else if (stepType == "And")
					CurrentScenarioName.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
			}
			else
			{
				var image = CaptureScreenshot(scenarioContext.StepContext.StepInfo.Text);
				if (stepType == "Given")
					CurrentScenarioName.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, image);
				else if (stepType == "When")
					CurrentScenarioName.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, image);
				else if (stepType == "Then")
					CurrentScenarioName.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message, image);
			}
		}
		public static MediaEntityModelProvider CaptureScreenshot(string name)
		{
			var screenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsBase64EncodedString;

			return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
		}
	}
}