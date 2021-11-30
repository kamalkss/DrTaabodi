using System;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.Meta
{
    public class CreateMeta
    {
        [Required]
        public string OptionKey { get; set; }
        [Required]
        public string OptionValue { get; set; }
        
        public Guid PostId { get; set; }
    }
}
