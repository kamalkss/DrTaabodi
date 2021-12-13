using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class PstTbl
{
    public PstTbl()
    {
        PostTypeTable = new HashSet<PostTypeTbl>();
        PostCategoryTable = new HashSet<PostCategoryTbl>();
        UserTable = new HashSet<UsrTbl>();
        //PstTblParent = new HashSet<PstTbl>();
    }

    [Key] [Required] public Guid PstId { get; set; }

    //[Required] public UsrTbl User { get; set; }
    [Required] public DateTime CreatedDate { get; set; }
    [Required] public DateTime UpdatedData { get; set; }

    [Required] public string PstContent { get; set; }
    [Required] public string PstTitle { get; set; }
    [Required] public string PstDescription { get; set; }
    public Guid? ParentId { get; set; }
    public virtual PstTbl Parent { get; set; }
    public virtual ICollection<PstTbl> Children { get; set; }


    //[ForeignKey(nameof(PstTbl))]
    //public Guid PostParentId { get; set; }


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