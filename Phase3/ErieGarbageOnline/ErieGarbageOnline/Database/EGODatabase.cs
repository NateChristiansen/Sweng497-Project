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

        private readonly string location = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName +
                                           "/Database/Database.ego";

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
                AddAdmin(new Admin
                {
                    Email = "test@test.com",
                    Firstname = "testmin",
                    Lastname = "mctest",
                    Password = "test"
                });
                AddCustomer(new Customer
                {
                    Address = "1234 test rd",
                    City = "test",
                    Country = "test",
                    Email = "cust1@test.com",
                    Firstname = "jake",
                    Lastname = "suxk",
                    Password = "test",
                    PostalCode = "12345",
                    State = "PA"
                });
                AddCustomer(new Customer
                {
                    Address = "1235 test rd",
                    City = "test",
                    Country = "test",
                    Email = "cust2@test.com",
                    Firstname = "nate",
                    Lastname = "rulz",
                    Password = "test",
                    PostalCode = "12345",
                    State = "PA"
                });
                AddCustomer(new Customer
                {
                    Address = "1236 test rd",
                    City = "test",
                    Country = "test",
                    Email = "cust3@test.com",
                    Firstname = "alex",
                    Lastname = "nowork",
                    Password = "test",
                    PostalCode = "12345",
                    State = "PA"
                });
                AddBill(new Bill
                {
                    Amount = new decimal(6999999999.9),
                    CustomerId = 2,
                    Unpaid = true
                });
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

        private void SaveChanges()
        {
            try
            {
                using (var sw = File.Open(location, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(sw, data);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetId(List<DbItem> set, DbItem item)
        {
            if (!set.Any())
            {
                item.Id = 0;
                return;
            }
            var max = set.Select(dbItem => dbItem.Id).Concat(new[] {int.MinValue}).Max();
            item.Id = max + 1;
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

        public List<Message> AllMessages()
        {
            var messages = data[Databases.Complaints];
            messages.AddRange(data[Databases.Disputes]);
            messages.AddRange(data[Databases.Suspensions]);
            return messages.Cast<Message>().ToList();
        }

        public bool AddComplaint(Complaint complaint)
        {
            try
            {
                var set = data[Databases.Complaints];
                SetId(set, complaint);
                if (!complaint.CheckValidity()) return false;
                set.Add(complaint);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddBill(Bill bill)
        {
            try
            {
                var set = data[Databases.Bills];
                SetId(set, bill);
                if (!bill.CheckValidity()) return false;
                set.Add(bill);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddAdmin(Admin admin)
        {
            try
            {
                var set = data[Databases.Admins];
                SetId(set, admin);
                if (!admin.CheckValidity()) return false;
                if (EmailExistsInDb(admin.Email)) return false;
                set.Add(admin);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                var set = data[Databases.Customers];
                SetId(set, customer);
                if (!customer.CheckValidity()) return false;
                if (EmailExistsInDb(customer.Email)) return false;
                set.Add(customer);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EmailExistsInDb(string email)
        {
            if (this.Admins().Any(admin => email.Equals(admin.Email)))
            {
                return true;
            }

            if (this.Customers().Any(admin => email.Equals(admin.Email)))
            {
                return true;
            }

            return false;
        }

        public bool AddDispute(Dispute dispute)
        {
            try
            {
                var set = data[Databases.Disputes];
                SetId(set, dispute);
                if (!dispute.CheckValidity()) return false;
                set.Add(dispute);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddSuspension(Suspension suspension)
        {
            try
            {
                var set = data[Databases.Suspensions];
                SetId(set, suspension);
                if (!suspension.CheckValidity()) return false;
                set.Add(suspension);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
