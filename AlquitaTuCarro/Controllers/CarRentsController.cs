using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlquitaTuCarro.Data;
using AlquitaTuCarro.Models;

namespace AlquitaTuCarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentsController : ControllerBase
    {
        private readonly AlquitaTuCarroContext _context;

        public CarRentsController(AlquitaTuCarroContext context)
        {
            _context = context;
        }

        // GET: api/CarRents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRent>>> GetCarRent()
        {
          if (_context.CarRent == null)
          {
              return NotFound();
          }
            return await _context.CarRent.ToListAsync();
        }

        // GET: api/CarRents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRent>> GetCarRent(int id)
        {
          if (_context.CarRent == null)
          {
              return NotFound();
          }
            var carRent = await _context.CarRent.FindAsync(id);

            if (carRent == null)
            {
                return NotFound();
            }

            return carRent;
        }

        // PUT: api/CarRents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarRent(int id, CarRent carRent)
        {
            if (id != carRent.Id)
            {
                return BadRequest();
            }

            _context.Entry(carRent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentExists(id))
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

        // POST: api/CarRents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarRent>> PostCarRent(CarRent carRent)
        {
          if (_context.CarRent == null)
          {
              return Problem("Entity set 'AlquitaTuCarroContext.CarRent'  is null.");
          }
            _context.CarRent.Add(carRent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarRent", new { id = carRent.Id }, carRent);
        }

        // DELETE: api/CarRents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarRent(int id)
        {
            if (_context.CarRent == null)
            {
                return NotFound();
            }
            var carRent = await _context.CarRent.FindAsync(id);
            if (carRent == null)
            {
                return NotFound();
            }

            _context.CarRent.Remove(carRent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarRentExists(int id)
        {
            return (_context.CarRent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
