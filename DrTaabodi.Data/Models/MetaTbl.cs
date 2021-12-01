using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class MetaTbl
{
    public MetaTbl()
    {
        PstTbls = new HashSet<PstTbl>();
    }

    [Key] [Required] public Guid MetaId { get; set; }
    [Required] public string MetaKey { get; set; }
    [Required] public string MetaValue { get; set; }
    public virtual ICollection<PstTbl> PstTbls { get; set; }
}