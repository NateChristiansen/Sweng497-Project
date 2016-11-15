using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class EGODatabase : DbContext
    {
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Bill> Bills { get; set; } 
        public DbSet<Message> Messages { get; set; } 
    }
}