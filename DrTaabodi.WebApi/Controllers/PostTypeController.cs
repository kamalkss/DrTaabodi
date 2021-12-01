using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.PostTable;
using DrTaabodi.Services.PostTypeTable;
using DrTaabodi.WebApi.DTO.PostType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers;

[ApiController]
[Route("/api/posttype")]
public class PostTypeController : ControllerBase
{
    private readonly ILogger<PostTypeController> _logger;
    private readonly IMapper _mapper;
    private readonly IPost _postService;
    private readonly IPostType _postTypeService;

    public PostTypeController(IPost Post, IPostType PostType, ILogger<PostTypeController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _postService = Post;
        _postTypeService = PostType;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPostType>>> GetAllPostTypes()
    {
        var PostTypes = _postTypeService.GetAllPosts();
        return Ok(PostTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ReadPostType>>> GetPostType(Guid id)
    {
        var PostType = _postTypeService.GetPostById(id);
        return Ok(PostType);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<CreatePostType>>> CreatePost([FromBody] CreatePostType PostType)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var MapPost = _mapper.Map<PostTypeTbl>(PostType);
        if (PostType.ParentId != Guid.Empty &&
            PostType.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = PostType.ParentId;
        if (PostType.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        //if(PostType.PostId!=Guid.Empty)
        //    MapPost.PostTable.Add(await _postService.GetPostById(PostType.PostId));
        var NewPost = _postTypeService.CreatePostType(MapPost);
        return Ok(NewPost);
    }

    [HttpPatch]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdatePostType([FromBody] ReadPostType postType)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var Post = _postTypeService.GetPostById(postType.PostTypeId);
        var MapPost = _mapper.Map<PostTypeTbl>(postType);
        if (postType.ParentId != Guid.Empty &&
            postType.ParentId != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = postType.ParentId;
        if (postType.PostId != Guid.Empty)
            MapPost.PostTable.Add(await _postService.GetPostById(postType.PostId));
        if (postType.ParentId == Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            MapPost.ParentId = null;
        var UpdatedPost = _postTypeService.UpdatePostType(MapPost.PostTypeId, MapPost);
        return Ok(UpdatedPost);
    }
}