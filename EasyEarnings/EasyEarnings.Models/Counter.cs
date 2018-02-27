using System;
using System.ComponentModel.DataAnnotations;

namespace EasyEarnings.Models
{
    public class Counter
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid AdID { get; set; }
        public Ad Ad { get; set; }
        public int Count { get; set; }
    }
}
