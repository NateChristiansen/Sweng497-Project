using System.Data.Entity.Migrations;
using ErieGarbageOnline.Models.DatabaseModels;

namespace ErieGarbageOnline.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EGODatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ErieGarbageOnline.Models.DatabaseModels.EGODatabase";
        }

        protected override void Seed(EGODatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
