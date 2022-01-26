using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Entities.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AddedByID { get; set; }
        public int? ModifyByID { get; set; }
        public string IPAddress { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
