using System;
using System.IO;
using System.Linq;
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
}