using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.PostCategory
{
    public class CreatePostCategory
    {
        [Required] public string CategoryName { get; set; }
        public Guid ParentId { get; set; }
        
    }
}
