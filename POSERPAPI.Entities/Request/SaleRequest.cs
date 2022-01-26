using POSERPAPI.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using POSERPAPI.Entities.Response;

namespace POSERPAPI.Entities.Request
{
   public class SaleRequest :IRequest<SaleResponse>
    { 
        public SalesMasterEntity salesMasterEntity { get; set; }
    }
}
