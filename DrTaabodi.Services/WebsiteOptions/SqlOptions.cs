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
            try
            {
                
                _context.WebsiteOptionsTbls.Add(WebUser);
                SaveChanges();
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
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public List<WebsiteOptionsTbl> GetWebsiteOptionsAsync()
        {
            return _context.WebsiteOptionsTbls.ToList();
        }

        public WebsiteOptionsTbl GetWebsiteOptionsById(Guid Id)
        {
            return _context.WebsiteOptionsTbls.FirstOrDefault(c => c.OptionId == Id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public ServiceResponse<bool> UpdateOption(Guid id, WebsiteOptionsTbl WebUser)
        {
            try
            {
                var UpdatedPost = _context.WebsiteOptionsTbls.Find(id);
                _context.Entry(UpdatedPost).CurrentValues.SetValues(WebUser);
                SaveChanges();
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
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
