using Microsoft.AspNetCore.Mvc;
using Pinnacle.PIS.Server.Domain;
using Pinnacle.PIS.Server.Services.ProductService;

namespace Pinnacle.PIS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }

        [Route("loadNewBatch")]
        [HttpPost]
        public async Task<bool> loadNewBatch(List<ImportedData> productInfos)
        {
            return await _productService.LoadNewBatchAsync(productInfos);
        }

        [Route("getProductInfoByItemId")]
        [HttpGet]
        public async Task<ProductInfo> getProductInfoByItemId(string productId)
        {
            return await _productService.getProductInfoByItemIdAsync(productId);
        }
    }
}
