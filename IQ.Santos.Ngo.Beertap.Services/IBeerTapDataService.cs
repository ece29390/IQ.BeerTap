using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    public interface IBeerTapDataService
    {
        /// <summary>
        /// gets TapData by
        /// </summary>
        /// <param name="tapId">primary key of tap object</param>
        /// <returns>IQ.Santos.Ngo.Beertap.Persistence.TapData object</returns>
        TapData GetTapDataBy(int tapId);
    }
}
