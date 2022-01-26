using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public class SaleTransaction
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? SalesPrice { get; set; }        

    }
}
