using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Data.Models
{
    public class FileSystemTbl
    {
        [Required] [Key] public Guid FileSystemId { get; set; }
        [Required] public DateTime? CreationTime { get; set; }
        [Required] public DateTime? LastWriteTime { get; set; }
        public long? Size { get; set; }
        public bool? HasChilds { get; set; }
        public bool? IsFile { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string ImageRuntimeVersion { get; set; }
        public string Compilation { get; set; }
        public string Extension { get; set; }

        public Guid? ParentId { get; set; }
        public virtual FileSystemTbl Parent { get; set; }
        public virtual ICollection<FileSystemTbl> Children { get; set; }
    }
}
