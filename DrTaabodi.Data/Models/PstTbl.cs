using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public  class PstTbl
    {
        [Key][Required] public Guid PstId { get; set; }
        [Required] public UsrTbl User { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }

        [Required] public string PstContent { get; set; }
        [Required] public string PstTitle { get; set; }
        [Required] public string PstDescription { get; set; }
        [Required] public PstStatus PstStatus { get; set; }
        [Required] public PstType PstType { get; set; }

        public PstTbl PstTbleParent { get; set; }
    }

    public enum PstStatus
    {
        Active,
        Hidden
    }

    public enum PstType
    {
        Blog,
        Article,
        Page
    }
}
