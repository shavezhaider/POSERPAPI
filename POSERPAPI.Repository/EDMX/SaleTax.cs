using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
   public class SaleTax
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int TaxId { get; set; }
        public Decimal TaxPercentage { get; set; }
        public Decimal TaxAmount { get; set; }
    }
}
