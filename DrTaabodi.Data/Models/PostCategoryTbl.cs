using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DrTaabodi.Data.Models;

public class PostCategoryTbl
{
    public PostCategoryTbl()
    {
        PostTable = new HashSet<PstTbl>().ToList();
        //this.PostType = new HashSet<PostCategoryTbl>();
    }

    [Key] [Required] public Guid PostCategoryId { get; set; }

    [Required] public string CategoryName { get; set; }
    [Required] public DateTime CreatedDate { get; set; }
    [Required] public DateTime UpdatedData { get; set; }

    //public Guid? ParentId { get; set; }

    //[ForeignKey(nameof(PostCategoryTbl))] public Guid PostCategoryParentId { get; set; }
    //public virtual ICollection<PostCategoryTbl> PostCategoryParent { get; set; }
    public Guid? ParentId { get; set; }
    public virtual PostCategoryTbl? Parent { get; set; }
    public virtual ICollection<PostCategoryTbl>? Children { get; set; }

    public virtual IList<PstTbl>? PostTable { get; set; }
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