using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.PostType
{
    public class ReadPostType
    {
        [Required] public Guid PostTypeId { get; set; }
        [Required] public string PostTypeName { get; set; }
        public  Guid ParentId { get; set; }
        public Guid PostId { get; set; }
    }
}
