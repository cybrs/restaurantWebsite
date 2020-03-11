using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }

        public List<Menu> Menu { get; set; }
        
    }
}