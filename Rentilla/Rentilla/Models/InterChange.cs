using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Rentilla.Models
{
    public enum Allowance
    {
        Money,
        Food,
        Nothing,
        Other
    }
    public class InterChange
    {
        public int ID { get; set; }
        public string UID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        public Allowance Allowance { get; set; }
        [Required(ErrorMessage = "Description for the Allowance is required.")]
        public string AllowanceDescription { get; set; }
    }
    public class OfferToDem : InterChange
    {
       
        public int DemandId { get; set; }
    }
    public class DemandToOff : Demand
    {
        
        public int OfferId { get; set; }
    }
   
    public class Offer : InterChange
    {
        public List<DemandToOff> DemandsToOffer { get; set; }
       

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
        public List<OfferToDem> OffersToDemand { get; set; }
    
    }
    public class InterchangeDBContext : DbContext
    {

        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferToDem> OffersToDemands { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DemandToOff> DemandsToOffers { get; set; }

    }
    

}