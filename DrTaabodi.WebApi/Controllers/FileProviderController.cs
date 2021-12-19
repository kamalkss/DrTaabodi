using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.FileSystemTableServices;
using DrTaabodi.WebApi.DTO.FileSystemDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Composite;
using Microsoft.Net.Http.Headers;
using PhysicalFileProvider = Microsoft.Extensions.FileProviders.PhysicalFileProvider;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController]
    [Route("/api/FileProvider")]
    public class FileProviderController : Controller
    {
        private readonly IFileProvider _fileProvider;
        public PhysicalFileProvider _operation;
        private readonly IMapper _mapper;
        private readonly IFileSystemService _fileSystemService;
        private IHostingEnvironment _environment;
        public string _basePath;
        string root = "wwwroot\\Files";
        public FileProviderController(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment, IFileSystemService fileSystemService, IMapper mapper)
        {
            _fileProvider = fileProvider;
            this._basePath = hostingEnvironment.ContentRootPath;
            //this._operation = new PhysicalFileProvider(this._basePath + "\\" + this.root);
            _environment = hostingEnvironment;
            _environment.WebRootPath = root;
            _environment.ContentRootPath = root;
            this._mapper = mapper;
            this._fileSystemService = fileSystemService;
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

        [HttpGet("ScanAll")]
        public async Task<IActionResult> ScanAll()
        {

            var content = _fileProvider.GetDirectoryContents(root);
            var operation = _operation;
        A:
            foreach (var directoryContent in content)
            {
                if (directoryContent.IsDirectory == true)
                {
                    var newcontent = _fileProvider.GetDirectoryContents(root + directoryContent.Name);
                    foreach (var directoryContent1 in newcontent)
                    {
                        if (directoryContent1.PhysicalPath != directoryContent.PhysicalPath)
                        {
                            content.Intersect(newcontent);
                        }
                    }


                }

            }

            return Ok(content);
        }
        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile(string Url,string Filename)
        {
            
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.DownloadFile(new Uri(Url), Filename);
            }

            return NotFound();
        }

        [HttpGet("downloadbyName")]
        public async Task<IActionResult> DownloadByname(string name)
        {
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IList<IFormFile> files)
        {

            CreateFileSystem createFile = new CreateFileSystem();
            string uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string filePath = Path.Combine(uploads, formFile.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {

                        await formFile.CopyToAsync(fileStream);

                    }


                    createFile.Name = formFile.FileName;
                    createFile.IsFile = true;
                    createFile.Size = formFile.Length;
                    createFile.FileFolderPath = filePath;
                    createFile.Extension = "";
                    createFile.Caption = formFile.FileName;
                    createFile.Description = "";
                    createFile.HasChilds = false;
                    createFile.ParentId = Guid.Empty;
                    createFile.Version = "";
                    createFile.Compilation = "";
                    var MapPost = _mapper.Map<FileSystemTbl>(createFile);
                    //if (postCategory.PostId != Guid.Empty)
                    //    MapPost.PostTable.Add(await _postService.GetPostById(postCategory.PostId));
                    var NewPost = _fileSystemService.Create(MapPost);
                    return Ok(NewPost);
                }

            }
            return NotFound();
        }



        [HttpPost("UploadSingle")]
        public async Task<IActionResult> UploadSingle(IFormFile formFile, UploadFile upload)
        {
            if (formFile.Length > 0 && formFile != null)
            {
                CreateFileSystem createFile = new CreateFileSystem();
                string uploads = Path.Combine(_environment.WebRootPath, "uploads");

                string filePath = Path.Combine(uploads, formFile.FileName);
               
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await formFile.CopyToAsync(fileStream);

                }


                createFile.Name = formFile.FileName;
                createFile.IsFile = true;
                createFile.Size = formFile.Length;
                createFile.FileFolderPath = filePath;
                createFile.Extension = "";
                createFile.Caption = upload.Caption;
                createFile.Description = upload.Description;
                createFile.HasChilds = false;
                createFile.ParentId = Guid.Empty;
                createFile.Version = "";
                createFile.Compilation = "";
                var MapPost = _mapper.Map<FileSystemTbl>(createFile);
                //if (postCategory.PostId != Guid.Empty)
                //    MapPost.PostTable.Add(await _postService.GetPostById(postCategory.PostId));
                var NewPost = _fileSystemService.Create(MapPost);
                return Ok(NewPost);
            }


            return NotFound();
        }


        [HttpPost("upload2")]
        public async Task<IActionResult> Create(CreateFileSystem model)
        {
            //// do other validations on your model as needed
            //if (model.MyFile != null)
            //{
            //    //var uniqueFileName = GetUniqueFileName(model.MyFile.FileName);
            //    //var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            //    //var filePath = Path.Combine(uploads, uniqueFileName);
            //    //model.MyFile.CopyToAsync(new FileStream(filePath, FileMode.Create));

            //    //to do : Save uniqueFileName  to your db table   
            //}
            //// to do  : Return something
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
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
}
