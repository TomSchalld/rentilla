using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Rentilla.Models
{
    public class Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public Categorie categorie { get; set; }
    }
    public class ObjectDbContext : DbContext
    {
        public DbSet<Object> Objects { get; set; }
    }

}