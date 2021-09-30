using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.PostTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.PostTypeTable
{
    public class SqlPostType : IPostType
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlPostType> _logger;

        public SqlPostType(DrTaabodiDbContext db, ILogger<SqlPostType> logger)
        {
            _context = db;
            _logger = logger;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<PostTypeTbl> GetAllPosts()
        {
            return (_context.PostTypeTbl.Include(c => c.PostTable).ToList());
        }

        public PostTypeTbl GetPostById(Guid id)
        {
            return (_context.PostTypeTbl.Include(c => c.PostTable)
                .FirstOrDefault(c => c.PostTypeId == id));
        }

        public ServiceResponse<PostTypeTbl> CreatePostType(PostTypeTbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow;


                _context.Add(WebPost);
                SaveChanges();
                return new ServiceResponse<PostTypeTbl>
                {
                    Data = WebPost,
                    IsSucceess = true,
                    Messege = "Post Type Created",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<PostTypeTbl>
                {
                    Data = null,
                    IsSucceess = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public ServiceResponse<bool> UpdatePostType(Guid id, PostTypeTbl WebPost)
        {
            var ChildPostType = _context.PostTypeTbl.Find(id);
            //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
            _logger.LogInformation("Log for Create Post Parent");
            try
            {
                ChildPostType.UpdatedData = DateTime.UtcNow;
                //ChildPostType.PostType = Parent;
                

                _context.Update(ChildPostType);
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

        public ServiceResponse<bool> EditParent(Guid id, Guid ParentId)
        {
            var ChildPostType = _context.PostTypeTbl.Find(id);
            //var Parent = _context.PostTypeTbl.Find(WebPost.PostTypeId);
            _logger.LogInformation("Log for Create Post Parent");
            try
            {
                ChildPostType.UpdatedData = DateTime.UtcNow;
                //ChildPostType.PostType = Parent;
               // ChildPostType.PostTypeParentId = ParentId;

                _context.Add(ChildPostType);
                SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    IsSucceess = true,
                    Messege = "Parent Added",
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

        public ServiceResponse<bool> RemoveParent(Guid id, PostTypeTbl WebPost)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> AddPosts(Guid id, PstTbl WebPost)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> RemovePosts(Guid id, PstTbl WebPost)
        {
            throw new NotImplementedException();
        }


    }
}
