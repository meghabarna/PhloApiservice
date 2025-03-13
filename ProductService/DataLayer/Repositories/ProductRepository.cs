using System;
using ProductService.Model;
using Newtonsoft.Json;
using ProductService.Constants;
using ProductService.Controllers;

namespace ProductService.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _prodUrl;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _prodUrl = configuration.GetValue<string>(AppSettingConstants.ProductUrl);
            _logger = logger;
        }
        public async Task<ProductModel> GetProducts()
        {
            var prodDataaModel = await GetAllProduct();
            return prodDataaModel;
        }

        /// <summary>
        /// Simulating as Database call
        /// </summary>
        /// <returns></returns>
        private async Task<ProductModel> GetAllProduct()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(_prodUrl);
                _logger.LogInformation("Mocky IO reponse data : " + response);

               var prod = JsonConvert.DeserializeObject<ProductModel>(response);
                return prod;
            }
        }
    }
}
