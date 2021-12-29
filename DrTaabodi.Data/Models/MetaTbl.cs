using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class MetaTbl
{
    

    [Key] [Required] public Guid MetaId { get; set; }
    [Required] public string MetaKey { get; set; }
    [Required] public string MetaValue { get; set; }
    
    //public Guid? PostId { get; set; }
    public PstTbl PstTbl { get; set; }
}