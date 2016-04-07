using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;

namespace IQ.Santos.Ngo.Beertap.Model.SupportResources
{
    /// <summary>
    /// action resource that describes action of getting new glass from a tap
    /// </summary>
    public class NewGlass : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// gets or sets the volume
        /// </summary>
        public double Volume { get; set; }
    }
}
