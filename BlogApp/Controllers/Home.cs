#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class Home : Controller
    {
        private readonly ApplicationDbContext _context;

        public Home(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogEntry.ToListAsync());
        }

        // GET: BlogEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            return View(blogEntry);
        }

        // GET: BlogEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ownerId,CreatedDate,content")] BlogEntry blogEntry)
        {
            blogEntry.ownerId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(blogEntry);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Blog created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry.FindAsync(id);
            if (blogEntry == null)
            {
                return NotFound();
            }
            return View(blogEntry);
        }

        // POST: BlogEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ownerId,CreatedDate,content")] BlogEntry blogEntry)
        {
            if (id != blogEntry.Id)
            {
                return NotFound();
            }
            blogEntry.CreatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogEntryExists(blogEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Success"] = "Blog edited successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(blogEntry);
        }

        // GET: BlogEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogEntry = await _context.BlogEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            return View(blogEntry);
        }

        // POST: BlogEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogEntry = await _context.BlogEntry.FindAsync(id);
            _context.BlogEntry.Remove(blogEntry);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Blog deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool BlogEntryExists(int id)
        {
            return _context.BlogEntry.Any(e => e.Id == id);
        }
    }
}
