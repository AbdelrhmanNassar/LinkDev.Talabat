using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistance
{
	public interface IDbContextIntializer
	{
		public Task SeedAsync();

		public Task InializeAsync();

	}
}
