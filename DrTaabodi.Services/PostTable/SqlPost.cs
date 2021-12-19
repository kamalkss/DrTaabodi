using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostTable;

public class SqlPost : IPost
{
    private readonly DrTaabodiDbContext _context;

    private readonly ILogger<SqlPost> _logger;
    //private readonly PstTbl _pstTbl;

    public SqlPost(DrTaabodiDbContext _db, ILogger<SqlPost> logger)
    {
        _context = _db;
        _logger = logger;
        // _pstTbl = pstTbl;
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<List<PstTbl>> GetAllPosts(QnAParametes qnAParametes)
    {
        return await _context.PstTbl
            .Include(c => c.UserTable)
            .Include(c => c.PostTypeTable)
            .Include(c => c.PostCategoryTable).OrderBy(c => c.UpdatedData)
            .Skip((qnAParametes.PageNumber - 1) * qnAParametes.PageSize).Take(qnAParametes.PageSize).ToListAsync();
    }

    public async Task<PstTbl> GetPostById(Guid id)
    {
        return await _context.PstTbl.Include(c => c.UserTable)
            //.Include(c => c.PstTbleParent)
            .Include(c => c.PostTypeTable)
            .Include(c => c.PostCategoryTable)
            .FirstOrDefaultAsync(p => p.PstId == id);
    }

    public async Task<ServiceResponse<PstTbl>> CreatePost(PstTbl WebPost, ICollection<Guid> CategoriesIds = null)
    {
        _logger.LogInformation("Log for Create Post");
        try
        {
            WebPost.UpdatedData = DateTime.UtcNow;
            WebPost.CreatedDate = DateTime.UtcNow;
            //var user = WebPost.UserTable;

            await _context.AddAsync(WebPost);
           if(CategoriesIds != null)
            {
                foreach (var item in CategoriesIds)
                {
                    var group = _context.PostCategoryTbl.Find(item);
                    if (group != null)
                        WebPost.PostCategoryTable.Add(group);
                }
            }
            await SaveChanges();
            return new ServiceResponse<PstTbl>
            {
                Data = WebPost,
                IsSucceess = true,
                Messege = "Post Created",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<PstTbl>
            {
                Data = null,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, PstTbl UsrStatus)
    {
        _logger.LogInformation("Log For Update Post");
        try
        {
            var WebPost = _context.PstTbl.Find(id);
            //WebPost.PstStatus = UsrStatus;
            UsrStatus.UpdatedData = DateTime.UtcNow;

            _context.Entry(WebPost).CurrentValues.SetValues(UsrStatus);


            //_context.PstTbl.Update(WebPost);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                IsSucceess = true,
                Data = true,
                Messege = " Post Updated",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                IsSucceess = false,
                Data = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }


    public async Task<ServiceResponse<bool>> AddPostParent(Guid id, PstTbl postStatus)
    {
        var Child = _context.PstTbl.Find(id);
        //var Parent = _context.PstTbl.Find(postStatus.PstTbleParent.PstId);
        _logger.LogInformation("Log For Update Post");
        try
        {
            //WebPost.PstType = UsrStatus;
            Child.UpdatedData = DateTime.UtcNow;
            await _context.PstTbl.AddAsync(Child);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                IsSucceess = true,
                Data = true,
                Messege = " Post Updated",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                IsSucceess = false,
                Data = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> UpdatePostType(Guid id, PstTbl UsrStatus)
    {
        var WebPost = _context.PstTbl.Find(id);
        _logger.LogInformation("Log For Update Post");
        try
        {
            //WebPost.PstType = UsrStatus;
            UsrStatus.UpdatedData = DateTime.UtcNow;

            _context.Entry(WebPost).CurrentValues.SetValues(UsrStatus);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                IsSucceess = true,
                Data = true,
                Messege = " Post Updated",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                IsSucceess = false,
                Data = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }
}