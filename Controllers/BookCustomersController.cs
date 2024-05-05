using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryLabb4.Data;
using LibraryLabb4.Models;

namespace LibraryLabb4.Controllers
{
    public class BookCustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCustomers
        public async Task<IActionResult> Index(string name)

            
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                var applicationDbContext = _context.BookCustomers.Include(b => b.Book).Include(b => b.Customer);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.BookCustomers.Include(b => b.Book).Where(x => x.Customer.FirstName.Contains(name)).
                Include(x => x.Customer);
                return View(await applicationDbContext.ToListAsync());
            }

            




        }

        // GET: BookCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookCustomerId == id);
            if (bookCustomer == null)
            {
                return NotFound();
            }

            return View(bookCustomer);
        }

        // GET: BookCustomers/Create
        public IActionResult Create()
        {
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "Author");
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            return View();
        }

        // POST: BookCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCustomerId,FkBookId,FkCustomerId,BorrowDate,ReturnDate")] BookCustomer bookCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "Author", bookCustomer.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookCustomer.FkCustomerId);
            return View(bookCustomer);
        }

        // GET: BookCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers.FindAsync(id);
            if (bookCustomer == null)
            {
                return NotFound();
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "Author", bookCustomer.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookCustomer.FkCustomerId);
            return View(bookCustomer);
        }

        // POST: BookCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCustomerId,FkBookId,FkCustomerId,BorrowDate,ReturnDate")] BookCustomer bookCustomer)
        {
            if (id != bookCustomer.BookCustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCustomerExists(bookCustomer.BookCustomerId))
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
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "Author", bookCustomer.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookCustomer.FkCustomerId);
            return View(bookCustomer);
        }

        // GET: BookCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookCustomerId == id);
            if (bookCustomer == null)
            {
                return NotFound();
            }

            return View(bookCustomer);
        }

        // POST: BookCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCustomer = await _context.BookCustomers.FindAsync(id);
            if (bookCustomer != null)
            {
                _context.BookCustomers.Remove(bookCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCustomerExists(int id)
        {
            return _context.BookCustomers.Any(e => e.BookCustomerId == id);
        }
    }
}
