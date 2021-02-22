using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingList.Models;
using Readinglist.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ReadingList.Controllers
{
    [Authorize]
    public class ReadingListController : Controller
    {
        private readonly ReadingListDB _context;
        private static HttpClient _client = new HttpClient();
        private IConfiguration _config;

        public ReadingListController(ReadingListDB context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }





        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("externalRestServices:recommendationService"));
            String resultAsString = response.Content.ReadAsStringAsync().Result;
            IEnumerable<Recommendation> recommendation = JsonConvert.DeserializeObject<IEnumerable<Recommendation>>(resultAsString);
            ViewBag.Recommendations = recommendation;
            return View(await _context.Books.ToListAsync());
        }

        // GET: ReadingList/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: ReadingList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReadingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Isbn,Title,Author,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Reader = "Ravi";
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: ReadingList/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: ReadingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Reader,Isbn,Title,Author,Description")] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
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
            return View(book);
        }

        // GET: ReadingList/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .SingleOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
