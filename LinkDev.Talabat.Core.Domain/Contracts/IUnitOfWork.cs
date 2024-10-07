using LinkDev.Talabat.Core.Domain.Enities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<Product, int> ProductRepo { get;}
        public IGenericRepository<ProductBrand, int> productBrand { get;}
        public IGenericRepository<ProductCategory, int> ProductCategoery { get; }

        Task<int> CompeletAsnc();
             
    }
}
