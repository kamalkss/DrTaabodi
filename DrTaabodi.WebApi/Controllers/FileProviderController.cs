using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController]
    [Route("/api/FileProvider")]
    public class FileProviderController : Controller
    {
        private readonly IFileProvider _fileProvider;
        public PhysicalFileProvider _operation;
        private IHostingEnvironment _environment;
        public string _basePath;
        string root = "wwwroot\\Files";

        public FileProviderController(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment)
        {
            _fileProvider = fileProvider;
            this._basePath = hostingEnvironment.ContentRootPath;
            this._operation = new PhysicalFileProvider(this._basePath + "\\" + this.root);
            _environment = hostingEnvironment;
        }

        [HttpGet("directories")]
        public async Task<IActionResult> GetDirectoies()
        {
            var content = _fileProvider.GetDirectoryContents(root);
            IList<string> filesList = new List<string>();
            foreach (var directoryContent in content)
            {
                var UrlContent = Path.Combine($"{this._environment.WebRootPath}\\{directoryContent.Name}");
                filesList.Add(UrlContent);
            }
            return Ok(content);
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(string Url)
        {
            return Ok();
        }

        [HttpGet("downloadbyName")]
        public async Task<IActionResult> DownloadByname(string name)
        {
            return Ok();
        }
        private string GetMimeType(string fileName)
        {
            // Make Sure Microsoft.AspNetCore.StaticFiles Nuget Package is installed
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        [HttpPost("uploader")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string dir = Path.Combine(_environment.WebRootPath, "files/" + DateTime.Now.ToString("yyyy/MM/dd"));
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                string targetPath = Path.Combine(dir, Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                using (var stream = System.IO.File.Create(targetPath))
                {
                    file.CopyTo(stream);
                }
                
                return Ok(targetPath.Replace(_environment.WebRootPath,"").Replace('\\','/'));
            }
            return BadRequest();
        }
    }
}
