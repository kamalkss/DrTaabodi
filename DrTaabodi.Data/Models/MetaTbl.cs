using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class MetaTbl
    {
        public MetaTbl()
        {
            this.PstTbls = new HashSet<PstTbl>();
        }
        [Key][Required] public Guid MetaId { get; set; }
        [Required] public string MetaKey { get; set;}
        [Required] public string MetaValue { get; set; }
        public virtual ICollection<PstTbl> PstTbls { get; set;}
    }
}
