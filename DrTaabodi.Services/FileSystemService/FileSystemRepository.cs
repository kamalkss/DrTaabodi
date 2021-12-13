using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.FileSystemService;

public class FileSystemRepository : IFileSystemRepository
{
    public IEnumerable<FileSystem> SelectMany(
        string id)
    {
        id = id ?? Environment.CurrentDirectory;

        var objs = new List<FileSystem>();

        if (Directory.Exists(id))
        {
            foreach (var directoryInfo in new DirectoryInfo(id).GetDirectories().AsParallel())
            {
                var obj = SelectOneDirectoryInfo(
                    directoryInfo);

                objs.AddIfNotNull(obj);
            }

            foreach (var fileInfo in new DirectoryInfo(id).GetFiles().AsParallel())
            {
                var obj = SelectOneFileInfo(
                    fileInfo);

                objs.AddIfNotNull(obj);
            }
        }

        return objs;
    }

    public FileSystem SelectOne(
        string id)
    {
        var obj = SelectOneFileInfo(
            new FileInfo(id));

        if (obj == null)
            obj = SelectOneDirectoryInfo(
                new DirectoryInfo(id));

        return obj;
    }

    public bool Delete(
        string id)
    {
        var obj = SelectOneFileInfo(
            new FileInfo(id));

        if (obj == null)
        {
            obj = SelectOneDirectoryInfo(
                new DirectoryInfo(id));

            if (obj != null) Directory.Delete(id);
        }
        else
        {
            File.Delete(id);

            return true;
        }

        return false;
    }

    public bool Exists(
        string fullName)
    {
        if (!Directory.Exists(fullName))
            return false;

        return true;
    }

    private FileSystem SelectOneDirectoryInfo(
        DirectoryInfo info)
    {
        if (info == null)
            return null;

        var obj = SelectOneFileSystemInfo(
            info);

        obj.IsFile = false;

        try
        {
            obj.HasChilds = Directory.GetDirectories(info.FullName).Length + Directory.GetFiles(info.FullName).Length >
                            0;
        }
        catch
        {
        }

        return obj;
    }

    private FileSystem SelectOneFileSystemInfo(
        FileSystemInfo info)
    {
        if (info == null)
            return null;

        var obj = new FileSystem
        {
            Name = Path.GetFileName(info.FullName),
            Id = info.FullName,
            HasChilds = false,
            IsFile = true,
            CreationTime = info.CreationTime,
            LastWriteTime = info.LastWriteTime,
            Extension = Path.GetExtension(info.FullName) ?? ""
        };

        return obj;
    }

    private FileSystem SelectOneFileInfo(
        FileInfo info)
    {
        if (info == null)
            return null;

        var obj = SelectOneFileSystemInfo(
            info);

        obj.Size = info.Length;

        return obj;
    }
}