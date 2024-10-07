
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastructure.Peresistance.Repositries;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;

namespace LinkDev.Talabat.Infrastructure.Peresistance.UnitOfWork
{
	internal class UnitOfWork : IUnitOfWork

	{
		private readonly StoreContext _storeContext;
		private readonly Lazy<IGenericRepository<Product, int>> _productRepo;
		private readonly Lazy<IGenericRepository<ProductBrand, int>> _brandtRepo;
		private readonly Lazy<IGenericRepository<ProductCategory, int>> _categoryRepo;
		public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
			_productRepo = new Lazy<IGenericRepository<Product, int>>( ()=> new GenericRepo<Product,int>(_storeContext) );
			_brandtRepo = new Lazy<IGenericRepository<ProductBrand, int>>( ()=> new GenericRepo<ProductBrand, int>(_storeContext) );
			_categoryRepo = new Lazy<IGenericRepository<ProductCategory, int>>( ()=> new GenericRepo<ProductCategory, int>(_storeContext) );

        }
        public IGenericRepository<Product, int> ProductRepo { get => _productRepo.Value; }
		public IGenericRepository<ProductBrand, int> productBrand { get => _brandtRepo.Value;  }
		public IGenericRepository<ProductCategory, int> ProductCategoery { get => _categoryRepo.Value; }



		public Task<int> CompeletAsnc()
		{
			throw new NotImplementedException();
		}

		public ValueTask DisposeAsync()
		{
			throw new NotImplementedException();
		}
	}
}
