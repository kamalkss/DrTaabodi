using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.WebsiteOptions
{
    public class CreateOption
    {
        [Required]
        public string OptionKey { get; set; }
        [Required]
        public string OptionValue { get; set; }
    }
}
