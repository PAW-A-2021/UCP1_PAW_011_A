using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_011_A.Models;

namespace UCP1_PAW_011_A.Controllers
{
    public class TableAdminsController : Controller
    {
        private readonly TokoSebelahContext _context;

        public TableAdminsController(TokoSebelahContext context)
        {
            _context = context;
        }

        // GET: TableAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableAdmins.ToListAsync());
        }

        // GET: TableAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableAdmin = await _context.TableAdmins
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (tableAdmin == null)
            {
                return NotFound();
            }

            return View(tableAdmin);
        }

        // GET: TableAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,NamaAdmin")] TableAdmin tableAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableAdmin);
        }

        // GET: TableAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableAdmin = await _context.TableAdmins.FindAsync(id);
            if (tableAdmin == null)
            {
                return NotFound();
            }
            return View(tableAdmin);
        }

        // POST: TableAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,NamaAdmin")] TableAdmin tableAdmin)
        {
            if (id != tableAdmin.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableAdminExists(tableAdmin.IdAdmin))
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
            return View(tableAdmin);
        }

        // GET: TableAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableAdmin = await _context.TableAdmins
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (tableAdmin == null)
            {
                return NotFound();
            }

            return View(tableAdmin);
        }

        // POST: TableAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableAdmin = await _context.TableAdmins.FindAsync(id);
            _context.TableAdmins.Remove(tableAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableAdminExists(int id)
        {
            return _context.TableAdmins.Any(e => e.IdAdmin == id);
        }
    }
}
