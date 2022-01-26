using MediatR;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Command
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public ProductRequest ProductRequest;

        public CreateProductCommand(ProductRequest productRequest)
        {
            ProductRequest = productRequest;
        }
    }
}
