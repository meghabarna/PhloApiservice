
using ProductService.Model;

namespace ProductService.DataLayer.Repositories
{
    public interface IProductRepository
    {
        public Task<ProductModel> GetProducts();
    }
}
