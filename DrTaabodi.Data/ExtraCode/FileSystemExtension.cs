using System.Collections.Generic;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Data.ExtraCode;

public static class FileSystemExtension
{
    public static void AddIfNotNull(this List<FileSystem> objs, FileSystem obj)
    {
        if (objs == null || obj == null) return;
        objs.Add(obj);
    }
}