using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ErieGarbageOnline.Models;

namespace ErieGarbageOnline.Database
{
    class EGODatabase
    {
        private static EGODatabase database;
        private readonly string location = "Database.ego";
        private readonly Dictionary<Databases, List<DbItem>> data;

        private EGODatabase()
        {
            try
            {
                using (var sr = File.Open(location, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    data = formatter.Deserialize(sr) as Dictionary<Databases, List<DbItem>>;
                }
            }
            catch (Exception)
            {
                data = null;
            }
            if (data == null)
            {
                data = new Dictionary<Databases, List<DbItem>>
                {
                    [Databases.Customers] = new List<DbItem>(),
                    [Databases.Admins] = new List<DbItem>(),
                    [Databases.Bills] = new List<DbItem>(),
                    [Databases.Complaints] = new List<DbItem>(),
                    [Databases.Suspensions] = new List<DbItem>(),
                    [Databases.Disputes] = new List<DbItem>()
                };
            }
        }

        public static EGODatabase Create()
        {
            return database ?? (database = new EGODatabase());
        }

        public List<Customer> Customers()
        {
            return data[Databases.Customers].Cast<Customer>().ToList();
        }

        public void SaveChanges()
        {
            using (var sw = File.Open(location, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(sw, data);
            }
        }

        enum Databases
        {
            Customers,
            Admins,
            Complaints,
            Suspensions,
            Disputes,
            Bills
        }

        public List<Admin> Admins()
        {
            return data[Databases.Admins].Cast<Admin>().ToList();
        }

        public List<Bill> Bills()
        {
            return data[Databases.Bills].Cast<Bill>().ToList();
        }
    }
}
