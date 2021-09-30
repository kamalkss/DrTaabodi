using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;

namespace DrTaabodi.Services.PostTable
{
    public interface IPost
    {
        public bool SaveChanges();
        public List<PstTbl> GetAllPosts();
        public PstTbl GetPostById(Guid id);
        public ServiceResponse<PstTbl> CreatePost(PstTbl WebPost);
        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public ServiceResponse<bool> UpdatePostStatus(Guid id, PstTbl postStatus);
        public ServiceResponse<bool> AddPostParent(Guid id, PstTbl postStatus);
    }
}
