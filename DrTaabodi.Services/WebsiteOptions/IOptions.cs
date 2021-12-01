using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.WebsiteOptions;

public interface IOptions
{
    public Task<bool> SaveChanges();
    public Task<IEnumerable<WebsiteOptionsTbl>> GetWebsiteOptionsAsync();
    public Task<WebsiteOptionsTbl> GetWebsiteOptionsById(string Id);

    public Task<ServiceResponse<WebsiteOptionsTbl>> CreateOption(WebsiteOptionsTbl WebUser);
    public Task<ServiceResponse<bool>> UpdateOption(string id, WebsiteOptionsTbl WebUser);
}