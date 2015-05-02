using Raven.Client;
using Raven.Client.Document;

namespace Hack24.Core.Repositories
{
	public abstract class RavenRepository
	{
		protected IDocumentStore DocStore;
		

		protected RavenRepository()
		{
			this.DocStore = new DocumentStore
			{
				Url = "http://localhost:8080",
				DefaultDatabase = "Hack24"
			}.Initialize();
		}


	}
}