using POSERPAPI.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Manager.Interface
{
    public interface ISales
    {
        Task<ProcessingStatusEntity> AddSales();
        Task<ProcessingStatusEntity> GetAllSales();
        Task<ProcessingStatusEntity> GetSaleBySaleID();
        Task<ProcessingStatusEntity> GetSaleByCustomerID();
    }
}
