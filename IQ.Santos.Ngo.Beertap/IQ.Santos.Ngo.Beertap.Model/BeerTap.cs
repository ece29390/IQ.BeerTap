using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IQ.Santos.Ngo.Beertap.Model
{
    /// <summary>
    /// class that represents beer tap
    /// </summary>
    public class BeerTap: IStatefulResource<KegLevel>, IIdentifiable<int>
    {
        /// <summary>
        /// gets or sets the office id (location)
        /// </summary>
        public string OfficeId { get; set; }

        /// <summary>
        /// gets or sets the status of Keg
        /// </summary>
        public KegLevel KegStatus { get; set; }

        /// <summary>
        /// gets or sets the kegid where the beertap is linked to
        /// </summary>
        public int KegId { get; set; }

        /// <summary>
        /// gets or sets the identifier of beertap
        /// </summary>
        public int Id { get; set; }
    }
}
