using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SKC_MVC.Data;
using SKC_MVC.Models;

namespace SKC_MVC.Controllers
{
    public class ClSeSusController : Controller
    {
        private readonly GradDBContext _context;

        public ClSeSusController(GradDBContext context)
        {
            _context = context;
        }

        // GET: ClSeSus
        public async Task<IActionResult> Index()
        {
            var gradDBContext = _context.ClSeSus.Include(c => c.Class);
            return View(await gradDBContext.ToListAsync());
        }

        // GET: ClSeSus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClSeSus == null)
            {
                return NotFound();
            }

            var clSeSu = await _context.ClSeSus
                .Include(c => c.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clSeSu == null)
            {
                return NotFound();
            }

            return View(clSeSu);
        }

        // GET: ClSeSus/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
            return View();
        }

        // POST: ClSeSus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Flag,NumOfClassPerWeek,ClassId")] ClSeSu clSeSu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clSeSu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", clSeSu.ClassId);
            return View(clSeSu);
        }

        // GET: ClSeSus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClSeSus == null)
            {
                return NotFound();
            }

            var clSeSu = await _context.ClSeSus.FindAsync(id);
            if (clSeSu == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", clSeSu.ClassId);
            return View(clSeSu);
        }

        // POST: ClSeSus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Flag,NumOfClassPerWeek,ClassId")] ClSeSu clSeSu)
        {
            if (id != clSeSu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clSeSu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClSeSuExists(clSeSu.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", clSeSu.ClassId);
            return View(clSeSu);
        }

        // GET: ClSeSus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClSeSus == null)
            {
                return NotFound();
            }

            var clSeSu = await _context.ClSeSus
                .Include(c => c.Class)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clSeSu == null)
            {
                return NotFound();
            }

            return View(clSeSu);
        }

        // POST: ClSeSus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClSeSus == null)
            {
                return Problem("Entity set 'GradDBContext.ClSeSus'  is null.");
            }
            var clSeSu = await _context.ClSeSus.FindAsync(id);
            if (clSeSu != null)
            {
                _context.ClSeSus.Remove(clSeSu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClSeSuExists(int id)
        {
            return (_context.ClSeSus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
