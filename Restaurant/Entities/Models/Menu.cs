using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Menu
    {
        [Key]
        public int IDMenu { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Price { get; set; }
    }
}