using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.FileSystemTableServices;
using DrTaabodi.WebApi.DTO.FileSystemDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using Microsoft.Extensions.FileProviders;

namespace DrTaabodi.WebApi.Controllers;

[Route("api/[controller]")]
[Controller]
public class FileManagerController : Controller
{
    private readonly IFileSystemService _fileSystemService;
    private readonly ILogger<FileManagerController> _logger;
    private readonly IMapper _mapper;

    public FileManagerController(IFileSystemService FileSystem, ILogger<FileManagerController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _fileSystemService = FileSystem;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadFileSystem>>> GetAllFilesandFolders()
    {
        _logger.LogInformation("read all Posts");
        var Post = await _fileSystemService.GetallFilesAdnFolders();
        return Ok(Post);
    }

    [HttpGet("files")]
    public async Task<ActionResult<IEnumerable<ReadFileSystem>>> GetAllFiles()
    {
        _logger.LogInformation("read all Posts");
        var Post = await _fileSystemService.GetallFile();
        return Ok(Post);
    }

    [HttpGet("folders")]
    public async Task<ActionResult<IEnumerable<ReadFileSystem>>> GetAllFolders()
    {
        _logger.LogInformation("read all Posts");
        var Post = await _fileSystemService.GetallFolders();
        return Ok(Post);
    }

    [HttpGet("path/{id}")]
    public async Task<ActionResult<IEnumerable<ReadFileSystem>>> GetPath(Guid Id)
    {
        _logger.LogInformation("read all Posts");
        var Post = await _fileSystemService.GetPath(Id);
        return Ok(Post);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ReadFileSystem>>> GetSingleFile(Guid id)
    {
        _logger.LogInformation("read single Posts");
        var Post = await _fileSystemService.GetById(id);
        return Ok(Post);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<CreateFileSystem>>> CreatePostCategory(
        [FromBody] CreateFileSystem postCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var MapPost = _mapper.Map<FileSystemTbl>(postCategory);
        if (postCategory.ParentId != Guid.Empty &&
            postCategory.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = postCategory.ParentId;

        if (postCategory.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        //if (postCategory.PostId != Guid.Empty)
        //    MapPost.PostTable.Add(await _postService.GetPostById(postCategory.PostId));
        var NewPost = _fileSystemService.Create(MapPost);
        return Ok(NewPost);
    }

    //public Task<ActionResult<ServiceResponse<bool>>> UpdatePostCategory([FromBody] ReadPostCategory postCategory)
    //{useless nothing
    //    return UpdatePostCategory(postCategory, _postCategoryService);
    //}

    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdatePostCategory([FromBody] ReadFileSystem postCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var MapPost = _mapper.Map<FileSystemTbl>(postCategory);
        if (postCategory.ParentId != Guid.Empty &&
            postCategory.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = postCategory.ParentId;

        if (postCategory.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        var NewPost = _fileSystemService.Update(MapPost.FileSystemId, MapPost);
        return Ok(NewPost);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteSomeFile(Guid Id)
    {
        return await _fileSystemService.Delete(Id);
    }
}