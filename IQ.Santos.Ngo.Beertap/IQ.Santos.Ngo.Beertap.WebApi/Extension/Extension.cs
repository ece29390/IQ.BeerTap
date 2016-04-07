using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Santos.Ngo.Beertap.Model;
using IQ.Santos.Ngo.Beertap.Persistence;

namespace IQ.Santos.Ngo.Beertap.WebApi.Extension
{
    public static class Extension
    {
        public static KegLevel ToKegLevel(this TapData tap)
        {
            var returnKegLevel = KegLevel.New;

            if (tap.Keg.VolumeLeft < Keg.Maximumcapacity && tap.Keg.VolumeLeft > Keg.MinimumCapacityIndicator)
            {
                returnKegLevel = KegLevel.GoingDown;
            }
            else if (tap.Keg.VolumeLeft <= Keg.MinimumCapacityIndicator && tap.Keg.VolumeLeft > 0)
            {
                returnKegLevel = KegLevel.AlmostEmpty;                
            }
            else if(tap.Keg.VolumeLeft==0)
            {
                returnKegLevel = KegLevel.SheIsDry;
            }

            return returnKegLevel;
        }
    }
}