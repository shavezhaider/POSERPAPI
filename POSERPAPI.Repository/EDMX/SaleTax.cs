using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
   public class SaleTax
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int TaxId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal TaxPercentage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal TaxAmount { get; set; }
    }
}
