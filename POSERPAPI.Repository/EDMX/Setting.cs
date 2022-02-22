using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POSERPAPI.Repository.EDMX
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; }
        [StringLength(250)]
        [Required]
        public string Value { get; set; }

        public int? IntValue { get; set; }
        public bool? BoolValue { get; set; }
        public bool? status { get; set; }

    }
}
