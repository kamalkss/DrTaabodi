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
            return View();
        }

        [Route("/faq"), ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult FAQ()
        {
            return View(_db.QnATbl.ToList());
        }
    }
}
