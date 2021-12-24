using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemTableServices;

public interface IFileSystemService
{
    public Task<bool> SaveChanges();
    public Task<IList<FileSystemTbl>> GetallFilesAdnFolders();
    public Task<IList<FileSystemTbl>> GetallFile();
    public Task<IList<FileSystemTbl>> GetallFolders();
    public Task<FileSystemTbl> GetById(Guid id);

    public Task<string> GetPath(Guid id);

    public Task<ServiceResponse<FileSystemTbl>> Create(FileSystemTbl WebPost);

    //public ServiceResponse<bool> UpdatePostType(Guid id, PstType PostType);
    public Task<ServiceResponse<bool>> Update(Guid id, FileSystemTbl postStatus);
    public Task<ServiceResponse<bool>> Delete(Guid id);
}