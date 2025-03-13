using Microsoft.AspNetCore.Mvc;
using ProductService.Services;

namespace ProductService.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductInfoService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductInfoService productService, ILogger<ProductController> logger)
        { 
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetProductFilter([FromQuery] int? minprice,[FromQuery] int? maxprice,
            [FromQuery] string? size, [FromQuery] string? highlight)
        {
            try
            {
                _logger.LogInformation("Fetching Products Min price : " + minprice + " Maxprice : " + maxprice
                    + " Size : " + size + " Highlight : " + highlight);

                var productModel = await _productService.GetProductFilterInfo(minprice, maxprice, size, highlight);
                return Ok(productModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching products.");
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
