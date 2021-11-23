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
    public class TableTransaksisController : Controller
    {
        private readonly TokoSebelahContext _context;

        public TableTransaksisController(TokoSebelahContext context)
        {
            _context = context;
        }

        // GET: TableTransaksis
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableTransaksis.ToListAsync());
        }

        // GET: TableTransaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableTransaksi = await _context.TableTransaksis
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (tableTransaksi == null)
            {
                return NotFound();
            }

            return View(tableTransaksi);
        }

        // GET: TableTransaksis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableTransaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdPembeli,IdProduk,IdAdmin,TotalTransaksi")] TableTransaksi tableTransaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableTransaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableTransaksi);
        }

        // GET: TableTransaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableTransaksi = await _context.TableTransaksis.FindAsync(id);
            if (tableTransaksi == null)
            {
                return NotFound();
            }
            return View(tableTransaksi);
        }

        // POST: TableTransaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,IdPembeli,IdProduk,IdAdmin,TotalTransaksi")] TableTransaksi tableTransaksi)
        {
            if (id != tableTransaksi.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableTransaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableTransaksiExists(tableTransaksi.IdTransaksi))
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
            return View(tableTransaksi);
        }

        // GET: TableTransaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableTransaksi = await _context.TableTransaksis
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (tableTransaksi == null)
            {
                return NotFound();
            }

            return View(tableTransaksi);
        }

        // POST: TableTransaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableTransaksi = await _context.TableTransaksis.FindAsync(id);
            _context.TableTransaksis.Remove(tableTransaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableTransaksiExists(int id)
        {
            return _context.TableTransaksis.Any(e => e.IdTransaksi == id);
        }
    }
}
