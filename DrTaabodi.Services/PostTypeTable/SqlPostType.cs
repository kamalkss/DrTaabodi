using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostTypeTable;

public class SqlPostType : IPostType
{
    private readonly DrTaabodiDbContext _context;
    private readonly ILogger<SqlPostType> _logger;

    public SqlPostType(DrTaabodiDbContext db, ILogger<SqlPostType> logger)
    {
        _context = db;
        _logger = logger;
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<List<PostTypeTbl>> GetAllPosts()
    {
        return await _context.PostTypeTbl.Include(c => c.PostTable).ToListAsync();
    }

    public async Task<PostTypeTbl> GetPostById(Guid id)
    {
        return await _context.PostTypeTbl.Include(c => c.PostTable)
            .FirstOrDefaultAsync(c => c.PostTypeId == id);
    }

    public async Task<ServiceResponse<PostTypeTbl>> CreatePostType(PostTypeTbl WebPost)
    {
        _logger.LogInformation("Log for Create Post");
        try
        {
            WebPost.UpdatedData = DateTime.UtcNow;
            WebPost.CreatedDate = DateTime.UtcNow;


            await _context.AddAsync(WebPost);
            await SaveChanges();
            return new ServiceResponse<PostTypeTbl>
            {
                Data = WebPost,
                IsSucceess = true,
                Messege = "Post Type Created",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<PostTypeTbl>
            {
                Data = null,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> UpdatePostType(Guid id, PostTypeTbl WebPost)
    {
        var ChildPostType = _context.PostTypeTbl.Find(id);
        //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
        _logger.LogInformation("Log for Create Post Parent");
        try
        {
            WebPost.UpdatedData = DateTime.UtcNow;
            //ChildPostType.PostType = Parent;


            _context.Entry(ChildPostType).CurrentValues.SetValues(WebPost);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                IsSucceess = true,
                Messege = "PosyType Updated Added",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                Data = false,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> EditParent(Guid id, Guid ParentId)
    {
        var ChildPostType = _context.PostTypeTbl.Find(id);
        //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
        _logger.LogInformation("Log for Create Post Parent");
        try
        {
            ChildPostType.UpdatedData = DateTime.UtcNow;
            //ChildPostType.PostType = Parent;
            // ChildPostType.PostTypeParentId = ParentId;

            await _context.AddAsync(ChildPostType);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                Data = true,
                IsSucceess = true,
                Messege = "Parent Added",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                Data = false,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> AddPosts(Guid id, PstTbl WebPost)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<bool>> RemovePosts(Guid id, PstTbl WebPost)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<bool>> RemoveParent(Guid id, PostTypeTbl WebPost)
    {
        throw new NotImplementedException();
    }
}