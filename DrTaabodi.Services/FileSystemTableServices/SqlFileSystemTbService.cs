using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.PostCategoryTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.Services.FileSystemTableServices
{
    public class SqlFileSystemTbService:IFileSystemService
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlFileSystemTbService> _logger;

        public SqlFileSystemTbService(DrTaabodiDbContext db, ILogger<SqlFileSystemTbService> logger)
        {
            _context = db;
            _logger = logger;
        }
        public async   Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async   Task<IList<FileSystemTbl>> GetallFilesAdnFolders()
        {
            return await _context.FileSystem.ToListAsync();
        }

        public async  Task<IList<FileSystemTbl>> GetallFile()
        {
            return await _context.FileSystem.Where(c => c.IsFile == true).ToListAsync();
        }

        public async  Task<IList<FileSystemTbl>> GetallFolders()
        {
            return await _context.FileSystem.Where(c => c.IsFile == false).ToListAsync();
        }

        public async  Task<FileSystemTbl> GetById(Guid id)
        {
            return await _context.FileSystem.FirstOrDefaultAsync(c => c.FileSystemId == id);
        }

        public async Task<string> GetPath(Guid id)
        {
            var item = await _context.FileSystem.FirstOrDefaultAsync(c => c.FileSystemId == id);
            try
            {
                return item.FileFolderPath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public async  Task<ServiceResponse<FileSystemTbl>> Create(FileSystemTbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.CreationTime = DateTime.UtcNow;
                WebPost.LastWriteTime = DateTime.UtcNow;


                await _context.AddAsync(WebPost);
                await SaveChanges();
                return new ServiceResponse<FileSystemTbl>
                {
                    Data = WebPost,
                    IsSucceess = true,
                    Messege = "Post Type Created",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<FileSystemTbl>
                {
                    Data = null,
                    IsSucceess = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public async  Task<ServiceResponse<bool>> Update(Guid id, FileSystemTbl postStatus)
        {
            _logger.LogInformation("Log for update Post Parent");
            try
            {
                var ChildPostType = GetById(id);
                postStatus.LastWriteTime = DateTime.UtcNow;
                //ChildPostType.PostType = Parent;


                _context.Entry(ChildPostType.Result).CurrentValues.SetValues(postStatus);
                await SaveChanges();
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

        public async  Task<ServiceResponse<bool>> Delete(Guid id)
        {
            _logger.LogInformation("Log for delete Post Parent");
            try
            {

                var ChildPostType = GetById(id);
               
                //ChildPostType.PostType = Parent;

                _context.Remove(ChildPostType);
                
                await SaveChanges();
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
