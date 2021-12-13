using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrTaabodi.Data.Models.Base;

public interface FileProviderBase
{
    public FileManagerResponse GetFiles(string path, bool showHiddenItems, params FileManagerDirectoryContent[] data);
    public FileManagerResponse Create(string path, string name, params FileManagerDirectoryContent[] data);
    public FileManagerResponse Details(string path, string[] names, params FileManagerDirectoryContent[] data);

    public FileManagerResponse Delete(string path, string[] names, params FileManagerDirectoryContent[] data);

    public FileManagerResponse Rename(string path, string name, string newName, bool replace = false,
        params FileManagerDirectoryContent[] data);

    public FileManagerResponse Copy(string path, string targetPath, string[] names, string[] renameFiles,
        FileManagerDirectoryContent targetData, params FileManagerDirectoryContent[] data);

    public FileManagerResponse Move(string path, string targetPath, string[] names, string[] renameFiles,
        FileManagerDirectoryContent targetData, params FileManagerDirectoryContent[] data);

    public FileManagerResponse Search(string path, string searchString, bool showHiddenItems, bool caseSensitive,
        params FileManagerDirectoryContent[] data);

    public FileStreamResult Download(string path, string[] names, params FileManagerDirectoryContent[] data);

    public FileManagerResponse Upload(string path, IList<IFormFile> uploadFiles, string action,
        params FileManagerDirectoryContent[] data);


    public FileStreamResult GetImage(string path, string id, bool allowCompress, ImageSize size,
        params FileManagerDirectoryContent[] data);
}