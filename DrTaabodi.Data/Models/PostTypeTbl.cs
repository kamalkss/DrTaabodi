using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class PostTypeTbl
    {
        public PostTypeTbl()
        {
            this.PostTable = new HashSet<PstTbl>();
        }
        [Key][Required] public Guid PostTypeId { get; set; }
        [Required] public string PostTypeName { get; set; }
        //public int PostTypeParent { get; set; }
        [Required] public DateTime CreatedDate { get; set; }
        [Required] public DateTime UpdatedData { get; set; }


        [ForeignKey(nameof(PostTypeTbl))] public Guid PostTypeParentId { get; set; }
        public PostTypeTbl PostType { get; set; }

        public virtual ICollection<PstTbl> PostTable { get; set; }
        //public virtual ICollection<PostTypeRelations> PostType { get; set; }
        //public virtual ICollection<PostTypeRelations> PostTypeParent { get; set; }
    }

    public class PostTypeRelations
    {
        public Guid PostTypeParentId { get; set; }
        public PostTypeTbl Parent { get; set; }


        public Guid PostTypeChildId { get; set; }
        public PostTypeTbl Child { get; set; }

    }
}
