using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.PostCategory;

public class ReadPostCategory
{
    [Required] public Guid PostCategoryId { get; set; }
    [Required] public string CategoryName { get; set; }
    public Guid ParentId { get; set; }
    public ICollection<Guid> PostId { get; set; }
}