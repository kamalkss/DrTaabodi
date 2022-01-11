using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.Meta;

public class CreateMeta
{
    [Required] public string MetaKey { get; set; }

    [Required] public string MetaValue { get; set; }

    public PstTbl Posttbl { get; set; }
}