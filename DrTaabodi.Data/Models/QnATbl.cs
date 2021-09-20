using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class QnATbl
    {
        [Key]
        [Required]
        public Guid QnAId { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }
        [Required] [MaxLength(250)] public string Question { get; set; }
        [Required] [MaxLength(1000)] public string Answer { get; set; }
        [Required] public UsrTbl UsrTbl { get; set; }
    }   
}
