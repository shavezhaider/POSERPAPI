using MediatR;
using POSERPAPI.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Manager.Queries
{
   public class ProductByProductIdQuery :IRequest<ProductEntity>
    {
        public int id { get; }

        public ProductByProductIdQuery(int Id)
        {
            id = Id;
        }
    }
}
