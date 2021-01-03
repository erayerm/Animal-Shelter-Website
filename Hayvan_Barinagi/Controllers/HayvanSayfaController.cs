using Hayvan_Barinagi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hayvan_Barinagi.Controllers
{
    public class HayvanSayfaController : Controller
    {
        private ApplicationDbContext _context;

        public HayvanSayfaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var hayvanList = (from f in _context.Hayvan
                              join g in _context.Cins on f.CinsID equals g.Id
                              join h in _context.Cinsiyet on f.CinsiyetID equals h.Id
                              join j in _context.Tur on f.TurID equals j.Id
                              select new HayvanDTO
                              {
                                  Ad = f.Ad,
                                  Hakkinda = f.Hakkinda,
                                  Fotograf = f.Fotograf,
                                  TurID = f.TurID,
                                  Tur=j.TurAd,
                                  CinsID = f.CinsID,
                                  CinsiyetID = f.CinsiyetID,
                                  Cins = g.CinsAd,
                                  Cinsiyet = h.CinsiyetAd,
                                  DogumYili = f.DogumYili

                              })
                            .ToList();

            var hayvans = hayvanList.ToList();

            return View(hayvans);
        }


    }
    public class HayvanDTO
    {
        public string Ad { get; internal set; }
        public string Hakkinda { get; internal set; }
        public string Fotograf { get; internal set; }
        public int TurID { get; internal set; }
        public string Tur { get; internal set; }
        public int CinsID { get; internal set; }
        public int CinsiyetID { get; internal set; }
        public string Cins { get; internal set; }
        public string Cinsiyet { get; internal set; }
        public int? DogumYili { get; internal set; }
    }
}

