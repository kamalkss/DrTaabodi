using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.PostTypeTable
{
    public interface IPostType
    {
        public Task<bool> SaveChanges();
        public Task<List<PostTypeTbl>> GetAllPosts();
        public Task<PostTypeTbl> GetPostById(Guid id);
        public Task<ServiceResponse<PostTypeTbl>> CreatePostType(PostTypeTbl WebPost);
        public Task<ServiceResponse<bool>> UpdatePostType(Guid id, PostTypeTbl WebPost);
        public Task<ServiceResponse<bool>> EditParent(Guid id, Guid ParentId);
        
        public Task<ServiceResponse<bool>> AddPosts(Guid id,PstTbl WebPost);
        public Task<ServiceResponse<bool>> RemovePosts(Guid id, PstTbl WebPost);


    }
}
