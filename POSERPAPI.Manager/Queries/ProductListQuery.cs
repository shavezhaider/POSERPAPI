using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;

namespace POSERPAPI.Manager.Queries
{
    public class ProductListQuery : IRequest<IEnumerable<ProductEntity>>
    {

        public ProductListQuery()
        {

        }

    }
}
