using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.MetaTable;

public class SqlMeta : IMeta
{
    private readonly DrTaabodiDbContext _context;
    private readonly ILogger<SqlMeta> _logger;

    public SqlMeta(DrTaabodiDbContext db, ILogger<SqlMeta> logger)
    {
        _context = db;
        _logger = logger;
    }

    public async Task<ServiceResponse<MetaTbl>> CreatePost(MetaTbl WebPost)
    {
        _logger.LogInformation("Log for Create Post");
        try
        {
            //var user = WebPost.UserTable;

            await _context.AddAsync(WebPost);
            await SaveChanges();
            return new ServiceResponse<MetaTbl>
            {
                Data = WebPost,
                IsSucceess = true,
                Messege = "Post Created",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<MetaTbl>
            {
                Data = null,
                IsSucceess = false,
                Messege = e.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<IEnumerable<MetaTbl>> GetAllPosts()
    {
        return await _context.MetaTbl.ToListAsync();
        //.Include(c => c.PstTbls).ToListAsync();
    }

    public async Task<IEnumerable<MetaTbl>> GetMetasWithPostId(Guid id)
    {
        return await _context.MetaTbl.ToListAsync();
        //.Include(c => c.PstTbls.FirstOrDefault(e => e.PstId == id)).ToListAsync();
    }

    public async Task<MetaTbl> GetPostById(Guid id)
    {
        return await _context.MetaTbl.FirstOrDefaultAsync(c => c.MetaId == id);
        //.Include(c => c.PstTbls)
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<ServiceResponse<bool>> UpdatePostStatus(Guid id, MetaTbl postStatus)
    {
        _logger.LogInformation("Log For Update Post");
        try
        {
            //WebPost.PstType = UsrStatus;
            var WebPost = await _context.MetaTbl.FindAsync(id);

            _context.Entry(WebPost).CurrentValues.SetValues(postStatus);
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