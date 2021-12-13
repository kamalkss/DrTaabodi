using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemService;

public interface IFileSystemRepository :
    ISelectRepository<FileSystem>,
    IDeleteRepository<FileSystem>
{
    bool Exists(
        string fullName);
}