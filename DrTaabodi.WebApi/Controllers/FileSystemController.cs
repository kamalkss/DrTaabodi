using System.Threading.Tasks;
using DrTaabodi.Services.FileSystemService;
using DrTaabodi.Services.FileSystemService.Formatter;
using Microsoft.AspNetCore.Mvc;

namespace DrTaabodi.WebApi.Controllers;

public class FileSystemController : Controller
{
    private readonly IFileSystemService _fileSystemService;

    public FileSystemController(
        IFileSystemService fileSystemService)
    {
        _fileSystemService = fileSystemService;
    }

    public async Task<IActionResult> Index(string fullName = null, string formatterName = null)
    {
        var data = _fileSystemService.GetAllFiles(fullName);

        var json = _fileSystemService.ToJson(data, FormatterFactory.CreateInstance(formatterName));

        return Json(json);
    }

    [ActionName("check-directory")]
    public async Task<IActionResult> DirectoryExists(string fullName = null)
    {
        var exists = _fileSystemService.DirectoryExists(fullName);

        return Json(exists);
    }
}