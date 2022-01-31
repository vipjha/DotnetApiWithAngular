using Skinet_Core.Entities;
using Skinet_Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet_Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> sepc);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec); 
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
