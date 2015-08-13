using ClassicJaguars.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicJaguars.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // all my DbSet<ClassNameGoesHere> ListNameGoesHere ) { get; set;}
        public DbSet<Car> Cars { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}