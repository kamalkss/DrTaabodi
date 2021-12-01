using System.Linq;
using DrTaabodi.Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace DrTaabodi.WebControllers;

public class HomeController : Controller
{
    private readonly DrTaabodiDbContext _db;

    public HomeController(DrTaabodiDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var model = _db.WebsiteOptionsTbls.Select(x => new {key = x.OptionKey, value = x.OptionValue})
            .ToDictionary(x => x.key, x => x.value);
        if (model.Count > 0)
        {
            ViewData["Title"] = model.ContainsKey("general_meta_title") ? model["general_meta_title"] : "";
            ViewData["Description"] =
                model.ContainsKey("general_meta_description") ? model["general_meta_description"] : "";
        }

        return View(model);
    }

    //what 

    [Route("/faq")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult FAQ()
    {
        return View(_db.QnATbl.ToList());
    }
}