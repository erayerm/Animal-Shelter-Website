using Hayvan_Barinagi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hayvan_Barinagi.Controllers
{
    public class SahiplenController : Controller
    {
        private ApplicationDbContext _context;

        public SahiplenController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Tur = _context.Tur;
            return View();
        }
    }
}
