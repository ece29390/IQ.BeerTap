using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    public class DefaultKegDataService : IKegDataService
    {
        public KegData GetKegDataBy(int kegId)
        {
            KegData keg = null;

            using (var db = new BeertapDbContext())
            {
                keg = db.Kegs.Where(k => k.KegId.Equals(kegId)).FirstOrDefault();
            }

            return keg;
        }

        public List<KegData> GetKegsBy(string officeId, int beertapId)
        {
            List<KegData> kegs=null;

            using (var db = new BeertapDbContext())
            {
                var @selectTap = db.Taps.Where(t => t.TapId.Equals(beertapId)).Include("Keg");

                if (@selectTap.Any())
                {
                    var tap = @selectTap.First();

                    kegs = new List<KegData>
                    {
                        tap.Keg
                    };
                }
            }

            return kegs;
        }

        private KegData SaveNewKeg(BeertapDbContext db, KegData newKegData)
        {           
            var keg = db.Kegs.Add(newKegData);
            db.SaveChanges();
            return keg;
        }

        private void ModifyReferenceOfTap(BeertapDbContext db,TapData tapData,KegData newlySavedKeg)
        {
            tapData.Keg = newlySavedKeg;
            tapData.KegId = newlySavedKeg.KegId;
            db.Entry(tapData).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void ReplaceOldKegInTap(TapData tapData, KegData newKegData)
        {
            using (var db = new BeertapDbContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var oldKeg = tapData.Keg;
                        var newlySavedKeg = SaveNewKeg(db, newKegData);

                        ModifyReferenceOfTap(db,tapData,newlySavedKeg);

                        var @selectKeg = db.Kegs.Where(k => k.KegId.Equals(oldKeg.KegId)).First();

                        db.Kegs.Remove(@selectKeg);                                                           
                        
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateKeg(KegData keg)
        {
            using (var db = new BeertapDbContext())
            {
                db.Entry(keg).State= EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}
