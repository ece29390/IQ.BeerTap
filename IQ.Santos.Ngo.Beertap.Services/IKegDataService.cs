using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    public interface IKegDataService
    {
        KegData GetKegDataBy(int kegId);

        List<KegData> GetKegsBy(string officeId, int beertapId);
        void UpdateKeg(KegData keg);
        void ReplaceOldKegInTap(TapData tapData, KegData newKegData);
    }
}
