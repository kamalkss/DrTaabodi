using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.WebsiteOptions
{
    public class UpdateOption
    {
        [Required]
        public Guid OptionId { get; set; }
        [Required]
        public string OptionKey { get; set; }
        [Required]
        public string OptionValue { get; set; }
    }
}
