
using Pinnacle.PIS.Server.Domain;

namespace Pinnacle.PIS.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<bool> LoadNewBatchAsync(List<ImportedData> productInfos);
        Task<ProductInfo> getProductInfoByItemIdAsync(string itemId);
        Task<AvailableProductQuantity> getAvailableQuantityByItemIdAsync(string itemId);
        Task<ProductInfo> GetProductInfoByBarcodeValue(int barCode);

    }
}
