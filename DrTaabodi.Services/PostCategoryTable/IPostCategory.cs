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
        public bool SaveChanges();
        public List<PostCategoryTbl> GetAllPosts();
        public PostCategoryTbl GetPostById(Guid id);
        public ServiceResponse<PostCategoryTbl> CreatePost(PostCategoryTbl WebPost);
        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public ServiceResponse<bool> UpdatePostStatus(Guid id, PostCategoryTbl postStatus);
    }
}
