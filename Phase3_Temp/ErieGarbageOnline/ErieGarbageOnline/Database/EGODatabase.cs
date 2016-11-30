using System.Collections.Generic;
using System.IO;
using ErieGarbageOnline.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErieGarbageOnline.Database
{
    class EGODatabase
    {
        private static EGODatabase database;
        private readonly string location = "Database.json";
        private dynamic data;

        private EGODatabase()
        {
            using (var sr = new StreamReader(location))
            {
                data = JsonConvert.DeserializeObject<dynamic>(sr.ReadToEnd());
            }
        }

        public static EGODatabase Create()
        {
            return database ?? (database = new EGODatabase());
        }

        public List<Customer> Customers()
        {
            return ((JArray) data.Customers).ToObject<List<Customer>>();
        }

        public void SaveChanges()
        {
            using (var sw = new StreamWriter(location))
            {
                var json = JsonConvert.SerializeObject(data);

            }
        }
    }
}
