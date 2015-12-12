using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
        public List<Demand> Demands { get; set; }
       

    }
    public enum Acceptance
    {
        Unanswered,
        Accepted,
        Refused
    }
    public class Demand : InterChange
    {
        public Acceptance Accepted { get; set; } //0 - No answer yet, 1 - Accepted, 2 - Refused
       // [Required(ErrorMessage = "Start Date is required.")]
        public DateTime DateStart { get; set; }
        //[Required(ErrorMessage = "End Date is required.")]
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

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }*/

    }

}