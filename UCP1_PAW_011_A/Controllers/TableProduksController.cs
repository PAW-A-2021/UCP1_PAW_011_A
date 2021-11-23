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
    public class TableProduksController : Controller
    {
        private readonly TokoSebelahContext _context;

        public TableProduksController(TokoSebelahContext context)
        {
            _context = context;
        }

        // GET: TableProduks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableProduks.ToListAsync());
        }

        // GET: TableProduks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableProduk = await _context.TableProduks
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (tableProduk == null)
            {
                return NotFound();
            }

            return View(tableProduk);
        }

        // GET: TableProduks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableProduks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduk,NamaProduk,QuantityProduk")] TableProduk tableProduk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableProduk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableProduk);
        }

        // GET: TableProduks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableProduk = await _context.TableProduks.FindAsync(id);
            if (tableProduk == null)
            {
                return NotFound();
            }
            return View(tableProduk);
        }

        // POST: TableProduks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduk,NamaProduk,QuantityProduk")] TableProduk tableProduk)
        {
            if (id != tableProduk.IdProduk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableProduk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableProdukExists(tableProduk.IdProduk))
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
            return View(tableProduk);
        }

        // GET: TableProduks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableProduk = await _context.TableProduks
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (tableProduk == null)
            {
                return NotFound();
            }

            return View(tableProduk);
        }

        // POST: TableProduks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableProduk = await _context.TableProduks.FindAsync(id);
            _context.TableProduks.Remove(tableProduk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableProdukExists(int id)
        {
            return _context.TableProduks.Any(e => e.IdProduk == id);
        }
    }
}
