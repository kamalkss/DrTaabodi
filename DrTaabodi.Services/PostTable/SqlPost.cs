﻿using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrTaabodi.Services.PostTable
{
    public class SqlPost : IPost
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlPost> _logger;
        //private readonly PstTbl _pstTbl;

        public SqlPost(DrTaabodiDbContext _db, ILogger<SqlPost> logger)
        {
            _context = _db;
            _logger = logger;
            // _pstTbl = pstTbl;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<PstTbl> GetAllPosts()
        {
            return _context.PstTbl
                .Include(c => c.UserTable)
                .Include(c=>c.PstTbleParent)
                .Include(c=>c.PostTypeTable)
                .Include(c=>c.PostCategoryTable).ToList();
        }

        public PstTbl GetPostById(Guid id)
        {
            return _context.PstTbl.Include(c => c.UserTable)
                .Include(c => c.PstTbleParent)
                .Include(c => c.PostTypeTable)
                .Include(c => c.PostCategoryTable).
                FirstOrDefault(p => p.PstId == id);
        }

        public ServiceResponse<PstTbl> CreatePost(PstTbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow;
                //var user = WebPost.UserTable;

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
                //WebPost.PstType = UsrStatus;
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

        public ServiceResponse<bool> UpdatePostStatus(Guid id, PstTbl UsrStatus)
        {
            var WebPost = _context.PstTbl.Find(id);
            _logger.LogInformation("Log For Update Post");
            try
            {
                //WebPost.PstStatus = UsrStatus;
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

        

        public ServiceResponse<bool> AddPostParent(Guid id, PstTbl postStatus)
        {
            var  Child = _context.PstTbl.Find(id);
            var Parent = _context.PstTbl.Find(postStatus.PstTbleParent.PstId);
            _logger.LogInformation("Log For Update Post");
            try
            {
                //WebPost.PstType = UsrStatus;
                Child.UpdatedData = DateTime.UtcNow;
                _context.PstTbl.Add(Child);
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
