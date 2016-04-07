using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Persistence
{
    [Table("Keg")]
    public class KegData
    {
        public KegData()
        {
            VolumeLeft = 189270.589;
        }
        [Key]
        public int KegId { get; set; }

        [StringLength(50)]
        public string BeerBrand { get; set; }

        public double VolumeLeft { get; set; }


    }
}
