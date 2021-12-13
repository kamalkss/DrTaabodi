using System.Collections.Generic;
using System.Linq;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.FileSystemService.Formatter;

namespace DrTaabodi.Services.FileSystemService;

public class DefaultFileSystemService : IFileSystemService
{
    private readonly IFileSystemRepository _fileSystemRepository;

    public DefaultFileSystemService(IFileSystemRepository fileSystemRepository)
    {
        _fileSystemRepository = fileSystemRepository;
    }

    public IEnumerable<FileSystem> GetAllFiles(string FullName)
    {
        var objs = _fileSystemRepository.SelectMany(FullName).ToList();

        if (objs.Any()) objs.OrderBy(obj => obj.IsFile.ToString());

        return objs;
    }

    public object ToJson(IEnumerable<FileSystem> files, IFileSystemFormatter fileSystemFormatter = null)
    {
        fileSystemFormatter = fileSystemFormatter ?? FormatterFactory.CreateInstance();

        return fileSystemFormatter.ToJson(files);
    }

    public bool DirectoryExists(string FullName)
    {
        var result = _fileSystemRepository.Exists(FullName);

        return result;
    }
}