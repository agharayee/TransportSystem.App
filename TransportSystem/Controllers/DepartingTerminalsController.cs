using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportSystem.Data.DbModels;
using TransportSystem.Data.Dbcontexts;

namespace TransportSystem.Controllers
{
    public class DepartingTerminalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartingTerminalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartingTerminals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartingTerminal.Include(d => d.Terminal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DepartingTerminals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departingTerminal = await _context.DepartingTerminal
                .Include(d => d.Terminal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departingTerminal == null)
            {
                return NotFound();
            }

            return View(departingTerminal);
        }

        // GET: DepartingTerminals/Create
        public IActionResult Create()
        {
            ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "TerminalName");
            return View();
        }

        // POST: DepartingTerminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartingTerminalName,TerminalId")] DepartingTerminal departingTerminal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departingTerminal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id", departingTerminal.TerminalId);
            return View(departingTerminal);
        }

        // GET: DepartingTerminals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departingTerminal = await _context.DepartingTerminal.FindAsync(id);
            if (departingTerminal == null)
            {
                return NotFound();
            }
            ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id", departingTerminal.TerminalId);
            return View(departingTerminal);
        }

        // POST: DepartingTerminals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartingTerminalName,TerminalId")] DepartingTerminal departingTerminal)
        {
            if (id != departingTerminal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departingTerminal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartingTerminalExists(departingTerminal.Id))
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
            ViewData["TerminalId"] = new SelectList(_context.Terminals, "Id", "Id", departingTerminal.TerminalId);
            return View(departingTerminal);
        }

        // GET: DepartingTerminals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departingTerminal = await _context.DepartingTerminal
                .Include(d => d.Terminal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departingTerminal == null)
            {
                return NotFound();
            }

            return View(departingTerminal);
        }

        // POST: DepartingTerminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departingTerminal = await _context.DepartingTerminal.FindAsync(id);
            _context.DepartingTerminal.Remove(departingTerminal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartingTerminalExists(int id)
        {
            return _context.DepartingTerminal.Any(e => e.Id == id);
        }
    }
}
