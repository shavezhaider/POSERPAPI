using MediatR;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Command;
using POSERPAPI.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace POSERPAPI.Manager.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductManager _productManager;

        public CreateProductCommandHandler(IProductManager productManager)
        {
            _productManager = productManager;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return _productManager.AddProductAsync(request.ProductRequest);
        }

        //public Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
