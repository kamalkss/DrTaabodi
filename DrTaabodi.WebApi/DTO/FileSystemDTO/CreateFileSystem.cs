using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.FileSystemDTO
{
    public class CreateFileSystem
    {
        public long? Size { get; set; }
        public bool? HasChilds { get; set; }
        public bool? IsFile { get; set; }
        [Required] public string FileFolderPath { get; set; }
        [Required] public string Name { get; set; }
        public string Version { get; set; }
        public string ImageRuntimeVersion { get; set; }
        public string Compilation { get; set; }
        public string Extension { get; set; }

        public Guid? ParentId { get; set; }
    }
}
