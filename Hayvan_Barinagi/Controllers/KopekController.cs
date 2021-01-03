using Hayvan_Barinagi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hayvan_Barinagi.Controllers
{
    public class KopekController : Controller
    {
        private ApplicationDbContext _context;

        public KopekController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var kopekList = (from f in _context.Hayvan
                            join g in _context.Cins on f.CinsID equals g.Id
                            join h in _context.Cinsiyet on f.CinsiyetID equals h.Id
                            join j in _context.Tur on f.TurID equals j.Id
                            select new HayvanDTO
                            {
                                Ad = f.Ad,
                                Hakkinda = f.Hakkinda,
                                Fotograf = f.Fotograf,
                                TurID = f.TurID,
                                Tur = j.TurAd,
                                CinsID = f.CinsID,
                                CinsiyetID = f.CinsiyetID,
                                Cins = g.CinsAd,
                                Cinsiyet = h.CinsiyetAd,
                                DogumYili = f.DogumYili

                            })
                            .ToList();

            var kopeks = kopekList.ToList();

            return View(kopeks);
        }
    }
}
