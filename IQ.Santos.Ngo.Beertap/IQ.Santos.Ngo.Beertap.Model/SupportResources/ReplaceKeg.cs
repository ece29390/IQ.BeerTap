using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IQ.Santos.Ngo.Beertap.Model.SupportResources
{
    /// <summary>
    /// represents the replacekeg parameter
    /// </summary>
    public class ReplaceKeg: IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// gets or sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// brand of beer to replace the empty keg
        /// </summary>
        public string NewBeerBrand { get; set; }

        /// <summary>
        /// volume of Keg to replace the empty keg
        /// </summary>
        public double NewVolume { get; set; }
    }
}
