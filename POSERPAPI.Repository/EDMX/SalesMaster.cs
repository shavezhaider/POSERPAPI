using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public class SalesMaster
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public Decimal? TaxAmount { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal? DiscountTotal { get; set; }
        public Decimal Total { get; set; }
        public string DiscountCoupon { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AddedByID { get; set; }
        public int? ModifyByID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
