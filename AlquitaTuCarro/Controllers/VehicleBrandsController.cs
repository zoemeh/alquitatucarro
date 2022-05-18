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
    public class VehicleBrandsController : ControllerBase
    {
        private readonly AlquitaTuCarroContext _context;

        public VehicleBrandsController(AlquitaTuCarroContext context)
        {
            _context = context;
        }

        // GET: api/VehicleBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleBrand>>> GetVehicleBrand()
        {
          if (_context.VehicleBrand == null)
          {
              return NotFound();
          }
            return await _context.VehicleBrand.ToListAsync();
        }

        // GET: api/VehicleBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleBrand>> GetVehicleBrand(int id)
        {
          if (_context.VehicleBrand == null)
          {
              return NotFound();
          }
            var vehicleBrand = await _context.VehicleBrand.FindAsync(id);

            if (vehicleBrand == null)
            {
                return NotFound();
            }

            return vehicleBrand;
        }

        // PUT: api/VehicleBrands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleBrand(int id, VehicleBrand vehicleBrand)
        {
            if (id != vehicleBrand.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleBrandExists(id))
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

        // POST: api/VehicleBrands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleBrand>> PostVehicleBrand(VehicleBrand vehicleBrand)
        {
          if (_context.VehicleBrand == null)
          {
              return Problem("Entity set 'AlquitaTuCarroContext.VehicleBrand'  is null.");
          }
            _context.VehicleBrand.Add(vehicleBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleBrand", new { id = vehicleBrand.Id }, vehicleBrand);
        }

        // DELETE: api/VehicleBrands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleBrand(int id)
        {
            if (_context.VehicleBrand == null)
            {
                return NotFound();
            }
            var vehicleBrand = await _context.VehicleBrand.FindAsync(id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }

            _context.VehicleBrand.Remove(vehicleBrand);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleBrandExists(int id)
        {
            return (_context.VehicleBrand?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
