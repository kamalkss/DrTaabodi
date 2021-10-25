using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.Data.Models
{
    public class WebsiteOptionsTbl
    {
        [Key]
        [Required]
        public int OptionId { get; set; }
        [Required]
        public string OptionKey { get; set; }
        [Required]
        public string OptionValue { get; set; }

    }
}
