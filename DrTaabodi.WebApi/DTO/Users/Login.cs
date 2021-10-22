using System.ComponentModel.DataAnnotations;

namespace DrTaabodi.WebApi.DTO.Users
{
    public class Login
    {
        //useless comments
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassCode { get; set; }
    }
}
