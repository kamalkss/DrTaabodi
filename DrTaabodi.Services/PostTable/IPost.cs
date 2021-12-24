using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.PostTable;

public interface IPost
{
    public Task<bool> SaveChanges();
    public Task<List<PstTbl>> GetAllPosts(QnAParametes qnAParamete);
    public Task<PstTbl> GetPostById(Guid id);

    public Task<ServiceResponse<PstTbl>> CreatePost(PstTbl WebPost, ICollection<Guid> CategoriesIds = null);

    //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
    public Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, PstTbl postStatus,
        ICollection<Guid> CategoriesIds = null);

    public Task<ServiceResponse<bool>> AddPostParent(Guid id, PstTbl postStatus);
}