using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yudin_back.Data;
using Yudin_back.Models;

namespace Yudin_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly Yudin_backContext _context;

        public BorrowingsController(Yudin_backContext context)
        {
            _context = context;
        }

        // GET: api/Borrowings
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Borrowing>>> GetBorrowing()
        {
            return await _context.Borrowing.ToListAsync();
        }

        // GET: api/Borrowings/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Borrowing>> GetBorrowing(int id)
        {
            var borrowing = await _context.Borrowing.FindAsync(id);

            if (borrowing == null)
            {
                return NotFound();
            }

            return borrowing;
        }

        // PUT: api/Borrowings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
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

        // POST: api/Borrowings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Borrowing>> PostBorrowing(Borrowing borrowing)
        {
            _context.Borrowing.Add(borrowing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowing", new { id = borrowing.Id }, borrowing);
        }

        // DELETE: api/Borrowings/5
        [HttpDelete("{id}")]
        [Authorize]
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

       /* [HttpPut("{id}/Return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var borrowing = await _context.Borrowing.FindAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }

            borrowing.MarkAsReturned();

            // Обновляем доступность книги
            var book = await _context.Book.FindAsync(borrowing.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                _context.Entry(book).State = EntityState.Modified;
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
        }*/

        /*[HttpGet("{id}/CalculateFine")]
        public async Task<ActionResult<decimal>> CalculateFine(int id)
        {
            var borrowing = await _context.Borrowing.Include(b => b.Book).Include(b => b.Member).FirstOrDefaultAsync(b => b.Id == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            // Вызов метода из модели
            decimal fine = borrowing.CalculateFine();
            return Ok(fine);
        }*/


    }
}
