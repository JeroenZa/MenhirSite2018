using EfEnumToLookup.LookupGenerator;
using MenhirSite.Model.Context;
using System.Data.Entity.Migrations;

namespace MenhirSite.Model.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = int.MaxValue;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var enumToLookup = new EnumToLookup
            {
                TableNamePrefix = "",
                UseTransaction = true
            };

            enumToLookup.Apply(context);

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
