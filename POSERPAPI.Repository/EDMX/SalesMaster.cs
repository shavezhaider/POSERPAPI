using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public class SalesMaster
    {
        public SalesMaster()
        {
            this.saleTransactions = new HashSet<SaleTransaction>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal? TaxAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public Decimal SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal? DiscountTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public Decimal Total { get; set; }
        public string DiscountCoupon { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AddedByID { get; set; }
        public int? ModifyByID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<SaleTransaction> saleTransactions{ get;set;}

    }
}
