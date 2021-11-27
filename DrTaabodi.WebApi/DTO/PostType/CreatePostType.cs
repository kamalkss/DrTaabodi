using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.PostType
{
    public class CreatePostType
    {
        [Required] public string PostTypeName { get; set; }
       
        public Guid ParentId { get; set; }
    }
}
