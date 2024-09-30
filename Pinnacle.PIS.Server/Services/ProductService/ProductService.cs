using Pinnacle.PIS.Repository;
using Pinnacle.PIS.Server.Domain;

namespace Pinnacle.PIS.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private ILogger<ProductService> _logger;
        private IProductRepository _productRepository;
        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<AvailableProductQuantity> getAvailableQuantityByItemIdAsync(string itemId)
        {
            _logger.LogInformation("Enter into getProductInfoByItemId in ProductService");
            try
            {
                return await _productRepository.getAvailableQuantityByItemId(itemId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getProductInfoByItemId in ProductService" + ex.Message);
                throw;
            }
        }

        public async Task<ProductInfo> GetProductInfoByBarcodeValue(int barCode)
        {
            _logger.LogInformation("Enter into GetProductInfoByBarcodeValue in ProductService");
            try
            {
                return await _productRepository.GetProductInfoByBarcodeValue(barCode);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetProductInfoByBarcodeValue in ProductService" + ex.Message);
                throw;
            }
        }

        public async Task<ProductInfo> getProductInfoByItemIdAsync(string itemId)
        {
            _logger.LogInformation("Enter into getProductInfoByItemId in ProductService");
            try
            {
                return await _productRepository.getProductInfoByItemIdAsync(itemId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getProductInfoByItemId in ProductService" + ex.Message);
                throw;
            }
        }

        public async Task<bool> LoadNewBatchAsync(List<ImportedData> RawProduct)
        {
            DateTime time = DateTime.Now;
            List<ProductInfo> productInfos = new List<ProductInfo>();
            foreach (ImportedData productInfo in    RawProduct)
            {
                ProductInfo product1 =await getProductInfoByItemIdAsync(productInfo.ItemId);
                if (product1 != null) 
                {
                    AvailableProductQuantity availableProductQuantity =await getAvailableQuantityByItemIdAsync(productInfo.ItemId);
                    availableProductQuantity.Quantity = availableProductQuantity.Quantity + Convert.ToInt32(productInfo.ItemQuantity);
                    availableProductQuantity.UpdatedDate = time;
                    availableProductQuantity.UpdatedBy = 1;
                    product1.AvailableProductQuantities.Add(availableProductQuantity);
                    productInfos.Add(product1);
                }
                else
                {
                    AvailableProductQuantity availableProductQuantity = new AvailableProductQuantity()
                    {
                        Quantity = productInfo.ItemQuantity,
                        CreatedDate = time,
                        CreatedBy = 1
                    };
                    product1 = new ProductInfo()
                    {
                        ItemId = productInfo.ItemId,
                        Description = productInfo.Description,
                        SellPrice = productInfo.SellPrice,
                        ExtSellPrice = productInfo.ExtSellPrice,
                        SalvagePercentage = productInfo.SalvagePercentage,
                        SalvageAmount = productInfo.SalvageAmount,
                        //SellPrice = (decimal)productInfo.SellPrice,
                        //ExtSellPrice = (decimal)productInfo.ExtSellPrice,
                        //SalvagePercentage = (decimal)productInfo.SalvagePercentage,
                        //SalvageAmount = (decimal)productInfo.SalvageAmount,
                        CreatedDate = time,
                        CreatedBy = 1
                    };
                    product1.AvailableProductQuantities = new List<AvailableProductQuantity>();
                    product1.AvailableProductQuantities.Add(availableProductQuantity);
                    productInfos.Add(product1);
                }
            }
            return await _productRepository.loadNewBatchAsync(productInfos);
        }
    }
}
