using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class QnATbl
    {
        public QnATbl()
        {
            this.UserTable = new HashSet<UsrTbl>();
        }
        [Key]
        [Required]
        public Guid QnAId { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }
        [Required] [MaxLength(250)] public string Question { get; set; }
        [Required] [MaxLength(1000)] public string Answer { get; set; }
        public virtual ICollection<UsrTbl> UserTable { get; set; }
    }   
}
