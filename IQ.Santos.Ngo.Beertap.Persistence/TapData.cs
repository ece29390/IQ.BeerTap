using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Persistence
{
    [Table("Tap")]
    public class TapData
    {
        [Key]
        public int TapId { get; set; }

        public string OfficeName { get; set; }

        [ForeignKey("OfficeName")]
        public OfficeData Office { get; set; }

        public int KegId { get; set; }

        [ForeignKey("KegId")]
        public KegData Keg { get; set; }
    }
}
