using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.Services;
using DrTaabodi.Services.WebsiteOptions;
using DrTaabodi.WebApi.DTO.WebsiteOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<ActionResult> GetSinglePostCategory([FromRoute] string key)
        {
            _logger.LogInformation("read single Posts");
            if (!_context.WebsiteOptionsTbls.Any())
                return NotFound();
            var Post = _context.WebsiteOptionsTbls.FirstOrDefault(x => x.OptionKey == key);
            if (Post == null)
                return NotFound();

            return Ok(Post.OptionValue);
        }

        [HttpPost("{Key}")]
        public async Task<ActionResult> updateOrInsertSinglePostCategory([FromRoute] string key)
        {
            string content = await new StreamReader(Request.Body).ReadToEndAsync();
            _logger.LogInformation("update or insert single Posts");
            if (!_context.WebsiteOptionsTbls.Any())
                return NotFound();
            var Post = _context.WebsiteOptionsTbls.FirstOrDefault(x => x.OptionKey == key);
            if (Post == null)
                _context.WebsiteOptionsTbls.Add(new WebsiteOptionsTbl { OptionKey = key, OptionValue = content });
            else
                Post.OptionValue = content;
            _context.SaveChanges();

            return Ok();
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
        public ActionResult<dynamic> saveAll(JObject obj)
        {

            foreach(var x in obj.Properties())
            {
                var Post = _context.WebsiteOptionsTbls.FirstOrDefault(o => o.OptionKey == x.Name);
                if (Post == null)
                    _context.WebsiteOptionsTbls.Add(new WebsiteOptionsTbl { OptionKey = x.Name, OptionValue = x.Value.ToString() });
                else
                    Post.OptionValue = x.Value.ToString();
            }
            _context.SaveChanges();

            return Ok();
        }

    }
}
