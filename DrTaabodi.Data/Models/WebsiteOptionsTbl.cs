using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models;

public class WebsiteOptionsTbl
{
    [Key] [Required] public Guid OptionId { get; set; }

    [Required] public string OptionKey { get; set; }

    [Required] public string OptionValue { get; set; }
}