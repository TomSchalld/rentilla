using System;
using System.Collections.Generic;
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

        public Building BuildingNumber { get; set; }

        public string AppartementNumber { get; set; }
    }
}