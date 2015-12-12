using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentilla.Models
{
    public enum AllowanceType
    {
        Money,
        Food,
        Nothing,
        Other
    }
    public class Allowance
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public AllowanceType TypeOfAllowance { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

    }

}