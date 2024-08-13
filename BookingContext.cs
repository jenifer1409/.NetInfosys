
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class BookingContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PL0KJBQ;Initial Catalog=adonet;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0");
        }

        public DbSet<VehicleCustomerDetails> VehicleCustomerDetails { get; set; }

       
    }
}
