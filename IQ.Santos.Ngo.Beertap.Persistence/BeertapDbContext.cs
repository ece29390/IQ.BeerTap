using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Persistence
{
    public class BeertapDbContext: DbContext
    {
        public BeertapDbContext(): base("name=BeertapDbConnectionString") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeertapDbContext, Configuration>("BeertapDbConnectionString"));

        }

        public DbSet<TapData> Taps { get; set; }
        public DbSet<OfficeData> Offices { get; set; }

        public DbSet<KegData> Kegs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
