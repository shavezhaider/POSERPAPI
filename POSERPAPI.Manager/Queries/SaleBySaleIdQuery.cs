using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Manager.Queries
{
    public class SaleBySaleIdQuery :IRequest<SaleResponse>
    {
        public SaleBySaleIdQuery()
        { }
    }
}
