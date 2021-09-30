using System;
using System.Linq;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.PostTable;
using DrTaabodi.Services.UserTable;
using DrTaabodi.WebApi.DTO.Posts;
using DrTaabodi.WebApi.DTO.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers
{
    [Route("/api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUser _UserService;
        private readonly IPost _post;
        private readonly DrTaabodiDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, DrTaabodiDbContext db, IUser user, IMapper mapper, IPost post)
        {
            _logger = logger;
            _db = db;
            _UserService = user;
            _mapper = mapper;
            _post = post;
        }

        [HttpGet]
        public ActionResult<ReadPosts> GetAllPost()
        {
            _logger.LogInformation("read all Posts");
            var posts = _post.GetAllPosts();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadPosts> GetPostById(Guid id)
        {
            _logger.LogInformation("Read Id Post");
            var post = _post.GetPostById(id);
            return Ok(_mapper.Map<ReadPosts>(post));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<CreatePosts>> CreatePost([FromBody] CreatePosts Post)
        {
            _logger.LogInformation("Create Post");
            
            
            //if (Post.User != null)
            //    Post.User = _UserService.GetUserById(Post.User);
            
            //if (Post.PstTbleParent != null)
            //    Post.PstTbleParent = _post.GetPostById(Post.PstTbleParent);
            var mapPost = _mapper.Map<PstTbl>(Post);


            if (Post.User != null && Post.User != Guid.Empty && Post.User != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                mapPost.UserTable.Add(_UserService.GetUserById(Post.User));
            if (Post.PstTbleParent != null && Post.PstTbleParent != Guid.Empty && Post.PstTbleParent != Guid.Parse("{00000000-0000-0000-0000-000000000000}"))
                mapPost.PstTblParent.Add(_post.GetPostById(Post.PstTbleParent));
            //if (Post.PstTbleParent != null)
            //    mapPost.PstTbleParent.
            
            
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
        [HttpPatch("/posttype/")]
        public ActionResult<ReadPosts> UpdatePost([FromBody] ReadPosts Post)
        {
            _logger.LogInformation("Update Post Status");
            var id = Post.PstId;
            if (Post.User != null)
                Post.User = _UserService.GetUserById(Post.User.UsrId);

            if (Post.PstTbleParent != null)
                Post.PstTbleParent = _post.GetPostById(Post.PstTbleParent.PstId);
            var mapPost = _mapper.Map<PstTbl>(Post);
            var UpdatedPost = _post.UpdatePostStatus(id, mapPost);
            return Ok(_mapper.Map<PstTbl>(UpdatedPost));
        }
    }
}
