using MenhirSite.Model.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace MenhirSite.Model.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MenhirContext")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Logging> Logging { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                if (!(entry.Entity is IAuditable entity))
                    continue;

                var identityName = Thread.CurrentPrincipal.Identity.Name;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = identityName;
                    entity.CreatedOn = now;
                }
                else
                {
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                }

                entity.ModifiedBy = identityName;
                entity.ModifiedOn = now;
            }

            return base.SaveChanges();
        }
    }
}