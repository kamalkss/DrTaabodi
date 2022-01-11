using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.PostType;

public class ReadPostType
{
    public Guid PostTypeId { get; set; }
    [Required] public string PostTypeName { get; set; }
    public Guid ParentId { get; set; }
    public ICollection<Guid> PostId { get; set; }
}