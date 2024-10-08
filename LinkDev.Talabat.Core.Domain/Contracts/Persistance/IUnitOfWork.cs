using LinkDev.Talabat.Core.Domain.Enities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistance
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<TEnitity, Tkey> GetRepository<TEnitity, Tkey>()
            where TEnitity : BaseAuditableEntitiy<Tkey>
            where Tkey : IEquatable<Tkey>;


        Task<int> CompeletAsnc();

    }
}
