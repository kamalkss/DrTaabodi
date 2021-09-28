using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class PostCategoryTbl
    {
        public PostCategoryTbl()
        {
            this.PostTable = new HashSet<PstTbl>();
            //this.PostType = new HashSet<PostCategoryTbl>();
        }
        [Key]
        [Required] public Guid PostCategoryId { get; set; }
        [Required] public string CategoryName {  get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }

        [ForeignKey(nameof(PostCategoryTbl))]public Guid PostCategoryParentId {  get; set; }
        public PostCategoryTbl PostCategory { get; set; }

        public virtual ICollection<PstTbl> PostTable { get; set; }
        //public virtual ICollection<PostCategoryTblRelation> PostCategory { get; set; }
        //public virtual ICollection<PostCategoryTblRelation> PostCategoryParent { get; set; }



    }

    public class PostCategoryTblRelation
    {
        public Guid PostCategoryParentId { get; set; }
        public PostCategoryTbl Parent { get; set; }


        public Guid PostCategoryChildId { get; set; }
        public PostCategoryTbl Child { get; set; }
    }
}
