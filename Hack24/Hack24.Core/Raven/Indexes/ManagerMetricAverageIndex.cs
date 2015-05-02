using System.Linq;
using Hack24.Core.Entities;
using Hack24.Core.Entities.Raven;
using Hack24.Core.Repositories;
using Mono.CSharp;
using Mono.CSharp.Linq;
using Raven.Client.Indexes;

namespace Hack24.Core.Raven.Indexes
{
	public sealed class ManagerMetricAverageIndex: RavenRepository
	{
		public ManagerMetricAverageIndex()
		{



		}
	}
}