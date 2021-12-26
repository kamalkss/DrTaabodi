using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.Meta;

public class ReadMeta
{
    public Guid MetaId { get; set; }

    [Required] public string MetaKey { get; set; }

    [Required] public string MetaValue { get; set; }

    public Guid PostId { get; set; }

}