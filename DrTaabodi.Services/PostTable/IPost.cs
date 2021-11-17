using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrTaabodi.Services.PostTable
{
    public interface IPost
    {
        public Task<bool> SaveChanges();
        public Task<List<PstTbl>> GetAllPosts();
        public Task<PstTbl> GetPostById(Guid id);
        public Task<ServiceResponse<PstTbl>> CreatePost(PstTbl WebPost);
        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, PstTbl postStatus);
        public Task<ServiceResponse<bool>> AddPostParent(Guid id, PstTbl postStatus);
    }
}
