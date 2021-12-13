using System.Collections.Generic;
using System.Linq;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemService.Formatter;

public class DefaultFileSystemFormatter : IFileSystemFormatter
{
    public object ToJson(IEnumerable<FileSystem> fileSystemObjects)
    {
        var DateTimeFormat = "MM/dd/yyyy HH:mm";
        return fileSystemObjects?.Select(obj => new
        {
            obj.Name,
            Id = obj.Id.Replace(@"\", @"\\"),
            obj.IsFile,
            obj.HasChilds,
            LastWriteTime = obj.LastWriteTime?.ToString(DateTimeFormat),
            CreationTime = obj.CreationTime?.ToString(DateTimeFormat),
            obj.Size,
            obj.Extension
        });
    }
}