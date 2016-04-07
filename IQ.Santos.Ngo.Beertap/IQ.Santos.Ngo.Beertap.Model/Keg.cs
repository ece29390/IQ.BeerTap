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
    /// class that represents the beer container
    /// </summary>
    public class Keg : IStatelessResource, IIdentifiable<int>
    {  
        /// <summary>
        /// maximum capacity of the tank
        /// </summary>
        public const double Maximumcapacity = 189270.589;

        /// <summary>
        /// warning level
        /// </summary>
        public const double MinimumCapacityIndicator = 100;
        /// <summary>
        /// represents the identifier
        /// </summary>
        public int Id { get; set; }      
        /// <summary>
        /// the brand of beer inside this keg
        /// </summary>
        public string BeerBrand { get; set; }

        /// <summary>
        /// the volume left in the tank
        /// </summary>
        public double VolumeLeft { get; set; }

        /// <summary>
        /// the remaining volume
        /// </summary>
        public double RemainingVolume => Maximumcapacity - VolumeLeft;

        /// <summary>
        /// gets or sets the beertapid where this keg is attached to
        /// </summary>
        public int BeerTapId { get; set; }
    }
}
