using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSERPAPI.Repository.EDMX
{
    [Table("ErrorLog")]
    public class ErrorLog
    {
        [Key]
        public long ErrorLogId { get; set; }
        public Nullable<System.DateTime> ErrorDate { get; set; }
        public string Exception { get; set; }
        
        public string Controller { get; set; }
        public string Action { get; set; }
        public string URL { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string InnerMsg { get; set; }
        public string Level { get; set; }
        public Nullable<bool> IsActive { get; set; }  
        public Nullable<int> UserID { get; set; }
        public Nullable<int> line { get; set; }
        public Nullable<int> col { get; set; }
    }

}
