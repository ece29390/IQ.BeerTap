using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Persistence
{
    public class Configuration: DbMigrationsConfiguration<BeertapDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BeertapDbContext context)
        {
            var kegs = new List<KegData>();
            SeedKegs(1, "Alexander Keith's Brewery",context, kegs);
            SeedKegs(2, "All or Nothing Brewhouse", context, kegs);
            SeedKegs(3, "Annedd'ale", context, kegs);
            SeedKegs(4, "Big Rock Brewery", context, kegs);

            SeedKegs(5, "Carling Black Label", context, kegs);
            SeedKegs(6, "Carling brewery", context, kegs);
            SeedKegs(7, "Coors Light", context, kegs);
            SeedKegs(8, "Drewrys", context, kegs);

            SeedKegs(9, "James Ready (beer)", context, kegs);
            SeedKegs(10, "King Snedley's Beer", context, kegs);
            SeedKegs(11, "Kokanee beer", context, kegs);
            SeedKegs(12, "Labatt 50", context, kegs);

            var offices = new List<OfficeData>();
            SeedOffice(context, "Vancouver", offices);
            SeedOffice(context, "Regina", offices);
            SeedOffice(context, "Winnipeg", offices);
            SeedOffice(context, "Davidson", offices);

            SeedTap(context, 1, kegs[0], offices[0]);
            SeedTap(context, 2, kegs[1], offices[0]);
            SeedTap(context, 3, kegs[2], offices[0]);

            SeedTap(context, 4, kegs[3], offices[1]);
            SeedTap(context, 5, kegs[4], offices[1]);
            SeedTap(context, 6, kegs[5], offices[1]);

            SeedTap(context, 7, kegs[6], offices[2]);
            SeedTap(context, 8, kegs[7], offices[2]);
            SeedTap(context, 9, kegs[8], offices[2]);

            SeedTap(context, 10, kegs[9], offices[3]);
            SeedTap(context, 11, kegs[10], offices[3]);
            SeedTap(context, 12, kegs[11], offices[3]);

            base.Seed(context);
          

        }

        private void SeedKegs(int kegid, string beerbrand, BeertapDbContext context,List<KegData> listofkegs)
        {
            var @select = context.Kegs.Select(k => k.BeerBrand.Equals(beerbrand));
            var keg = new KegData { KegId = kegid, BeerBrand = beerbrand };
            listofkegs.Add(keg);
            if (!@select.Any())
            {                            
                context.Kegs.Add(keg);
            }
            
        }

        private void SeedOffice(BeertapDbContext context,string officename,List<OfficeData> offices)
        {
            var @select = context.Offices.Select(o => o.Name.Contains(officename));
            var office = new OfficeData { Name = officename };
            offices.Add(office);
            if (!@select.Any())
            {
                context.Offices.Add(office);
            }
        }

        private void SeedTap(BeertapDbContext context,int beertapid,KegData keg, OfficeData office )
        {
            var @select = context.Taps.Select(o => o.TapId.Equals(beertapid));

            if (!@select.Any())
            {
                var tap = new TapData
                {
                    TapId = beertapid             
                    ,OfficeName = office.Name                 
                    ,KegId = keg.KegId
                };                
                context.Taps.Add(tap);
            }
        }

        
    }
}
