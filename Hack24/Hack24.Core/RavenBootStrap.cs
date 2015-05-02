using Hack24.Core.Entities.Raven;
using Hack24.Core.Repositories;

namespace Hack24.Core
{
	public sealed class RavenBootStrap: RavenRepository
	{
		public void Setup()
		{

			new ManagerMetricAverageIndex().Execute(this.DocStore);
			new ManagerMetricTotalIndex().Execute(this.DocStore);
			new ManagerTotalIndex().Execute(this.DocStore);
		}
	}
}