using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hayvan_Barinagi.Data;
using Hayvan_Barinagi.Models;

namespace Hayvan_Barinagi.Controllers
{
    public class CinsiyetController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public CinsiyetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cinsiyet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinsiyet.ToListAsync());
        }

        // GET: Cinsiyet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // GET: Cinsiyet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinsiyet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CinsiyetAd")] Cinsiyet cinsiyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinsiyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinsiyet);
        }

        // GET: Cinsiyet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyet.FindAsync(id);
            if (cinsiyet == null)
            {
                return NotFound();
            }
            return View(cinsiyet);
        }

        // POST: Cinsiyet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CinsiyetAd")] Cinsiyet cinsiyet)
        {
            if (id != cinsiyet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinsiyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinsiyetExists(cinsiyet.Id))
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
            return View(cinsiyet);
        }

        // GET: Cinsiyet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // POST: Cinsiyet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinsiyet = await _context.Cinsiyet.FindAsync(id);
            _context.Cinsiyet.Remove(cinsiyet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinsiyetExists(int id)
        {
            return _context.Cinsiyet.Any(e => e.Id == id);
        }
    }
}
