using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrTaabodi.Services.WebsiteOptions;

public class SqlOptions : IOptions
{
    private readonly DrTaabodiDbContext _context;

    public SqlOptions(DrTaabodiDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<WebsiteOptionsTbl>> CreateOption(WebsiteOptionsTbl WebUser)
    {
        try
        {
            await _context.WebsiteOptionsTbls.AddAsync(WebUser);
            await SaveChanges();
            return new ServiceResponse<WebsiteOptionsTbl>
            {
                IsSucceess = true,
                Data = WebUser,
                Messege = "New user Added",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<WebsiteOptionsTbl>
            {
                IsSucceess = false,
                Data = null,
                Messege = e.InnerException.Message,
                Time = DateTime.UtcNow
            };
        }
    }

    public async Task<IEnumerable<WebsiteOptionsTbl>> GetWebsiteOptionsAsync()
    {
        return await _context.WebsiteOptionsTbls.ToListAsync();
    }

    public async Task<WebsiteOptionsTbl> GetWebsiteOptionsById(string Id)
    {
        return await _context.WebsiteOptionsTbls.FirstOrDefaultAsync(c => c.OptionKey == Id);
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<ServiceResponse<bool>> UpdateOption(string id, WebsiteOptionsTbl WebUser)
    {
        try
        {
            var UpdatedPost = _context.WebsiteOptionsTbls.Find(id);
            _context.Entry(UpdatedPost).CurrentValues.SetValues(WebUser);
            await SaveChanges();
            return new ServiceResponse<bool>
            {
                IsSucceess = true,
                Data = true,
                Messege = "New user Added",
                Time = DateTime.UtcNow
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                IsSucceess = false,
                Data = false,
                Messege = e.InnerException.Message,
                Time = DateTime.UtcNow
            };
        }
    }
}