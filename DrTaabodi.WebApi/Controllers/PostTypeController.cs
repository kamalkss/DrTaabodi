using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.PostTable;
using DrTaabodi.Services.PostTypeTable;
using DrTaabodi.WebApi.DTO.PostType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController]
    [Route("/api/posttype")]
    public class PostTypeController:ControllerBase
    {
        private readonly IPost _postService;
        private readonly IPostType _postTypeService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public PostTypeController(IPost Post, IPostType PostType, ILogger logger, IMapper mapper)
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
        public ActionResult<ServiceResponse<CreatePostType>> CreatePost([FromBody] CreatePostType PostType)
        {
            var MapPost = _mapper.Map<PostTypeTbl>(PostType);
            var NewPost = _postTypeService.CreatePostType(MapPost);
            return Ok(NewPost);
        }
    }
}
