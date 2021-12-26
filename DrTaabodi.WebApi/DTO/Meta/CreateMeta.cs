using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.Meta;

public class CreateMeta
{
    [Required] public string MetaKey { get; set; }

    [Required] public string MetaValue { get; set; }

    public Guid PostId { get; set; }
}