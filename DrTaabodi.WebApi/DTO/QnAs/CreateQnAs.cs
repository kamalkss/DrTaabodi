using System;
using System.ComponentModel.DataAnnotations;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.DTO.QnAs
{
    public class CreateQnAs
    {
        
         public DateTime CreatedDate { get; set; }
         public DateTime UpdatedData { get; set; }
         public string Question { get; set; }
         public string Answer { get; set; }
        public ReadUsers UsrTbl { get; set; }
    }
}
