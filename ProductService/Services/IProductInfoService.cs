using ProductService.Model;

namespace ProductService.Services
{
    public interface IProductInfoService
    {
        Task<List<ProductView>> GetProductFilterInfo(int? minprice, int? maxprice, string? size, string? highlight);
    }
}
