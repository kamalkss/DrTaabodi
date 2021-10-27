using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.WebsiteOptions;
using DrTaabodi.WebApi.DTO.WebsiteOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrTaabodi.WebApi.Controllers
{
    [ApiController, Route("api/options")]
    public class OptionsController : ControllerBase
    {
        private readonly IOptions _options;
        private readonly ILogger<OptionsController> _logger;
        private readonly IMapper _mapper;
        private readonly Data.DatabaseContext.DrTaabodiDbContext _context;
        public OptionsController(IOptions options, ILogger<OptionsController> logger, IMapper mapper, Data.DatabaseContext.DrTaabodiDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _options = options;
            _context = context;
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
            if (Option == null)
            {
                var Mapped = _mapper.Map<WebsiteOptionsTbl>(postCategory);
                var NewPost = _options.CreateOption(Mapped);
                return Ok(NewPost);
            }
            else
            {
                var Mapped = _mapper.Map<WebsiteOptionsTbl>(postCategory);
                var NewPost = _options.UpdateOption(postCategory.OptionKey, Mapped);
                return Ok(NewPost);

            }


        }

        [HttpPost("all")]
        public ActionResult SaveAll(IEnumerable<KeyValuePair<string, string>> result)
        {
            foreach (KeyValuePair<string, string> item in result)
            {
                WebsiteOptionsTbl row = _context.WebsiteOptionsTbls.First(x => x.OptionKey == item.Key);
                if(row!= null)
                {
                    row.OptionValue = item.Value;                   
                }
                else
                {
                    _context.WebsiteOptionsTbls.Add(new WebsiteOptionsTbl { OptionKey = item.Key, OptionValue = item.Value });
                }
            }
            _context.SaveChanges();
            return Ok();
        }


    }
}
