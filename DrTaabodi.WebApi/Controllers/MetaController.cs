using System;
using System.Threading.Tasks;
using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.MetaTable;
using DrTaabodi.Services.PostTable;
using DrTaabodi.WebApi.DTO.Meta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrTaabodi.WebApi.Controllers;

[Route("/api/meta")]
[ApiController]
public class MetaController : ControllerBase
{
    private readonly DrTaabodiDbContext _context;
    private readonly ILogger<MetaController> _logger;
    private readonly IMapper _mapper;
    private readonly IMeta _metaService;
    private readonly IPost _postService;

    public MetaController(ILogger<MetaController> logger, DrTaabodiDbContext db, IMeta meta, IMapper mapper, IPost post)
    {
        _context = db;
        _logger = logger;
        _metaService = meta;
        _mapper = mapper;
        _postService = post;
    }

    [HttpGet]
    public async Task<ActionResult<ReadMeta>> GetAllMetas()
    {
        var AllMetas = await _metaService.GetAllPosts();
        return Ok(AllMetas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadMeta>> GetMetaById(Guid id)
    {
        var meta = await _metaService.GetPostById(id);
        return Ok(meta);
    }

    [HttpGet("post/{id}")]
    public async Task<ActionResult<ReadMeta>> GetMetaByPostId(Guid id)
    {
        var metaList = await _metaService.GetMetasWithPostId(id);
        return Ok(metaList);
    }

    [HttpPost]
    public async Task<ActionResult<CreateMeta>> CreateMeta([FromBody] CreateMeta createMeta)
    {
        var mapPost = _mapper.Map<MetaTbl>(createMeta);


        var newPost = _metaService.CreatePost(mapPost);

        return Ok(newPost);
    }

    [HttpPatch]
    public async Task<ActionResult<ReadMeta>> UpdateMeta()
    {
        return Ok();
    }
}