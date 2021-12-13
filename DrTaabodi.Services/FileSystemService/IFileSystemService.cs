using System.Collections.Generic;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.FileSystemService.Formatter;

namespace DrTaabodi.Services.FileSystemService;

public interface IFileSystemService
{
    public IEnumerable<FileSystem> GetAllFiles(string FullName);
    public object ToJson(IEnumerable<FileSystem> files, IFileSystemFormatter fileSystemFormatter = null);
    bool DirectoryExists(string FullName);
}