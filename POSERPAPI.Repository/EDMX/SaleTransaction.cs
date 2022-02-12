using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public class SaleTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public int SalesId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MRP { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalesPrice { get; set; }        
        public virtual  SalesMaster salesMasterTran { get; set; }
        public virtual Product productMasterTran { get; set; }

    }
}
