﻿using System.Collections.Generic;
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
    public class BorrowingsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BorrowingsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Borrowing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrowing>>> GetBorrowing()
        {
            return await _context.Borrowing
                .Include(b => b.Borrower)
                .Include(b => b.Client)
                .ToListAsync();
        }

        // GET: api/Borrowing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrowing>> GetBorrowing(int id)
        {
            var borrowing = await _context.Borrowing.FindAsync(id);
           
            if (borrowing == null)
            {
                return NotFound();
            }

            _context.Entry(borrowing).Reference(b => b.Borrower).Load();
            _context.Entry(borrowing).Reference(b => b.Client).Load();
            
            return borrowing;
        }

        [HttpGet("ByEmail/{email}/{amount}")]
        // [ActionName("GetBorrowingsByEmailWithAmount")]
        public async Task<ActionResult<List<Borrowing>>> GetBorrowing(string email, int amount)
        {
            var borrowing = await _context.Borrowing
                .Where(x => x.Borrower.Email == email || x.Client.Email == email)
                .OrderBy(x=>x.ReturnDate)
                .Take(amount)
                .ToListAsync();
            
            if (borrowing == null)
            {
                return NotFound();
            }

            return borrowing;
        }


        [HttpGet("ByEmail/{email}")]
        // [ActionName("GetBorrowingsByEmail")]
        public async Task<ActionResult<List<Borrowing>>> GetAllBorrowing(string email)
        {
            var borrowing = await _context.Borrowing
                .Where(x => x.Borrower.Email == email|| x.Client.Email == email)
                .ToListAsync();

            if (borrowing == null)
            {
                return NotFound();
            }

            return borrowing;
        }

        // PUT: api/Borrowing/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowing(int id, Borrowing borrowing)
        {
            if (id != borrowing.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(id))
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

        // POST: api/Borrowing
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Borrowing>> PostBorrowing(Borrowing borrowing)
        {
            _context.Borrowing.Add(borrowing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowing", new { id = borrowing.Id }, borrowing);
        }

        // DELETE: api/Borrowing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowing(int id)
        {
            var borrowing = await _context.Borrowing.FindAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }

            _context.Borrowing.Remove(borrowing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.Id == id);
        }
    }
}
