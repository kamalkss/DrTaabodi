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
        private readonly ILogger<UsersController> _logger;

        public PostController(ILogger<UsersController> logger, DrTaabodiDbContext db, IUser user, IMapper mapper,IPost post)
        {
            _logger = logger;
            _db = db;
            _UserService = user;
            _mapper = mapper;
            _post = post;
        }

        [HttpPost]
        public ActionResult<ReadPosts> GetAllPost()
        {
            _logger.LogInformation("read all Posts");
            var posts = _post.GetAllPosts().Select(pi=>new ReadUsers
            {
                UsrId = pi.User.UsrId
            });

            return Ok(_mapper.Map<ReadPosts>(posts));
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
            Post.CreatedDate = DateTime.UtcNow;
            Post.UpdatedData = DateTime.UtcNow;
            var mapPost = _mapper.Map<PstTbl>(Post);
            var newPost = _post.CreatePost(mapPost);
            
            return Ok(newPost);
        }
    }
}
