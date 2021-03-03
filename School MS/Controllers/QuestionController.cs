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
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblQuestion.Include(t => t.tblChapter).Include(t => t.tblSubject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuestion = await _context.tblQuestion
                .Include(t => t.tblChapter)
                .Include(t => t.tblSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblQuestion == null)
            {
                return NotFound();
            }

            return View(tblQuestion);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            ViewData["Chaptertid"] = new SelectList(_context.tblChapter, "Id", "ChaptertName");
            ViewData["SubjectId"] = new SelectList(_context.tblSubject, "Id", "SubjectName");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectId,Chaptertid,QuestionNo,QuestionName,QuestionAnswer,ImageUrl,VideoUrl,CreatedDate,CreatedBy")] tblQuestion tblQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Chaptertid"] = new SelectList(_context.tblChapter, "Id", "ChaptertName", tblQuestion.Chaptertid);
            ViewData["SubjectId"] = new SelectList(_context.tblSubject, "Id", "SubjectName", tblQuestion.SubjectId);
            return View(tblQuestion);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuestion = await _context.tblQuestion.FindAsync(id);
            if (tblQuestion == null)
            {
                return NotFound();
            }
            ViewData["Chaptertid"] = new SelectList(_context.tblChapter, "Id", "Id", tblQuestion.Chaptertid);
            ViewData["SubjectId"] = new SelectList(_context.tblSubject, "Id", "Id", tblQuestion.SubjectId);
            return View(tblQuestion);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectId,Chaptertid,QuestionNo,QuestionName,QuestionAnswer,ImageUrl,VideoUrl,CreatedDate,CreatedBy")] tblQuestion tblQuestion)
        {
            if (id != tblQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblQuestionExists(tblQuestion.Id))
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
            ViewData["Chaptertid"] = new SelectList(_context.tblChapter, "Id", "Id", tblQuestion.Chaptertid);
            ViewData["SubjectId"] = new SelectList(_context.tblSubject, "Id", "Id", tblQuestion.SubjectId);
            return View(tblQuestion);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblQuestion = await _context.tblQuestion
                .Include(t => t.tblChapter)
                .Include(t => t.tblSubject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblQuestion == null)
            {
                return NotFound();
            }

            return View(tblQuestion);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblQuestion = await _context.tblQuestion.FindAsync(id);
            _context.tblQuestion.Remove(tblQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblQuestionExists(int id)
        {
            return _context.tblQuestion.Any(e => e.Id == id);
        }
    }
}
