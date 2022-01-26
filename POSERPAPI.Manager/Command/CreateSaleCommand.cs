using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Entity;
using POSERPAPI.Entities.Request;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Manager.Command
{
    public class CreateSaleCommand : IRequest<ProcessingStatusEntity>
    {
        public SaleRequest saleRequest;
        public CreateSaleCommand(SaleRequest _saleRequest)
        {
            saleRequest = _saleRequest;

        }
    }
}
