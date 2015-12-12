using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rentilla.Models
{
    public class InterChange
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Allowance is required.")]
        public Allowance Allowance { get; set; }
    }
 
   
    public class Offer : InterChange
    {
        public LinkedList<Demand> Demands { get; set; }
       

    }
    public class Demand : InterChange
    {
        public int Accepted { get; set; } //0 - No answer yet, 1 - Accepted, -1 - Refused
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage = "End Date is required.")]
        public DateTime DateEnd { get; set; }
        public LinkedList<Offer> Offers { get; set; }
    
    }
    public class OfferDBContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }

    }
    public class DemandDBContext : DbContext
    {
        public DbSet<Demand> Demands { get; set; }

    }

}