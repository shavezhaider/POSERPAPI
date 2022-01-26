using System;
using System.Collections.Generic;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public Nullable<int> MaxLimit { get; set; }
        public Nullable<int> MinLimit { get; set; }
        public Nullable<int> StockItem { get; set; }
        
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AddedByID { get; set; }
        public int? ModifyByID { get; set; }        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
