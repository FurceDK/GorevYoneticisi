using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Threading.Tasks;

namespace GorevYoneticisi.Models
{
    public class GorevContext : DbContext
    {
        public GorevContext() : base("GorevContext")
        {
        }

        public DbSet<Kullanici> User { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
    }
}