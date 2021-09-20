using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.UserTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostTable
{
    public class SqlPost:IPost
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlPost> _logger;
        private readonly UsrTbl _usrTbl;

        public SqlPost(DrTaabodiDbContext _db, ILogger<SqlPost> logger,UsrTbl usrTbl)
        {
            _context = _db;
            _logger = logger;
            _usrTbl = usrTbl;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<PstTbl> GetAllPosts()
        {
            return _context.PstTbl
                .Include(c => c.User).ToList();
        }

        public PstTbl GetPostById(Guid id)
        {
            return _context.PstTbl.Include(c => c.User).
                FirstOrDefault(p => p.PstId == id);
        }

        public ServiceResponse<PstTbl> CreatePost(PstTbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow;;
                _context.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdatePostType(Guid id, PstType UsrStatus)
        {
            var WebPost = _context.PstTbl.Find(id);
            _logger.LogInformation("Log For Update Post");
            try
            {
                WebPost.PstType = UsrStatus;
                WebPost.UpdatedData = DateTime.UtcNow;
                _context.PstTbl.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdatePostStatus(Guid id, PstStatus UsrStatus)
        {
            var WebPost = _context.PstTbl.Find(id);
            _logger.LogInformation("Log For Update Post");
            try
            {
                WebPost.PstStatus = UsrStatus;
                WebPost.UpdatedData = DateTime.UtcNow;
                _context.PstTbl.Add(WebPost);
                SaveChanges();
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
}
