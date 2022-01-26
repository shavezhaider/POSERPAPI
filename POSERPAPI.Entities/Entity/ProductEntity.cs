using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Entities.Entity
{
    public class ProductEntity : BaseEntity 
    {
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public Nullable<int> MaxLimit { get; set; }
        public Nullable<int> MinLimit { get; set; }
        public Nullable<int> StockItem { get; set; }
    }
}
