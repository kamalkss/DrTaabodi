using System;
using DrTaabodi.Data.Models;

namespace DrTaabodi.WebApi.DTO.Users
{
    public class CreateUsers
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedData { get; set; }
        public string UserName { get; set; }
        public string PassCode { get; set; }
        public string UsrNickName { get; set; }
        public string UsrFamily { get; set; }
        public string UsrEmail { get; set; }
        public UserStatus UsrStatus { get; set; }
    }
}
