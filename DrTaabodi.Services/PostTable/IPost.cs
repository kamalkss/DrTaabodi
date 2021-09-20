using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.PostTable
{
    public interface IPost
    {
        public bool SaveChanges();
        public List<PstTbl> GetAllPosts();
        public PstTbl GetPostById(Guid id);
        public ServiceResponse<PstTbl> CreatePost(PstTbl WebPost);
        public ServiceResponse<bool> UpdatePostType(Guid id, PstType UsrStatus);
        public ServiceResponse<bool> UpdatePostStatus(Guid id, PstStatus UsrStatus);
    }
}
