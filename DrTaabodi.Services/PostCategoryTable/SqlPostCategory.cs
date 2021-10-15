using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.PostTypeTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostCategoryTable
{
    public class SqlPostCategory:IPostCategory
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlPostCategory> _logger;

        public SqlPostCategory(DrTaabodiDbContext db, ILogger<SqlPostCategory> logger)
        {
            _context = db;
            _logger = logger;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<PostCategoryTbl> GetAllPosts()
        {
            return _context.PostCategoryTbl
                .Include(post => post.PostTable).ToList();
        }

        public PostCategoryTbl GetPostById(Guid id)
        {
            return (_context.PostCategoryTbl.Include(c => c.PostTable)
                .FirstOrDefault(c => c.PostCategoryId == id));
        }

        public ServiceResponse<PostCategoryTbl> CreatePost(PostCategoryTbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow;


                _context.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdatePostStatus(Guid id, PostCategoryTbl postStatus)
        {
            var ChildPostType = GetPostById(id);
            //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
            _logger.LogInformation("Log for Create Post Parent");
            try
            {
                postStatus.UpdatedData = DateTime.UtcNow;
                //ChildPostType.PostType = Parent;


                _context.Entry(ChildPostType).CurrentValues.SetValues(postStatus);
                SaveChanges();
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
}
