
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Repository.EDMX;
using POSERPAPI.Repository.Interface;
using POSERPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace POSERPAPI.Manager.Implementation
{
    public class ProductManager : IProductManager
    {

        #region Variables 
        private IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IServiceProvider serviceProvider, IMapper mapper)
        {
            _mapper = mapper;
            ResolveRepository(serviceProvider);
            // MapperConfiguration();
        }

        #endregion 
        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        public async Task<ProductResponse> AddProductAsync(ProductRequest productRequest)
        {
            int result = 0;
            ProcessingStatusEntity processingStatusEntity = new ProcessingStatusEntity();
            ProductResponse productResponse = new ProductResponse();
            List<ErrorEntity> errorEntities = new List<ErrorEntity>();
            if (errorEntities.Count == 0)
            {
                ProductEntity product = productRequest.productEntity;
                Product existingProduct = await _productRepository.FirstOrDefaultAsync(x => x.ProductName == product.ProductName);
                if (existingProduct == null)
                {
                    result = await AddProduct(product);
                    processingStatusEntity.Status = result > 0 ? Constants.Success : Constants.Failure;
                }
            }
            else
            {
                processingStatusEntity.Status = Constants.Failure;
                processingStatusEntity.Errors = errorEntities;

            }
            productResponse.processingStatus = processingStatusEntity;
            return productResponse;

        }



        public async Task<ProcessingStatusEntity> DeleteProductAsync(int productId)
        {
            int result = 0;
            ProcessingStatusEntity processingStatusEntity = new ProcessingStatusEntity();
            Product product = _productRepository.GetByID(productId);
            if (product != null)
            {

                await _productRepository.RemoveAsync(product);
                result = await _productRepository.SaveChangesAsync();
                if (result > 0)
                    processingStatusEntity.Status = Constants.Success;
                else
                    processingStatusEntity.Status = Constants.Failure;

            }
            return processingStatusEntity;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductList()
        {
            var productlist = await _productRepository.GetAll() as IEnumerable<Product>;


            return MapProductEntity(productlist);

            // return productlist.Count() > 0 ? _mapper.Map<IEnumerable<ProductEntity>>(productlist) : null;

        }

        public async Task<ProductEntity> GetProductByProductId(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return product != null ? _mapper.Map<ProductEntity>(product) : null;

        }



        #region Methods

        private IEnumerable<ProductEntity> MapProductEntity(IEnumerable<Product> listProduct)
        {
            return listProduct?.Select(e =>
            new ProductEntity
            {
                ProductName = e.ProductName,
                SKU = e.SKU,
                MaxLimit = e.MaxLimit,
                MinLimit = e.MinLimit,
                StockItem = e.StockItem

            }
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productEntity"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>

        private async Task<int> AddProduct(ProductEntity productEntity, int ProductId = 0)
        {
            // Product product = new Product();

            var product = new Product
            {

                ProductName = productEntity.ProductName,
                AddedDate = DateTime.UtcNow

            };
            int result = 0;

            await _productRepository.AddAsync(product);
            result = await _productRepository.SaveChangesAsync();
            return result;

        }
        private void ResolveRepository(IServiceProvider serviceProvider)
        {
            _productRepository = serviceProvider.GetService<IBaseRepository<Product>>();
        }
     
        #endregion 
    }
}
