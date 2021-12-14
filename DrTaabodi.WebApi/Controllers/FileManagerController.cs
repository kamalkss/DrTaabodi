using System;
using System.Collections.Generic;
using DrTaabodi.Data.Models;
using DrTaabodi.Data.Models.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

//using Microsoft.Extensions.FileProviders;

namespace DrTaabodi.WebApi.Controllers;

[Route("api/[controller]")]
[EnableCors("AllowAllOrigins")]
public class FileManagerController : Controller
{
    public string basePath;
    public PhysicalFileProvider operation;
    private readonly string root = "wwwroot\\Files";

    public FileManagerController(IHostingEnvironment hostingEnvironment)
    {
        basePath = hostingEnvironment.ContentRootPath;
        operation = new PhysicalFileProvider();
        operation.RootFolder(basePath + "\\" + root);
    }

    [Route("FileOperations")]
    public object FileOperations([FromBody] FileManagerDirectoryContent args)
    {
        if (args.Action == "delete" || args.Action == "rename")
            if (args.TargetPath == null && args.Path == "")
            {
                var response = new FileManagerResponse();
                response.Error = new ErrorDetails {Code = "401", Message = "Restricted to modify the root folder."};
                return operation.ToCamelCase(response);
            }

        switch (args.Action)
        {
            case "read":
                // reads the file(s) or folder(s) from the given path.
                return operation.ToCamelCase(operation.GetFiles(args.Path, args.ShowHiddenItems));
            case "delete":
                // deletes the selected file(s) or folder(s) from the given path.
                return operation.ToCamelCase(operation.Delete(args.Path, args.Names));
            case "copy":
                // copies the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                return operation.ToCamelCase(operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles,
                    args.TargetData));
            case "move":
                // cuts the selected file(s) or folder(s) from a path and then pastes them into a given target path.
                return operation.ToCamelCase(operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles,
                    args.TargetData));
            case "details":
                // gets the details of the selected file(s) or folder(s).
                return operation.ToCamelCase(operation.Details(args.Path, args.Names, args.Data));
            case "create":
                // creates a new folder in a given path.
                return operation.ToCamelCase(operation.Create(args.Path, args.Name));
            case "search":
                // gets the list of file(s) or folder(s) from a given path based on the searched key string.
                return operation.ToCamelCase(operation.Search(args.Path, args.SearchString, args.ShowHiddenItems,
                    args.CaseSensitive));
            case "rename":
                // renames a file or folder.
                return operation.ToCamelCase(operation.Rename(args.Path, args.Name, args.NewName));
        }

        return null;
    }

    // uploads the file(s) into a specified path
    //[Route("Upload")]
    [Route("Upload")]
    public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
    {
        FileManagerResponse uploadResponse;
        uploadResponse = operation.Upload(path, uploadFiles, action, null);
        if (uploadResponse.Error != null)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
        }

        return Content("");
    }

    // downloads the selected file(s) and folder(s)
    [Route("Download")]
    public IActionResult Download(string downloadInput)
    {
        var args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
        return operation.Download(args.Path, args.Names, args.Data);
    }

    // gets the image(s) from the given path
    [Route("GetImage")]
    public IActionResult GetImage(FileManagerDirectoryContent args)
    {
        return operation.GetImage(args.Path, args.Id, false, null, null);
    }
}