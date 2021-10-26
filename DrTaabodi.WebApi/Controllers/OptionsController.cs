using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.WebsiteOptions;
using DrTaabodi.WebApi.DTO.WebsiteOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController, Route("api/options")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptions _options;
        private readonly ILogger<OptionsController> _logger;
        private readonly IMapper _mapper;
        public OptionsController(IOptions options,ILogger<OptionsController> logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _options = options;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateOption>>> GetAllPosts()
        {
            _logger.LogInformation("read all Posts");
            var Post = _options.GetWebsiteOptionsAsync();
            return Ok(Post);
        }

        [HttpGet("{Key}")]
        public async Task<ActionResult<IEnumerable<UpdateOption>>> GetSinglePostCategory([FromBody] string id)
        {
            _logger.LogInformation("read single Posts");
            var Post = _options.GetWebsiteOptionsById(id);
            return Ok(Post);
        }

        [HttpPost]
        public ActionResult<ServiceResponse<UpdateOption>> CreatePostCategory(
            [FromBody] UpdateOption postCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Option = _options.GetWebsiteOptionsById(postCategory.OptionKey);
            if(Option == null)
            {
                var Mapped = _mapper.Map<WebsiteOptionsTbl>(postCategory);
                var NewPost = _options.CreateOption(Mapped);
                return Ok(NewPost);
            }
            else
            {
                var Mapped = _mapper.Map<WebsiteOptionsTbl>(postCategory);
                var NewPost = _options.UpdateOption(postCategory.OptionId, Mapped);
                return Ok(NewPost);
                
            }
            

        }

        
    }
}
