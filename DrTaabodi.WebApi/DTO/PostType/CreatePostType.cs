using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.PostType;

public class CreatePostType
{
    [Required] public string PostTypeName { get; set; }

    public Guid ParentId { get; set; }
}