using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeachingAssigment.Data;
using TeachingAssigment.Models;

namespace TeachingAssigment.Controllers
{
    public class ProfessorInfoesController : Controller
    {
        private readonly TeachingAssigmentContext _context;

        public ProfessorInfoesController(TeachingAssigmentContext context)
        {
            _context = context;
        }

        // GET: ProfessorInfoes
        public async Task<IActionResult> Index()
        {
            var teachingAssigmentContext = _context.ProfessorInfo.Include(p => p.Day).Include(p => p.Time);
            return View(await teachingAssigmentContext.ToListAsync());
        }

        // GET: ProfessorInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorInfo = await _context.ProfessorInfo
                .Include(p => p.Day)
                .Include(p => p.Time)
                .FirstOrDefaultAsync(m => m.ProfessorInfoId == id);
            if (professorInfo == null)
            {
                return NotFound();
            }

            return View(professorInfo);
        }

        // GET: ProfessorInfoes/Create
        public IActionResult Create()
        {
            ViewData["DayId"] = new SelectList(_context.Set<Day>(), "DayId", "DayId");
            ViewData["TimeId"] = new SelectList(_context.Set<Time>(), "TimeId", "TimeId");
            return View();
        }

        // POST: ProfessorInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorInfoId,Name,CourseCode,CourseDay,CourseTime,LectureName,DayId,TimeId")] ProfessorInfo professorInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DayId"] = new SelectList(_context.Set<Day>(), "DayId", "DayId", professorInfo.DayId);
            ViewData["TimeId"] = new SelectList(_context.Set<Time>(), "TimeId", "TimeId", professorInfo.TimeId);
            return View(professorInfo);
        }

        // GET: ProfessorInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorInfo = await _context.ProfessorInfo.FindAsync(id);
            if (professorInfo == null)
            {
                return NotFound();
            }
            ViewData["DayId"] = new SelectList(_context.Set<Day>(), "DayId", "DayId", professorInfo.DayId);
            ViewData["TimeId"] = new SelectList(_context.Set<Time>(), "TimeId", "TimeId", professorInfo.TimeId);
            return View(professorInfo);
        }

        // POST: ProfessorInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessorInfoId,Name,CourseCode,CourseDay,CourseTime,LectureName,DayId,TimeId")] ProfessorInfo professorInfo)
        {
            if (id != professorInfo.ProfessorInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorInfoExists(professorInfo.ProfessorInfoId))
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
            ViewData["DayId"] = new SelectList(_context.Set<Day>(), "DayId", "DayId", professorInfo.DayId);
            ViewData["TimeId"] = new SelectList(_context.Set<Time>(), "TimeId", "TimeId", professorInfo.TimeId);
            return View(professorInfo);
        }

        // GET: ProfessorInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorInfo = await _context.ProfessorInfo
                .Include(p => p.Day)
                .Include(p => p.Time)
                .FirstOrDefaultAsync(m => m.ProfessorInfoId == id);
            if (professorInfo == null)
            {
                return NotFound();
            }

            return View(professorInfo);
        }

        // POST: ProfessorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorInfo = await _context.ProfessorInfo.FindAsync(id);
            _context.ProfessorInfo.Remove(professorInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorInfoExists(int id)
        {
            return _context.ProfessorInfo.Any(e => e.ProfessorInfoId == id);
        }
    }
}
