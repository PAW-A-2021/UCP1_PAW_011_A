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
    public class TablePembelisController : Controller
    {
        private readonly TokoSebelahContext _context;

        public TablePembelisController(TokoSebelahContext context)
        {
            _context = context;
        }

        // GET: TablePembelis
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablePembelis.ToListAsync());
        }

        // GET: TablePembelis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePembeli = await _context.TablePembelis
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (tablePembeli == null)
            {
                return NotFound();
            }

            return View(tablePembeli);
        }

        // GET: TablePembelis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TablePembelis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembeli,NamaPembeli,Alamat,NoHp")] TablePembeli tablePembeli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablePembeli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablePembeli);
        }

        // GET: TablePembelis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePembeli = await _context.TablePembelis.FindAsync(id);
            if (tablePembeli == null)
            {
                return NotFound();
            }
            return View(tablePembeli);
        }

        // POST: TablePembelis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembeli,NamaPembeli,Alamat,NoHp")] TablePembeli tablePembeli)
        {
            if (id != tablePembeli.IdPembeli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablePembeli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablePembeliExists(tablePembeli.IdPembeli))
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
            return View(tablePembeli);
        }

        // GET: TablePembelis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablePembeli = await _context.TablePembelis
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (tablePembeli == null)
            {
                return NotFound();
            }

            return View(tablePembeli);
        }

        // POST: TablePembelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablePembeli = await _context.TablePembelis.FindAsync(id);
            _context.TablePembelis.Remove(tablePembeli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablePembeliExists(int id)
        {
            return _context.TablePembelis.Any(e => e.IdPembeli == id);
        }
    }
}
