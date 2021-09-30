using System;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.DTO.QnAs
{
    public class ReadQnAs
    {
        public Guid QnAId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public ReadUsers UsrTbl { get; set; }
    }
}
