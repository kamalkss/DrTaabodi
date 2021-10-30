using AutoMapper;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Services.QnATable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrTaabodi.WebControllers
{
    public class HomeController : Controller
    {
        private readonly DrTaabodiDbContext _db;

        public HomeController(DrTaabodiDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.WebsiteOptionsTbls.Select(x => new { key = x.OptionKey, value = x.OptionValue }).ToDictionary(x => x.key, x => x.value);
            if (model.Count > 0)
            {
                ViewData["Title"] = model["general_meta_title"] ?? "";
                ViewData["Description"] = model["general_meta_description"] ?? "";
            }
            return View(model);
        }

        //what ?

        [Route("/faq"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult FAQ()
        {
            return View(_db.QnATbl.ToList());
        }
    }
}
