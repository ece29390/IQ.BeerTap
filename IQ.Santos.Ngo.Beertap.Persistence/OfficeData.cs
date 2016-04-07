using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.Santos.Ngo.Beertap.Persistence
{
    [Table("Office")]
    public class OfficeData
    {
        public OfficeData()
        {
            Taps = new List<TapData>();
        }
        [Key]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<TapData> Taps { get; set; } 
    }
}
