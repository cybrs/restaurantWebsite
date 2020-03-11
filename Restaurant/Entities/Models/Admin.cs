using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPhone { get; set; }
        public string AdminEmail { get; set; }
        public string AdminUsername { get; set; }
        public string AdmninPassword { get; set; }

        public List<Menu> Menu { get; set; }
    }
}