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
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductEntity>>
    {
        private readonly IProductManager _IproductManager;

        public ProductListQueryHandler(IProductManager productManager)
        {
            _IproductManager = productManager;
        }
        public async  Task<IEnumerable<ProductEntity>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            return await _IproductManager.GetProductList();
        }
    }
}
