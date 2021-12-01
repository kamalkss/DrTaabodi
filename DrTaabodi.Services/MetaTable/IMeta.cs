using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.MetaTable;

public interface IMeta
{
    public Task<bool> SaveChanges();
    public Task<IEnumerable<MetaTbl>> GetAllPosts();
    public Task<MetaTbl> GetPostById(Guid id);

    public Task<ServiceResponse<MetaTbl>> CreatePost(MetaTbl WebPost);

    //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
    public Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, MetaTbl postStatus);
    Task<IEnumerable<MetaTbl>> GetMetasWithPostId(Guid id);
}