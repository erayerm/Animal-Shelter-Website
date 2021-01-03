using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hayvan_Barinagi.Data;
using Hayvan_Barinagi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Hayvan_Barinagi.Controllers
{
    public class HayvanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HayvanController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Hayvan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hayvan.Include(h => h.Cins).Include(h => h.Cinsiyet).Include(h => h.Tur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hayvan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvan
                .Include(h => h.Cins)
                .Include(h => h.Cinsiyet)
                .Include(h => h.Tur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        // GET: Hayvan/Create
        public IActionResult Create()
        {
            ViewData["CinsID"] = new SelectList(_context.Cins, "Id", "CinsAd");
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyet, "Id", "CinsiyetAd");
            ViewData["TurID"] = new SelectList(_context.Tur, "Id", "TurAd");
            return View();
        }

        // POST: Hayvan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,DogumYili,Hakkinda,Fotograf,TurID,CinsID,CinsiyetID")] Hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\hayvan");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                hayvan.Fotograf = @"\images\hayvan\" + fileName + extension;

                _context.Add(hayvan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinsID"] = new SelectList(_context.Cins, "Id", "CinsAd", hayvan.CinsID);
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyet, "Id", "CinsiyetAd", hayvan.CinsiyetID);
            ViewData["TurID"] = new SelectList(_context.Tur, "Id", "TurAd", hayvan.TurID);
            return View(hayvan);
        }

        // GET: Hayvan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvan.FindAsync(id);
            if (hayvan == null)
            {
                return NotFound();
            }
            ViewData["CinsID"] = new SelectList(_context.Cins, "Id", "CinsAd", hayvan.CinsID);
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyet, "Id", "CinsiyetAd", hayvan.CinsiyetID);
            ViewData["TurID"] = new SelectList(_context.Tur, "Id", "TurAd", hayvan.TurID);
            return View(hayvan);
        }

        // POST: Hayvan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,DogumYili,Hakkinda,Fotograf,TurID,CinsID,CinsiyetID")] Hayvan hayvan)
        {
            if (id != hayvan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hayvan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HayvanExists(hayvan.Id))
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
            ViewData["CinsID"] = new SelectList(_context.Cins, "Id", "CinsAd", hayvan.CinsID);
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyet, "Id", "CinsiyetAd", hayvan.CinsiyetID);
            ViewData["TurID"] = new SelectList(_context.Tur, "Id", "TurAd", hayvan.TurID);
            return View(hayvan);
        }

        // GET: Hayvan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hayvan = await _context.Hayvan
                .Include(h => h.Cins)
                .Include(h => h.Cinsiyet)
                .Include(h => h.Tur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            return View(hayvan);
        }

        // POST: Hayvan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hayvan = await _context.Hayvan.FindAsync(id);
            _context.Hayvan.Remove(hayvan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HayvanExists(int id)
        {
            return _context.Hayvan.Any(e => e.Id == id);
        }
    }
}
