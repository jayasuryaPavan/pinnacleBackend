using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pinnacle.PIS.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinnacle.PIS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ILogger<ProductRepository> _logger;
        private PISEntities _pISEntities;
        public ProductRepository(ILogger<ProductRepository> logger, PISEntities pISEntities)
        {
            _logger = logger;
            _pISEntities = pISEntities;
        }

        public async Task<AvailableProductQuantity> getAvailableQuantityByItemId(string itemId)
        {
            _logger.LogInformation("Enter into getAvailableQuantityByItemId in ProductRepository");
            try
            { 
                var product = _pISEntities.ProductInfos.Where(x => x.ItemId == itemId).FirstOrDefault();
                return _pISEntities.AvailableProductQuantities.Where(x=>x.ProductInfoId==product.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getAvailableQuantityByItemId in ProductRepository" + ex.Message);
                throw;
            }
        }

        public async Task<ProductInfo> GetProductInfoByBarcodeValue(int barCode)
        {
            _logger.LogInformation("Enter into GetProductInfoByBarcodeValue in ProductRepository");
            try
            {
                return await _pISEntities.ProductInfos.Where(x => x.BarcodeValue == barCode).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetProductInfoByBarcodeValue in ProductRepository" + ex.Message);
                throw;
            }
        }

        public async Task<ProductInfo> getProductInfoByItemIdAsync(string itemId)
        {
            _logger.LogInformation("Enter into getProductInfoByItemId in ProductRepository");
            try
            {
                return await _pISEntities.ProductInfos.Where(x => x.ItemId == itemId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in getProductInfoByItemId in ProductRepository" + ex.Message);
                throw;
            }
        }

        public async Task<bool> loadNewBatchAsync(List<ProductInfo> productInfos)
        {
            _logger.LogInformation("Enter into getProductInfoByItemId in ProductRepository");
            try
            {
                foreach (var productInfo in productInfos)
                {
                    if(productInfo.Id!=0)
                    {
                        _pISEntities.Update(productInfo);
                    }
                    else
                    {
                        _pISEntities.Add(productInfo);
                    }
                }
                return await _pISEntities.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in loadNewBatch in ProductRepository" + ex.Message);

                return false;
            }
        }
    }
}
