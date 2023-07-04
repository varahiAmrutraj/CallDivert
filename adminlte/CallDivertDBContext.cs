using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using adminlte.Models;
using System.Data.Entity;
using Npgsql;

namespace adminlte
{
    public class CallDivertDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public CallDivertDBContext()
        {
            
            
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }
        }
        

        //public CallDivertDBContext() : base(GetConnectionString())
        //{
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // NpgsqlConnection.RemoveGlobalTypeMappingConvention();
        }

        private static string GetConnectionString()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            

            return connectionString;
        }
    }
}

