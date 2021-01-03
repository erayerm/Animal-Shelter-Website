using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hayvan_Barinagi.Data;
using Hayvan_Barinagi.Models;
using Microsoft.Extensions.Localization;


namespace Hayvan_Barinagi.Controllers
{
    public class CinsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<CinsController> _localizer;
        public CinsController(ApplicationDbContext context, IStringLocalizer<CinsController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        // GET: Cins
        public async Task<IActionResult> Index()
        {

            ViewData["Duzenle"] = _localizer["Duzenle"];
            ViewData["CinsAd"] = _localizer["CinsAd"];
            ViewData["Detaylar"] = _localizer["Detaylar"];
            ViewData["Sil"] = _localizer["Sil"];
            ViewData["YeniKayitOlustur"] = _localizer["YeniKayitOlustur"];
            return View(await _context.Cins.ToListAsync());

        }

        // GET: Cins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Duzenle"] = _localizer["Duzenle"];
            ViewData["CinsAd"] = _localizer["CinsAd"];
            ViewData["ListeyeGeriDon"] = _localizer["ListeyeGeriDon"];

            if (id == null)
            {
                return NotFound();
            }

            var cins = await _context.Cins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cins == null)
            {
                return NotFound();
            }

            return View(cins);
        }

        // GET: Cins/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: Cins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CinsAd")] Cins cins)
        {
            ViewData["Olustur"] = _localizer["Olustur"];
            ViewData["CinsAd"] = _localizer["CinsAd"];
            ViewData["ListeyeGeriDon"] = _localizer["ListeyeGeriDon"];
            if (ModelState.IsValid)
            {
                _context.Add(cins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cins);
        }

        // GET: Cins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Kaydet"] = _localizer["Kaydet"];
            ViewData["CinsAd"] = _localizer["CinsAd"];
            ViewData["ListeyeGeriDon"] = _localizer["ListeyeGeriDon"];
            if (id == null)
            {
                return NotFound();
            }

            var cins = await _context.Cins.FindAsync(id);
            if (cins == null)
            {
                return NotFound();
            }
            return View(cins);
        }

        // POST: Cins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CinsAd")] Cins cins)
        {
            if (id != cins.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinsExists(cins.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cins);
        }

        // GET: Cins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cins = await _context.Cins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cins == null)
            {
                return NotFound();
            }

            return View(cins);
        }

        // POST: Cins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cins = await _context.Cins.FindAsync(id);
            _context.Cins.Remove(cins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinsExists(int id)
        {
            return _context.Cins.Any(e => e.Id == id);
        }
    }
}
