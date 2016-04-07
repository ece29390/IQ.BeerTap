using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    /// <summary>
    /// default service for office data funtionalities
    /// </summary>
    public class DefaultOfficeDataService : IOfficeDataService
    {
        public OfficeData GetOfficeBy(string id)
        {
            OfficeData office=null;

            using (var db = new BeertapDbContext())
            {
                var @select = db.Offices
                    .Where(o => o.Name.Equals(id, StringComparison.InvariantCulture))
                    .Include("Taps")
                    .Include("Taps.Keg");

                if (@select.Any())
                {
                    office = @select.First();
                }
            }
                           
            return office;
        }

        public List<OfficeData> GetOffices()
        {
            List<OfficeData> offices = null;

            using (var db = new BeertapDbContext())
            {
                offices = db.Offices
                    .Include("Taps")
                    .Include("Taps.Keg")
                    .ToList();
            }

            return offices;
        }
    }
}
