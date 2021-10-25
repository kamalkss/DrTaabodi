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
        public bool SaveChanges();
        public List<WebsiteOptionsTbl> GetWebsiteOptionsAsync();
        public WebsiteOptionsTbl GetWebsiteOptionsById(Guid Id);

        public ServiceResponse<WebsiteOptionsTbl> CreateOption(WebsiteOptionsTbl WebUser);
        public ServiceResponse<bool> UpdateOption(Guid id, WebsiteOptionsTbl WebUser);
    }
}
