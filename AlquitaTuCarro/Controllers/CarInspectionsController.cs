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
    public class CarInspectionsController : ControllerBase
    {
        private readonly AlquitaTuCarroContext _context;

        public CarInspectionsController(AlquitaTuCarroContext context)
        {
            _context = context;
        }

        // GET: api/CarInspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInspection>>> GetCarInspection()
        {
          if (_context.CarInspection == null)
          {
              return NotFound();
          }
            return await _context.CarInspection.ToListAsync();
        }

        // GET: api/CarInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInspection>> GetCarInspection(int id)
        {
          if (_context.CarInspection == null)
          {
              return NotFound();
          }
            var carInspection = await _context.CarInspection.FindAsync(id);

            if (carInspection == null)
            {
                return NotFound();
            }

            return carInspection;
        }

        // PUT: api/CarInspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInspection(int id, CarInspection carInspection)
        {
            if (id != carInspection.Id)
            {
                return BadRequest();
            }

            _context.Entry(carInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInspectionExists(id))
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

        // POST: api/CarInspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarInspection>> PostCarInspection(CarInspection carInspection)
        {
          if (_context.CarInspection == null)
          {
              return Problem("Entity set 'AlquitaTuCarroContext.CarInspection'  is null.");
          }
            _context.CarInspection.Add(carInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarInspection", new { id = carInspection.Id }, carInspection);
        }

        // DELETE: api/CarInspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInspection(int id)
        {
            if (_context.CarInspection == null)
            {
                return NotFound();
            }
            var carInspection = await _context.CarInspection.FindAsync(id);
            if (carInspection == null)
            {
                return NotFound();
            }

            _context.CarInspection.Remove(carInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarInspectionExists(int id)
        {
            return (_context.CarInspection?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
