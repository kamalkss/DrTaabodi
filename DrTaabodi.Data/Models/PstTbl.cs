using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class PstTbl
    {
        public PstTbl()
        {
            this.PostTypeTable = new HashSet<PostTypeTbl>();
            this.PostCategoryTable = new HashSet<PostCategoryTbl>();
            this.UserTable = new HashSet<UsrTbl>();
        }
        [Key] [Required] public Guid PstId { get; set; }
        //[Required] public UsrTbl User { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }

        [Required] public string PstContent { get; set; }
        [Required] public string PstTitle { get; set; }
        [Required] public string PstDescription { get; set; }
        

        //[ForeignKey(nameof(PstTbl))]
        //public Guid PostParentId { get; set; }

        public virtual ICollection<PstTbl> PstTblParent { get; set; }

        public virtual ICollection<PostTypeTbl> PostTypeTable { get; set; }
        public virtual ICollection<PostCategoryTbl> PostCategoryTable { get; set; }
        public virtual ICollection<UsrTbl> UserTable { get; set; }
        //public virtual ICollection<PstTbl> ChildDependencies { get; set; } = new List<PstTbl>();
        //public virtual ICollection<PstTbl> ParentDependencies { get; set; } = new List<PstTbl>();
    }

    public class PostTblRelations
    {
        public Guid PostParentId { get; set; }
        public PstTbl Parent { get; set; }


        public Guid PostChildId { get; set; }
        public PstTbl Child { get; set; }
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
