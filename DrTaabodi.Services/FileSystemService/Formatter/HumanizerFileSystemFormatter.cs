using System.Collections.Generic;
using System.Linq;
using DrTaabodi.Data.Models;
using Humanizer;

namespace DrTaabodi.Services.FileSystemService.Formatter;

public sealed class HumanizerFileSystemFormatter : IFileSystemFormatter
{
    public object ToJson(IEnumerable<FileSystem> fileSystemObjects)
    {
        return fileSystemObjects?.Select(obj => new
        {
            obj.Name,
            Id = obj.Id.Replace(@"\", @"\\"),
            obj.IsFile,
            obj.HasChilds,
            LastWriteTime = obj.LastWriteTime.Humanize(),
            CreationTime = obj.CreationTime.Humanize(),
            Size = obj.Size.HasValue ? obj.Size.Value.Bytes().Humanize() : null,
            obj.Extension
        });
    }
}