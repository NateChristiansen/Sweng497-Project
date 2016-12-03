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

        private Dictionary<Databases, List<DbItem>> data;

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
        }

        public static EGODatabase Create()
        {
            if (database != null) return database;
            database = new EGODatabase();
            
            return database;
        }

        public void init()
        {
            database.data = new Dictionary<Databases, List<DbItem>>
            {
                [Databases.Customers] = new List<DbItem>(),
                [Databases.Admins] = new List<DbItem>(),
                [Databases.Bills] = new List<DbItem>(),
                [Databases.Complaints] = new List<DbItem>(),
                [Databases.Suspensions] = new List<DbItem>(),
                [Databases.Disputes] = new List<DbItem>()
            };
            database.AddAdmin(new Admin
            {
                Email = "test@test.com",
                Firstname = "testmin",
                Lastname = "mctest",
                Password = "test"
            });
            database.AddCustomer(new Customer
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
            database.AddCustomer(new Customer
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
            database.AddCustomer(new Customer
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
            database.AddBill(new Bill
            {
                Amount = new decimal(6999999999.9),
                CustomerId = 2,
                Paid = false
            });
            database.AddBill(new Bill
            {
                Amount = new decimal(10),
                CustomerId = 1,
                Paid = true
            });
            database.AddBill(new Bill
            {
                Amount = new decimal(100),
                CustomerId = 0,
                Paid = true
            });
            database.AddBill(new Bill
            {
                Amount = new decimal(100),
                CustomerId = 0,
                Paid = false
            });
            database.AddBill(new Bill
            {
                Amount = new decimal(50),
                CustomerId = 1,
                Paid = true
            });
            database.AddComplaint(new Complaint
            {
                CustomerId = 0,
                MessageBody = "You suck"
            });
            database.AddComplaint(new Complaint
            {
                CustomerId = 1,
                MessageBody = "You really sux"
            });
            database.AddSuspension(new Suspension
            {
                CustomerId = 2,
                MessageBody = "I am homeless",
                SuspensionEnds = new DateTime(2016, 12, 3)
            });
            database.AddDispute(new Dispute
            {
                BillId = 2,
                MessageBody = "pls cancle",
                CustomerId = 0
            });
        }

        public List<Customer> Customers()
        {
            return data[Databases.Customers].Cast<Customer>().ToList();
        }

        private void SaveChanges()
        {
            using (var sw = File.Open(location, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(sw, data);
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
            var messages = data[Databases.Complaints].ToList();
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
                if (data[Databases.Customers].All(c => c.Id == complaint.CustomerId)) return false;
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
                if (data[Databases.Customers].All(c => c.Id == bill.CustomerId)) return false;
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
            if (Admins().Any(admin => email.Equals(admin.Email)))
            {
                return true;
            }

            if (Customers().Any(admin => email.Equals(admin.Email)))
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
                if (data[Databases.Customers].All(c => c.Id == dispute.CustomerId)) return false;
                if (data[Databases.Bills].All(b => b.Id == dispute.BillId)) return false;
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
                if (data[Databases.Customers].All(c => c.Id == suspension.CustomerId)) return false;
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

        public bool PayBill(Bill b)
        {
            try
            {
                var set = data[Databases.Bills];
                var bi = set.FirstOrDefault(bill => bill.Id == b.Id);
                if (bi == null) return false;
                ((Bill) bi).Paid = true;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ViewMessage(Message m)
        {
            try
            {
                var msg = GetMessage(m);
                if (msg == null) return false;
                msg.Viewed = true;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RespondToMessage(Message m)
        {
            try
            {
                var msg = GetMessage(m);
                if (msg == null) return false;
                msg.Responded = true;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Message GetMessage(Message m)
        {
            List<DbItem> set = null;
            if (m.GetType() == typeof(Complaint))
            {
                set = data[Databases.Complaints];
            }
            else if (m.GetType() == typeof(Dispute))
            {
                set = data[Databases.Disputes];
            }
            else if (m.GetType() == typeof(Suspension))
            {
                set = data[Databases.Suspensions];
            }
            var msg = set?.FirstOrDefault(c => c.Id == m.Id) as Message;
            return msg;
        }
    }
}
