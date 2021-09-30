using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.PostCategoryTable
{
    public interface IPostType
    {
        public bool SaveChanges();
        public List<PostTypeTbl> GetAllPosts();
        public PostTypeTbl GetPostById(Guid id);
        public ServiceResponse<PostTypeTbl> CreatePostType(PostTypeTbl WebPost);
        public ServiceResponse<bool> UpdatePostType(Guid id, PostTypeTbl WebPost);
        public ServiceResponse<bool> EditParent(Guid id, Guid ParentId);
        
        public ServiceResponse<bool> AddPosts(Guid id,PstTbl WebPost);
        public ServiceResponse<bool> RemovePosts(Guid id, PstTbl WebPost);


    }
}
