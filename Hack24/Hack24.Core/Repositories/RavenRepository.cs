﻿using Raven.Client;
using Raven.Client.Document;

namespace Hack24.Core.Repositories
{
	public abstract class RavenRepository
	{
		public readonly IDocumentStore DocStore;
		
		protected RavenRepository()
		{
			this.DocStore = new DocumentStore
			{
				Url = "http://10.82.1.56:8080",
				DefaultDatabase = "Hack24"
			}.Initialize();
		}
	}
}