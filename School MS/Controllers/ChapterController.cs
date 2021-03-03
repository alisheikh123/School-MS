using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_MS.Data;
using School_MS.Models;

namespace School_MS.Controllers
{
    public class ChapterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChapterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chapter
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblChapter.Include(t => t.tblSubject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chapter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChapter = await _context.tblChapter
                .Include(t => t.tblSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblChapter == null)
            {
                return NotFound();
            }

            return View(tblChapter);
        }

        // GET: Chapter/Create
        public IActionResult Create()
        {
            ViewData["SubjectID"] = new SelectList(_context.tblSubject, "Id", "SubjectName");
            return View();
        }

        // POST: Chapter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChaptertName,SubjectID")] tblChapter tblChapter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChapter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectID"] = new SelectList(_context.tblSubject, "Id", "SubjectName", tblChapter.SubjectID);
            return View(tblChapter);
        }

        // GET: Chapter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChapter = await _context.tblChapter.FindAsync(id);
            if (tblChapter == null)
            {
                return NotFound();
            }
            ViewData["SubjectID"] = new SelectList(_context.tblSubject, "Id", "SubjectName", tblChapter.SubjectID);
            return View(tblChapter);
        }

        // POST: Chapter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChaptertName,SubjectID")] tblChapter tblChapter)
        {
            if (id != tblChapter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChapter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblChapterExists(tblChapter.Id))
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
            ViewData["SubjectID"] = new SelectList(_context.tblSubject, "Id", "SubjectName", tblChapter.SubjectID);
            return View(tblChapter);
        }

        // GET: Chapter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChapter = await _context.tblChapter
                .Include(t => t.tblSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblChapter == null)
            {
                return NotFound();
            }

            return View(tblChapter);
        }

        // POST: Chapter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblChapter = await _context.tblChapter.FindAsync(id);
            _context.tblChapter.Remove(tblChapter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblChapterExists(int id)
        {
            return _context.tblChapter.Any(e => e.Id == id);
        }
    }
}
