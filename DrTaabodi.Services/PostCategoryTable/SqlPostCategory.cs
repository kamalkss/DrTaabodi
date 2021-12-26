using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostCategoryTable;

public class SqlPostCategory : IPostCategory
{
    private readonly DrTaabodiDbContext _context;
    private readonly ILogger<SqlPostCategory> _logger;

    public SqlPostCategory(DrTaabodiDbContext db, ILogger<SqlPostCategory> logger)
    {
        _context = db;
        _logger = logger;
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<List<PostCategoryTbl>> GetAllPosts()
    {
        return await _context.PostCategoryTbl
            .Include(post => post.PostTable).ToListAsync();
    }

    public async Task<PostCategoryTbl> GetPostById(Guid id)
    {
        return await _context.PostCategoryTbl.Include(c => c.PostTable)
            .FirstOrDefaultAsync(c => c.PostCategoryId == id);
    }

    public async Task<ServiceResponse<PostCategoryTbl>> CreatePost(PostCategoryTbl WebPost)
    {
        _logger.LogInformation("Log for Create Post");
        try
        {
            WebPost.UpdatedData = DateTime.UtcNow;
            WebPost.CreatedDate = DateTime.UtcNow;


            await _context.AddAsync(WebPost);
            await SaveChanges();
            return new ServiceResponse<PostCategoryTbl>
            {
                Data = WebPost,
                IsSucceess = true,
                Messege = "Post Type Created",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<PostCategoryTbl>
            {
                Data = null,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, PostCategoryTbl postStatus)
    {
        //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
        _logger.LogInformation("Log for Create Post Parent");
        try
        {
            var ChildPostType = await GetPostById(id);
            ChildPostType.UpdatedData = DateTime.UtcNow;
            //ChildPostType.PostType = Parent;
            _context.Entry(ChildPostType).CurrentValues.SetValues(postStatus);
            ChildPostType.PostTable.Clear();
            foreach (var item in postStatus.PostTable) ChildPostType.PostTable.Add(item);
            
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
}