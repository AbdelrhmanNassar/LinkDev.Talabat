
using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastructure.Peresistance.Repositries;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Peresistance.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork

	{
		private readonly StoreContext _storeContext; 
		private readonly ConcurrentDictionary<string,object> _repositories;

		public UnitOfWork(StoreContext storeContext)
        { 
            _storeContext = storeContext;
			_repositories = new ConcurrentDictionary<string,object>();
        }
       
		public Task<int> CompeletAsnc()
		=>_storeContext.SaveChangesAsync();
		public ValueTask DisposeAsync()
		=>_storeContext.DisposeAsync();

		public IGenericRepository<TEnitity, Tkey> GetRepository<TEnitity, Tkey>()
			where TEnitity : BaseAuditableEntitiy<Tkey>
			where Tkey : IEquatable<Tkey>
		{
			//var typeName = typeof(TEnitity).Name;//will get the type  as string
			//if (_repositories.ContainsKey(typeName))
			//	return (IGenericRepository<TEnitity, Tkey>) _repositories[typeName];
			//var repo = new GenericRepo<TEnitity, Tkey>(_storeContext);
			//_repositories.Add(typeName, repo);
			return(IGenericRepository<TEnitity, Tkey>) _repositories.GetOrAdd(typeof(TEnitity).Name, (key) => new GenericRepo<TEnitity, Tkey>(_storeContext));
		

		}
	}
}
