using Skinet_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet_Core.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id);
        public Task<IReadOnlyList<Product>> GetProductsAysc();
        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        public Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}
