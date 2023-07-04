using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using adminlte.Models;
namespace adminlte
{
    public class CallDivertDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }
        // Constructor to provide the connection string or name
        
        public CallDivertDBContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
        }
    }
}
