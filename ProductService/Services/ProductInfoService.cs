using System.Linq;
using System.Xml.Linq;
using ProductService.DataLayer.Repositories;
using ProductService.Model;

namespace ProductService.Services
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IProductRepository _productRespository;
        public ProductInfoService(IProductRepository productRepository)
        {
           _productRespository = productRepository;
        }

        /// <summary>
        /// Apply filter condition in service layer
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductView>> GetProductFilterInfo(int? minprice, int? maxprice, string? size, string? highlight)
        {
            var productDataModel = await _productRespository.GetProducts();

            var productView = ApplyFilterProductData(productDataModel, minprice, maxprice, size, highlight);

            return productView;
        }
        
        private List<ProductView> ApplyFilterProductData(ProductModel productInforModel, int? minprice, int? maxprice, 
            string? size, string? highlight)
        {
            var filteredProducts = productInforModel.Products.AsQueryable();

            if (minprice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= minprice.Value);
            }

            if (maxprice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxprice.Value);
            }

            if (!string.IsNullOrEmpty(size))
            {
                filteredProducts = filteredProducts.Where(p => p.Sizes.Contains(size, StringComparer.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(highlight))
            {
                filteredProducts = filteredProducts.Where(p => p.Description.Contains(highlight, StringComparison.OrdinalIgnoreCase));
            }
            return filteredProducts.ToList();
        }
    }
}
