using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentilla.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategorieDbContext : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }
    }
}