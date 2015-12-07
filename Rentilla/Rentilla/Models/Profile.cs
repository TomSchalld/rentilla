using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentilla.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PictureAddress { get; set; }
        public Rank Rank { get; set; }
    }
}