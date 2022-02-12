using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }
        [MaxLength]
        public string ProductDescription { get; set; }
        [StringLength(50)]
        [Required]
        public string SKU { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MRP { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        public Nullable<int> MaxLimit { get; set; }
        public Nullable<int> MinLimit { get; set; }
        public Nullable<int> StockItem { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AddedByID { get; set; }
        public int? ModifyByID { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<SaleTransaction> saleTransactions { get; set; }

    }
}
