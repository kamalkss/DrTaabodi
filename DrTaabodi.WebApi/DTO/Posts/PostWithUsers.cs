using System;

namespace DrTaabodi.WebApi.DTO.Posts
{
    public class PostWithUsers
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedData { get; set; }

        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }

        public string PstContent { get; set; }
        public string PstTitle { get; set; }
        public string PstDescription { get; set; }
    }
}
