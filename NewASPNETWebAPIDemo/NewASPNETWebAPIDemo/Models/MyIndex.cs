using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewASPNETWebAPIDemo.Models
{
    public class MyIndex
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile is required!")]
        [StringLength(25, ErrorMessage = "Mobile number can't be more than 25 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
    }
}