using Framework;
using Framework.Report;
using TechTalk.SpecFlow;

namespace BaseProject.Hooks
{
	[Binding]
	public  class Hooks : BaseHooks
	{
		[BeforeScenario]
		public static void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
		{
			InitializeTests();
			Report.CreateScenario(featureContext.FeatureInfo.Title, scenarioContext.ScenarioInfo.Title);
		}

		[AfterScenario]
		public static void AfterScenario()
		{
			FinalizeTests();
		}

		[BeforeTestRun]
		public static void InitReport()
		{
			Report.InitializaReport();
		}

		[AfterTestRun]
		public static void TearDownReport()
		{
			Report.CreateReport();
		}

		[AfterStep]
		public static void StepFinished(ScenarioContext scenarioContext)
		{
			string errorMsg = "";
			bool pass = true;

			if (scenarioContext.TestError != null)
			{
				errorMsg = scenarioContext.TestError.Message;
				pass = false;
			}

			Report.AddStepToReport(pass, scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(), scenarioContext.StepContext.StepInfo.Text, errorMsg);
		}
	}
}
