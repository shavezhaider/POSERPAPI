using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Manager.Command;

namespace POSERPAPI.Manager.Handlers.Sales
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, ProcessingStatusEntity>
    {
        public Task<ProcessingStatusEntity> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
