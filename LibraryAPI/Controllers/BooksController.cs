using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context
                .Book
                .Include(b => b.Owner)
                .ToListAsync();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book
                .FindAsync(id);

            _context.Entry(book).Reference(b => b.Owner).Load();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("GetBooksByUserId/{Userid}")]
        [ActionName("GetBooksByUserId")]
        public async Task<ActionResult<List<Book>>> GetBooksByUserId(string Userid)
        {
            var book = await _context.Book.Where(x => x.Owner.Id == Userid).ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("GetBooksByUserIdWithLimits/{Userid}/{limit}")]
        [ActionName("GetBooksByUserIdWithLimits")]
        public async Task<ActionResult<List<Book>>> GetBooksByUserIdWithLimits(string Userid, int limit)
        {
            var book = await _context.Book.Where(x => x.Owner.Id == Userid).OrderBy(x=>x.Title).Take(limit).ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(IEnumerable<Book> books)
        {
            foreach (Book b in books)
            {
                _context.Book.Add(b);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", books);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
