using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrTaabodi.Services.WebsiteOptions
{
    public class SqlOptions : IOptions
    {
        private readonly DrTaabodiDbContext _context;

        public SqlOptions(DrTaabodiDbContext context)
        {
            _context = context;
        }
        public ServiceResponse<WebsiteOptionsTbl> CreateOption(WebsiteOptionsTbl WebUser)
        {
            throw new NotImplementedException();
        }

        public List<WebsiteOptionsTbl> GetWebsiteOptionsAsync()
        {
            throw new NotImplementedException();
        }

        public WebsiteOptionsTbl GetWebsiteOptionsById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public ServiceResponse<bool> UpdateOption(Guid id, WebsiteOptionsTbl WebUser)
        {
            throw new NotImplementedException();
        }
    }
}
