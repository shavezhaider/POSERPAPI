using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Entities.Request
{
    public class ProductRequest : IRequest<ProductResponse>
    {
        public ProductEntity productEntity { get; set; }
    }
}
