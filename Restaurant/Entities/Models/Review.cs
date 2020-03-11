using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Restaurant.Models
{
    public class Review
    {
        [Key]
        public int IdReview { get; set; }
        public User User { get; set; }
        public Menu Menu{ get; set; }
}
}
