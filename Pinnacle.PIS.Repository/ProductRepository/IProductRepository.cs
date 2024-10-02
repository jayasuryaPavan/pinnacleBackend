using Pinnacle.PIS.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinnacle.PIS.Repository
{
    public interface IProductRepository
    {
        Task<bool> loadNewBatchAsync(List<ProductInfo> productInfos);

        Task<ProductInfo> getProductInfoByItemIdAsync(string itemId);
        Task<AvailableProductQuantity> getAvailableQuantityByItemId(string itemId);
        Task<ProductInfo> GetProductInfoByBarcodeValue(int barCode);


    }
}
