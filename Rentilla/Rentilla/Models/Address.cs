using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentilla.Models
{
    public enum Building
    {
        A,
        B
    }
    public class Address
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Building Number")]
        public Building BuildingNumber { get; set; }
        [Required]
        [Display(Name = "Appartment Number")]
        public string AppartementNumber { get; set; }
    }
}