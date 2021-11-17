using System;
using DrTaabodi.Data.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Services.WebsiteOptions
{
    public interface IOptions
    {
        public Task<bool> SaveChanges();
        public Task<IEnumerable<WebsiteOptionsTbl>> GetWebsiteOptionsAsync();
        public Task<WebsiteOptionsTbl> GetWebsiteOptionsById(string Id);

        public Task<ServiceResponse<WebsiteOptionsTbl>> CreateOption(WebsiteOptionsTbl WebUser);
        public Task<ServiceResponse<bool>> UpdateOption(string id, WebsiteOptionsTbl WebUser);
    }
}
