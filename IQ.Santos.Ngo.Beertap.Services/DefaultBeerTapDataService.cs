using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    public class DefaultBeerTapDataService : IBeerTapDataService
    {
        public TapData GetTapDataBy(int tapId)
        {
            TapData tapData=null;

            using (var db = new BeertapDbContext())
            {
                 tapData =
                    db.Taps.Where(t => t.TapId.Equals(tapId)).Include("Office").Include("Keg").FirstOrDefault();               
            }

            return tapData;
            
        }
    }
}
