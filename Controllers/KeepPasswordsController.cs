using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeepPassDBStore.Data;
using KeepPassDBStore.Models;

namespace KeepPassDBStore.Controllers
{
    public class KeepPasswordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeepPasswordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET Request for list of all passwords records
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyPasswords.ToListAsync());
        }

        // GET request for getting detials of specific password
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keepPassword = await _context.MyPasswords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keepPassword == null)
            {
                return NotFound();
            }

            return View(keepPassword);
        }

        // GET request to create and return view
        public IActionResult Create()
        {
            return View();
        }

        // POST Request to create and save changes
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,URL,Notes,Modified")] KeepPassword keepPassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keepPassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keepPassword);
        }

        // GET request to edit record by id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keepPassword = await _context.MyPasswords.FindAsync(id);
            if (keepPassword == null)
            {
                return NotFound();
            }
            return View(keepPassword);
        }

        // POST request ot edit record by id
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,URL,Notes,Modified")] KeepPassword keepPassword)
        {
            if (id != keepPassword.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keepPassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeepPasswordExists(keepPassword.Id))
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
            return View(keepPassword);
        }

        // GET req to delete password record by id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keepPassword = await _context.MyPasswords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keepPassword == null)
            {
                return NotFound();
            }

            return View(keepPassword);
        }

        // POST req to delete and confirm by id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keepPassword = await _context.MyPasswords.FindAsync(id);
            _context.MyPasswords.Remove(keepPassword);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // mehtod to check if record exists
        private bool KeepPasswordExists(int id)
        {
            return _context.MyPasswords.Any(e => e.Id == id);
        }
    }
}
