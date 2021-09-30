using System;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.Users;

namespace DrTaabodi.WebApi.DTO.Posts
{
    public class ReadPosts
    {
        public Guid PstId { get; set; }
        public UsrTbl User { get; set; }
        public string PstContent { get; set; }
        public string PstTitle { get; set; }
        public string PstDescription { get; set; }
        public PstStatus PstStatus { get; set; }
        public PstType PstType { get; set; }

        public PstTbl PstTbleParent { get; set; }
    }
}
