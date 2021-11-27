using System;
using DrTaabodi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Services.MetaTable
{
    internal interface IMeta
    {
        public Task<bool> SaveChanges();
        public Task<IEnumerable<MetaTbl>> GetAllPosts();
        public Task<MetaTbl> GetPostById(Guid id);
        public Task<ServiceResponse<MetaTbl>> CreatePost(MetaTbl WebPost);
        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, MetaTbl postStatus);
        
    }
}
