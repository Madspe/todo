using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoDemo.Data;
using TodoDemo.Models;

namespace TodoDemo.Controllers
{
    public class TodoTypeController : Controller
    {
        private readonly TodoContext _context;

        public TodoTypeController(TodoContext context)
        {
            _context = context;
        }

        // GET: TodoType
        public async Task<IActionResult> Index()
        {
              return View(await _context.TodoType.ToListAsync());
        }

        // GET: TodoType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TodoType == null)
            {
                return NotFound();
            }

            var todoType = await _context.TodoType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoType == null)
            {
                return NotFound();
            }

            return View(todoType);
        }

        // GET: TodoType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UteInne")] TodoType todoType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoType);
        }

        // GET: TodoType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TodoType == null)
            {
                return NotFound();
            }

            var todoType = await _context.TodoType.FindAsync(id);
            if (todoType == null)
            {
                return NotFound();
            }
            return View(todoType);
        }

        // POST: TodoType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UteInne")] TodoType todoType)
        {
            if (id != todoType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoTypeExists(todoType.Id))
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
            return View(todoType);
        }

        // GET: TodoType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TodoType == null)
            {
                return NotFound();
            }

            var todoType = await _context.TodoType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoType == null)
            {
                return NotFound();
            }

            return View(todoType);
        }

        // POST: TodoType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TodoType == null)
            {
                return Problem("Entity set 'TodoContext.TodoType'  is null.");
            }
            var todoType = await _context.TodoType.FindAsync(id);
            if (todoType != null)
            {
                _context.TodoType.Remove(todoType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoTypeExists(int id)
        {
          return _context.TodoType.Any(e => e.Id == id);
        }
    }
}
