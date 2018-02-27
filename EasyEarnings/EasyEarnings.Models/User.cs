using System;
using System.ComponentModel.DataAnnotations;

namespace EasyEarnings.Models
{
    public class User
    {
        
        [Key]
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Guid ActivationKey { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
