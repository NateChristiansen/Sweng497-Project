using System.Data.Entity;

namespace ErieGarbageOnline.Models.DatabaseModels
{
    public class EGODatabase : DbContext
    {
        public DbSet<Admin> Admins { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Bill> Bills { get; set; } 
        public DbSet<Message> Messages { get; set; } 
        private static readonly EGODatabase Data = new EGODatabase();

        public static EGODatabase Create()
        {
            return Data;
        }
    }
}