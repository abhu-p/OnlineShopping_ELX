using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShopping_ELX.Data;
using OnlineShopping_ELX.Models;

namespace OnlineShopping_ELX.Controllers
{
    public class BuyProductController : Controller
    {
        private readonly OnlineShopping_ELXContext _context;

        public BuyProductController(OnlineShopping_ELXContext context)
        {
            _context = context;
        }

        // GET: BuyProduct
        public async Task<IActionResult> Index()
        {
              return _context.BuyProduct != null ? 
                          View(await _context.BuyProduct.ToListAsync()) :
                          Problem("Entity set 'OnlineShopping_ELXContext.BuyProduct'  is null.");
        }

        // GET: BuyProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyProduct == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyProduct == null)
            {
                return NotFound();
            }

            return View(buyProduct);
        }

        // GET: BuyProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuyProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,Quantity,Status")] BuyProduct buyProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyProduct);
        }

        // GET: BuyProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyProduct == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProduct.FindAsync(id);
            if (buyProduct == null)
            {
                return NotFound();
            }
            return View(buyProduct);
        }

        // POST: BuyProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,Quantity,Status")] BuyProduct buyProduct)
        {
            if (id != buyProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyProductExists(buyProduct.Id))
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
            return View(buyProduct);
        }

        // GET: BuyProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyProduct == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyProduct == null)
            {
                return NotFound();
            }

            return View(buyProduct);
        }

        // POST: BuyProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyProduct == null)
            {
                return Problem("Entity set 'OnlineShopping_ELXContext.BuyProduct'  is null.");
            }
            var buyProduct = await _context.BuyProduct.FindAsync(id);
            if (buyProduct != null)
            {
                _context.BuyProduct.Remove(buyProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyProductExists(int id)
        {
          return (_context.BuyProduct?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
