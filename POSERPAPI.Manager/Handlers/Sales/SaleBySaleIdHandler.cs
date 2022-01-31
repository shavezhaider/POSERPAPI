using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POSERPAPI.Entities.Response;
using POSERPAPI.Manager.Queries;

namespace POSERPAPI.Manager.Handlers.Sales
{
    public class SaleBySaleIdHandler : IRequestHandler<SaleBySaleIdQuery, SaleResponse>
    {
        public Task<SaleResponse> Handle(SaleBySaleIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
