using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Capstone.Models
{
    public class ApplicationDBContext : DbContext
    {
        internal object Session;

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=H5CG1220SMZ;Database=HealthcareDB;Integrated security=true");
        }

        
    }

}
