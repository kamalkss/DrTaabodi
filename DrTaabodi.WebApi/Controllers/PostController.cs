using System;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.PostCategoryTable;
using DrTaabodi.Services.PostTable;
using DrTaabodi.Services.PostTypeTable;
using DrTaabodi.Services.UserTable;
using DrTaabodi.WebApi.DTO.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers;

[Route("/api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostCategory _CategoryService;
    private readonly DrTaabodiDbContext _db;
    private readonly ILogger<PostController> _logger;
    private readonly IMapper _mapper;
    private readonly IPost _post;
    private readonly IPostType _TypeService;
    private readonly IUser _UserService;

    public PostController(ILogger<PostController> logger, DrTaabodiDbContext db, IUser user, IMapper mapper, IPost post,
        IPostCategory postCategory, IPostType PostType)
    {
        _logger = logger;
        _db = db;
        _UserService = user;
        _mapper = mapper;
        _post = post;
        _CategoryService = postCategory;
        _TypeService = PostType;
    }

    [HttpGet]
    public async Task<ActionResult<ReadPosts>> GetAllPost([FromHeader] QnAParametes qnaParameters)
    {
        _logger.LogInformation("read all Posts");
        var posts = await _post.GetAllPosts(qnaParameters);

        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadPosts>> GetPostById(Guid id)
    {
        _logger.LogInformation("Read Id Post");
        var post = await _post.GetPostById(id);
        return Ok(_mapper.Map<ReadPosts>(post));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<CreatePosts>>> CreatePost([FromBody] CreatePosts Post)
    {
        _logger.LogInformation("Create Post");
        var mapPost = _mapper.Map<PstTbl>(Post);


        if (Post.User != null && Post.User != Guid.Empty &&
            Post.User != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
        {
            var user = await _UserService.GetUserById(Post.User);
            mapPost.UserTable.Add(user);
        }

        if (Post.PstTbleParent != null && Post.PstTbleParent != Guid.Empty &&
            Post.PstTbleParent != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
        {
            var PostParent = await _post.GetPostById(Post.PstTbleParent);
            mapPost.ParentId = Post.PstTbleParent;
        }

        //if (Post.PstTbleParent != null)
        //    mapPost.PstTbleParent.


        var newPost = _post.CreatePost(mapPost);

        return Ok(newPost);
    }

    [HttpPost("/PostCreateUsingCategoryAndType")]
    public async Task<ActionResult<ServiceResponse<CreatePostWithTypeAndCategory>>> PostCreateUsingCategoryAndType(
        [FromBody] CreatePostWithTypeAndCategory Post)
    {
        _logger.LogInformation("CreatePostWithTypeAndCategory");
        var mapPost = _mapper.Map<PstTbl>(Post);
        if (Post.User != null && Post.User != Guid.Empty &&
            Post.User != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.UserTable.Add(await _UserService.GetUserById(Post.User));
        if (Post.PstTbleParent != null && Post.PstTbleParent != Guid.Empty &&
            Post.PstTbleParent != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.ParentId = Post.PstTbleParent;
        if (Post.PostCategory != null && Post.PostCategory != Guid.Empty &&
            Post.PostCategory != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.PostCategoryTable.Add(await _CategoryService.GetPostById(Post.PostCategory));
        if (Post.PostType != null && Post.PostType != Guid.Empty &&
            Post.PostType != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.PostTypeTable.Add(await _TypeService.GetPostById(Post.PostType));
        //if(Post.Meta != null && Post.Meta != Guid.Empty &&Post.Meta != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
        //    mapPost.

        var newPost = _post.CreatePost(mapPost);

        return Ok(newPost);
    }

    /*[HttpPatch("/postStatus/")]
    public ActionResult<ReadPosts> updatePostStatus([FromBody] ReadPosts Post)
    {
        //_logger.LogInformation("Update Post Status");
        //var id = Post.PstId;
        //var PostStatus = Post.PstStatus;
        //var UpdatedPost = _post.UpdatePostStatus(id, PostStatus);
        //return Ok(_mapper.Map<PstTbl>(UpdatedPost));
    }*/
    [HttpPatch]
    public async Task<ActionResult<ReadPosts>> UpdatePost([FromBody] ReadPosts Post)
    {
        _logger.LogInformation("Update Post Status");
        var id = Post.PstId;
        var mapPost = _mapper.Map<PstTbl>(Post);
        if (Post.User != null && Post.User != Guid.Empty &&
            Post.User != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.UserTable.Add(await _UserService.GetUserById(Post.User));
        if (Post.PstTbleParent != null && Post.PstTbleParent != Guid.Empty &&
            Post.PstTbleParent != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.ParentId = Post.PstTbleParent;
        if (Post.PostCategory != null && Post.PostCategory != Guid.Empty &&
            Post.PostCategory != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.PostCategoryTable.Add(await _CategoryService.GetPostById(Post.PostCategory));
        if (Post.PostType != null && Post.PostType != Guid.Empty &&
            Post.PostType != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
            mapPost.PostTypeTable.Add(await _TypeService.GetPostById(Post.PostType));
        //var mapPost = _mapper.Map<PstTbl>(Post);
        var UpdatedPost = _post.UpdatePostStatus(id, mapPost);
        //var updated = _mapper.Map<PstTbl>(UpdatedPost);
        return Ok(UpdatedPost);
    }
}