using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.Services
{
    public interface IOfficeDataService
    {
        /// <summary>
        /// gets office data object
        /// </summary>
        /// <param name="id">location</param>
        /// <returns>IQ.Santos.Ngo.Beertap.Persistence.OfficeData object</returns>
        OfficeData GetOfficeBy(string id);

        /// <summary>
        /// gets list of offices
        /// </summary>
        List<OfficeData> GetOffices();
    }
}
