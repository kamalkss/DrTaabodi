using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.PostCategoryTable;
using DrTaabodi.Services.PostTable;
using DrTaabodi.WebApi.DTO.PostCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers;

[ApiController]
[Route("/api/postcategory")]
public class PostCategoryController : ControllerBase
{
    private readonly ILogger<PostCategoryController> _logger;
    private readonly IMapper _mapper;
    private readonly IPostCategory _postCategoryService;
    private readonly IPost _postService;

    public PostCategoryController(IPost Post, IPostCategory PostType, ILogger<PostCategoryController> logger,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _postService = Post;
        _postCategoryService = PostType;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPostCategory>>> GetAllPosts()
    {
        _logger.LogInformation("read all Posts");
        var Post = await _postCategoryService.GetAllPosts();
        return Ok(Post);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ReadPostCategory>>> GetSinglePostCategory(Guid id)
    {
        _logger.LogInformation("read single Posts");
        var Post = await _postCategoryService.GetPostById(id);
        return Ok(Post);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<CreatePostCategory>>> CreatePostCategory(
        [FromBody] CreatePostCategory postCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var MapPost = _mapper.Map<PostCategoryTbl>(postCategory);
        if (postCategory.ParentId != Guid.Empty &&
            postCategory.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = postCategory.ParentId;

        if (postCategory.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        if (postCategory.PostId != null)
        {
            foreach (var guid in postCategory.PostId)
            {
                if (guid != null && guid != Guid.Empty &&
                    guid != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                    MapPost.PostTable.Add(await _postService.GetPostById(guid));

            }
        }
        var NewPost = _postCategoryService.CreatePost(MapPost);
        return Ok(NewPost);
    }

    //public Task<ActionResult<ServiceResponse<bool>>> UpdatePostCategory([FromBody] ReadPostCategory postCategory)
    //{useless nothing
    //    return UpdatePostCategory(postCategory, _postCategoryService);
    //}

    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdatePostCategory([FromBody] ReadPostCategory postCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var MapPost = _mapper.Map<PostCategoryTbl>(postCategory);
        if (postCategory.ParentId != Guid.Empty &&
            postCategory.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = postCategory.ParentId;
        if(postCategory.PostId != null)
        {
            foreach (var guid in postCategory.PostId)
            {
                if (guid != null && guid != Guid.Empty &&
                    guid != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                    MapPost.PostTable.Add(await _postService.GetPostById(guid));

            }
        }
        if (postCategory.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        var NewPost = _postCategoryService.UpdatePostStatus(MapPost.PostCategoryId, MapPost);
        return Ok(NewPost);
    }
}