using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Interface;
using POSERPAPI.Manager.Command;
using POSERPAPI.Entities.Entity;

namespace POSERPAPI.Manager.Handlers.Products
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ProcessingStatusEntity>
    {
        private readonly IProductManager _productManager;

        public ProductDeleteCommandHandler(IProductManager productManager)
        {
            _productManager = productManager;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public Task<ProcessingStatusEntity> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

       




    }
}
