
using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastructure.Peresistance.Repositries;
using LinkDev.Talabat.Infrastructure.Peresistance.Repositries.GenericRepo;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Peresistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

	{
		private readonly StoreDbContext _storeContext; 
		private readonly ConcurrentDictionary<string,object> _repositories;

		public UnitOfWork(StoreDbContext storeContext)
        { 
            _storeContext = storeContext;
			_repositories = new ConcurrentDictionary<string,object>();
        }
       
		public Task<int> CompleteAsync()
		=>_storeContext.SaveChangesAsync();
		public ValueTask DisposeAsync()
		=>_storeContext.DisposeAsync();

		public IGenericRepository<TEnitity, Tkey> GetRepository<TEnitity, Tkey>()
			where TEnitity : BaseEntity<Tkey>
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
