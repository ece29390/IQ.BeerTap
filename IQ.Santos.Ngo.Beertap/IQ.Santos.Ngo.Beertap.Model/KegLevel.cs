using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Model
{
    /// <summary>
    /// custom type that describes the level of keg
    /// </summary>
    public enum KegLevel
    {
        /// <summary>
        /// New or full
        /// </summary>
        New,
        /// <summary>
        /// it means that the keg is no longer full
        /// </summary>
        GoingDown,
        /// <summary>
        /// it means that the keg reaches the 100 ml mark
        /// </summary>
        AlmostEmpty,
        /// <summary>
        /// 0 milliliter in the keg
        /// </summary>
        SheIsDry
    }
}
