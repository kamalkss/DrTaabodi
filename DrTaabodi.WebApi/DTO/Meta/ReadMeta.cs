using System;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.Meta;

public class ReadMeta
{
    public Guid MetaId { get; set; }

    [Required] public string MetaKey { get; set; }

    [Required] public string MetaValue { get; set; }

    public PstTbl Posttbl { get; set; }
}