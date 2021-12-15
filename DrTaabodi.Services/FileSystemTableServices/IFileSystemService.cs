using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemTableServices
{
    public interface IFileSystemService
    {
        public Task<bool> SaveChanges();
        public Task<List<FileSystemTbl>> GetallFilesAdnFolders();
        public Task<List<FileSystemTbl>> GetallFile();
        public Task<List<FileSystemTbl>> GetallFolders();
        public Task<FileSystemTbl> GetById(Guid id);

        public Task<ServiceResponse<FileSystemTbl>> Create(FileSystemTbl WebPost);

        //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
        public Task<ServiceResponse<bool>> Update(Guid id, FileSystemTbl postStatus);
        public Task<ServiceResponse<bool>> Delete(Guid id);
    }


}
