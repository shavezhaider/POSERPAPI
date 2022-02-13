using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Entity;

namespace POSERPAPI.Manager.Command
{
  public class ProductDeleteCommand : IRequest<ProcessingStatusEntity>
    {
        public int id { get; }
        public ProductDeleteCommand(int Id)
        {
            id = Id;

        }
    }
}
