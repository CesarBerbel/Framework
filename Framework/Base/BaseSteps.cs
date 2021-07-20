using Framework.Config;

namespace Framework.Base
{
	public class BaseSteps : Base
	{

		public virtual void NavigateToHome()
		{
			NavigateTo(Configurations.URL);
		}
	}
}
