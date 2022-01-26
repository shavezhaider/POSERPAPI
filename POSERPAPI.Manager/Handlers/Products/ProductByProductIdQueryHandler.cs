using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Manager.Queries;

namespace POSERPAPI.Manager.Handlers.Products
{
    public class ProductByProductIdQueryHandler : IRequestHandler<ProductByProductIdQuery, ProductEntity>
    {
        private readonly IProductManager _productManager;

        public ProductByProductIdQueryHandler(IProductManager productManager)
        {
            _productManager = productManager;


        }
        public async Task<ProductEntity> Handle(ProductByProductIdQuery request, CancellationToken cancellationToken)
        
        {
            return await _productManager.GetProductByProductId(request.id);
        }
    }
}
