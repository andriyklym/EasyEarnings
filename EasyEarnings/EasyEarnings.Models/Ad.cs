using System;
using System.ComponentModel.DataAnnotations;

namespace EasyEarnings.Models
{
    public class Ad
    {
        
        [Key]
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
    }
}
