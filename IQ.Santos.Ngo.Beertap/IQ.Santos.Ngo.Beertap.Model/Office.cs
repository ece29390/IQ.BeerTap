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
    /// class that represents the IQMetrix offices i.e Regina, Vancouver, Winnipeg, Davidson, Manila.
    /// </summary>
    public class Office : IStatelessResource, IIdentifiable<string>
    {
        /// <summary>
        /// id represents the location or office name, to make it straight forward.
        /// </summary>       
        public string Id { get; set; }

        /// <summary>
        /// list of beertaps on the office
        /// </summary>
        public IList<BeerTap> BeerTaps { get; set; } 
    }
}
