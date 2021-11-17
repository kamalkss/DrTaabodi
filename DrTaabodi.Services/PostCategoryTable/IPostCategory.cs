using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.PostCategoryTable
{
    public interface IPostCategory
    {
        public Task<bool> SaveChanges();
        public Task<List<PostCategoryTbl>> GetAllPosts();
        public Task<PostCategoryTbl> GetPostById(Guid id);
        public Task<ServiceResponse<PostCategoryTbl>> CreatePost(PostCategoryTbl WebPost);
        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, PostCategoryTbl postStatus);
    }
}
