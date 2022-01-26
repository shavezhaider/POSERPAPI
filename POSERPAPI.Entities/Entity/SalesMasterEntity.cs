using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Entities.Entity
{
    public class SalesMasterEntity :  BaseEntity
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public Decimal? TaxAmount { get; set; }
        public Decimal SubTotal { get; set; }

        public Decimal? DiscountTotal { get; set; }
        public Decimal Total { get; set; }
        public string DiscountCoupon { get; set; }
        IEnumerable<SaleTransactionEntity> saleTransactionlist { get; set; }
        IEnumerable<SaleTaxEntity> saleTaxlist { get; set; }
    }
}
