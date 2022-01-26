using POSERPAPI.Entities.Entity;
using POSERPAPI.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Implementation
{
    public class SalesManager : ISales
    {
        public Task<ProcessingStatusEntity> AddSales()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessingStatusEntity> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessingStatusEntity> GetSaleByCustomerID()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessingStatusEntity> GetSaleBySaleID()
        {
            throw new NotImplementedException();
        }
    }
}
