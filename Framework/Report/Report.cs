using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Framework.Base;

namespace Framework.Report
{
	public static class Report
	{
		private static ExtentTest _currentScenarioName;
		private static ExtentTest featureName;
		private static ExtentReports extent;
		private static IDictionary<string, ExtentTest> Features = new Dictionary<string, ExtentTest>();

		public static void AddStepToReport(bool error, string stepType, string stepInfo, string errorMessage = "")
		{

			if (error)
			{
				if (stepType == "Given")
					_currentScenarioName.CreateNode<Given>(stepInfo);
				else if (stepType == "When")
					_currentScenarioName.CreateNode<When>(stepInfo);
				else if (stepType == "Then")
					_currentScenarioName.CreateNode<Then>(stepInfo);
				else if (stepType == "And")
					_currentScenarioName.CreateNode<And>(stepInfo);
			}
			else
			{
				var image = CaptureScreenshot(stepInfo);
				if (stepType == "Given")
					_currentScenarioName.CreateNode<Given>(stepInfo).Fail(errorMessage, image);
				else if (stepType == "When")
					_currentScenarioName.CreateNode<When>(stepInfo).Fail(errorMessage, image);
				else if (stepType == "Then")
					_currentScenarioName.CreateNode<Then>(stepInfo).Fail(errorMessage, image);
			}
		}

		public static void CreateScenario(string titulo, string scenarioTitle)
		{
			if (Features.TryGetValue(titulo, out ExtentTest feature) == false)
			{
				featureName = extent.CreateTest<Feature>(titulo);
				Features.Add(titulo, featureName);
			}
			else
			{
				featureName = feature;
			}

			_currentScenarioName = featureName.CreateNode<Scenario>(scenarioTitle);
		}

		public static void InitializaReport()
		{
			var htmlReporter = new ExtentHtmlReporter(@"..\..\TestResults\index.html");
			htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
			
			extent = new ExtentReports();

			extent.AttachReporter(htmlReporter);
		}

		public static void CreateReport()
		{
			//extent.Flush();
		}

		public static MediaEntityModelProvider CaptureScreenshot(string name)
		{
			var screenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsBase64EncodedString;

			return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
		}
	}
}
