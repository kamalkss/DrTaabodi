using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System.Web;

namespace DrTaabodi.WebControllers;

public class HomeController : Controller
{
    private readonly DrTaabodiDbContext _db;
    private readonly IWebHostEnvironment env;
    private readonly IHostingEnvironment _environment;

    public HomeController(DrTaabodiDbContext db, IWebHostEnvironment env, IHostingEnvironment environment)
    {
        _environment = environment;
        _db = db;
        this.env = env;
    }

    public IActionResult Index()
    {
        try
        {
            var option = _db.WebsiteOptionsTbls.First(x => x.OptionKey == "website_pages__home");
            if (option != null) return Content(option.OptionValue, "text/html");
        }
        catch (Exception e)
        {
        }


        var path = Path.Combine(env.WebRootPath, "template/index.html");
        string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\template\\index.html");
        if (System.IO.File.Exists(path))
            return Content(System.IO.File.ReadAllText(path), "text/html");
        if (System.IO.File.Exists(path1))
            return Content(System.IO.File.ReadAllText(path1), "text/html");
        return NotFound();
    }

    //what 

    [Route("/faq")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult FAQ()
    {
        var path = Path.Combine(env.WebRootPath, "template/faq.html");
        string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\template\\faq.html");
        if (System.IO.File.Exists(path))
        {
            var content = System.IO.File.ReadAllText(path);
            content = content.Replace("[JSON_DATA]", JsonConvert.SerializeObject(_db.QnATbl
                .Select(x => new { x.Question, x.Answer, x.CreatedDate })
                .ToList()));
            return LoadPageContent(content);
        }
        if (System.IO.File.Exists(path1))
        {
            var content = System.IO.File.ReadAllText(path1);
            content = content.Replace("[JSON_DATA]", JsonConvert.SerializeObject(_db.QnATbl
                .Select(x => new { x.Question, x.Answer, x.CreatedDate })
                .ToList()));
            return LoadPageContent(content);
        }
        return NotFound();
    }

    [Route("/articles")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Articles()
    {
        var path = Path.Combine(env.WebRootPath, "template/articles.html");
        if (System.IO.File.Exists(path))
        {
            int page = 0;
            int.TryParse(Request.Query["page"], out page);
            page -= 1;
            if (page <= 0)
                page = 0;

            int perPage = 0;
            int.TryParse(Request.Query["per_page"], out perPage);
            if (perPage <= 0)
                perPage = 50;
            double totalPages = Math.Ceiling((double)(_db.PstTbl.Count() / perPage));

            var content = System.IO.File.ReadAllText(path);
            content = content.Replace("[JSON_DATA]", JsonConvert.SerializeObject(new
            {
                contents = _db.PstTbl.Skip(page * perPage).Take(perPage).ToList(),
                page = page + 1,
                perPage,
                totalPages
            }));
            return LoadPageContent(content);
        }

        return NotFound();
    }

    [Route("/article/{pstId}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Page(Guid? pstId)
    {
        var post = _db.PstTbl.Find(pstId);
        if (post == null)
            return NotFound();

        var path = Path.Combine(env.WebRootPath, "template\\post.html");
        string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\template\\post.html");
        if (System.IO.File.Exists(path))
        {
            var content = System.IO.File.ReadAllText(path);
            content = content.Replace("[title]", post.PstTitle);
            content = content.Replace("[description]", post.PstDescription);
            content = content.Replace("[content]", post.PstContent);
            content = content.Replace("[date]", post.CreatedDate.ToPersianCalender() ?? "---");
            content = content.Replace("[time]", post.CreatedDate.ToShortTimeString() ?? "---");


            return LoadPageContent(content);
        }
        
        else if (System.IO.File.Exists(path1))
        {
            var content = System.IO.File.ReadAllText(path1);
            content = content.Replace("[title]", post.PstTitle);
            content = content.Replace("[description]", post.PstDescription);
            content = content.Replace("[content]", post.PstContent);
            content = content.Replace("[date]", post.CreatedDate.ToPersianCalender() ?? "---");
            content = content.Replace("[time]", post.CreatedDate.ToShortTimeString() ?? "---");


            return LoadPageContent(content);
        }

        return NotFound();
    }

    private ContentResult LoadPageContent(string content)
    {
        var machs = Regex.Matches(content, @"\[(?<name>[^\]]*)\]");
        foreach (Match match in machs)
        {
            var part = _db.WebsiteOptionsTbls.Where(x =>
                x.OptionKey == $"website_pages__home_theme_part_{match.Groups["name"].Value}");
            if (part.Any()) content = content.Replace(match.Value, part.First().OptionValue);
        }

        return Content(content, "text/html");
    }
}