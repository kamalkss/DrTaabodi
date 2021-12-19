﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DrTaabodi.WebApi.DTO.FileSystemDTO
{
    public class ReadFileSystem
    {
        [Required] [Key] public Guid FileSystemId { get; set; }
        public long? Size { get; set; }
        public bool? HasChilds { get; set; }
        public string Caption { set; get; }
        public string Description { set; get; }
        public bool? IsFile { get; set; }
        [Required]public string FileFolderPath { get; set; }
        [Required] public string Name { get; set; }
        public string Version { get; set; }
        public string ImageRuntimeVersion { get; set; }
        public string Compilation { get; set; }
        public string Extension { get; set; }

        public Guid? ParentId { get; set; }
    }
}
