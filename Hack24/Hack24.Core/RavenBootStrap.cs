using Hack24.Core.Entities.Raven;
using Hack24.Core.Repositories;

namespace Hack24.Core
{
	public sealed class RavenBootStrap: RavenRepository
	{
		public void Setup()
		{

			new ManagerMetricAverageIndexCreation().Execute(this.DocStore);
			new ManagerMetricTotalIndexCreation().Execute(this.DocStore);
		}
	}
}