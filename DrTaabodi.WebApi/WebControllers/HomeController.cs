﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DrTaabodi.Data.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DrTaabodi.WebControllers;

public class HomeController : Controller
{
    private readonly DrTaabodiDbContext _db;
    private readonly IWebHostEnvironment env;

    public HomeController(DrTaabodiDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        this.env = env;
    }

    public IActionResult Index()
    {
        try
        {
            var option = _db.WebsiteOptionsTbls.First(x => x.OptionKey == "website_pages__home");
            if (option != null)
            {
                return Content(option.OptionValue, "text/html");
            }
        }
        catch (Exception e)
        {

        }


        string path = Path.Combine(env.WebRootPath, "template/index.html");
        if (System.IO.File.Exists(path))
        {
            return Content(System.IO.File.ReadAllText(path), "text/html");
        }
        else return NotFound();
    }

    //what 

    [Route("/faq")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult FAQ()
    {
        return View(_db.QnATbl.ToList());
    }

    [Route("/article/{pstId}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Page(Guid? pstId)
    {
        var post = _db.PstTbl.Find(pstId);
        if (post == null)
            return NotFound();

        string path = Path.Combine(env.WebRootPath, "template/post.html");
        if (System.IO.File.Exists(path))
        {
            string content = System.IO.File.ReadAllText(path);
            content = content.Replace("[title]", post.PstTitle);
            content = content.Replace("[description]", post.PstDescription);
            content = content.Replace("[content]", post.PstContent);


            var machs = Regex.Matches(content, @"\[(?<name>[^\]]*)\]");
            foreach (Match match in machs)
            {
                var part = _db.WebsiteOptionsTbls.Where(x => x.OptionKey == $"website_pages__home_theme_part_{match.Groups["name"].Value}");
                if (part.Any())
                {
                    content = content.Replace(match.Value, part.First().OptionValue);
                }
            }
            return Content(content, "text/html");
        }
        else return NotFound();
    }
}