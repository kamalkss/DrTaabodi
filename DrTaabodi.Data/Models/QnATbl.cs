using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class QnATbl
{
    public QnATbl()
    {
        UserTable = new HashSet<UsrTbl>();
    }

    [Key] [Required] public Guid QnAId { get; set; }

    [Required] public DateTime CreatedDate { get; set; }
    [Required] public DateTime UpdatedData { get; set; }
    [Required] [MaxLength(2500)] public string Question { get; set; }
    [Required] public string Answer { get; set; }
    public virtual ICollection<UsrTbl> UserTable { get; set; }
}