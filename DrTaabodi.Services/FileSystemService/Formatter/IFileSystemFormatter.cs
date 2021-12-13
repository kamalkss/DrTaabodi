using System.Collections.Generic;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemService.Formatter;

public interface IFileSystemFormatter
{
    object ToJson(
        IEnumerable<FileSystem> fileSystemObjects);
}