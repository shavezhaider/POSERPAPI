
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Interface
{
    public interface IProductManager
    {
        //Task<  void GetProductList();
        /// <summary>
        /// 
        /// </summary>
        Task<ProductResponse> AddProductAsync(ProductRequest productRequest);
        Task<ProcessingStatusEntity> DeleteProductAsync(int productId);
        Task<IEnumerable<ProductEntity>> GetProductList();
        Task<ProductEntity> GetProductByProductId(int productId);
    }
}
