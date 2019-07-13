using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using House_Information.Models;

namespace House_Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HouseController : ControllerBase
    {
        private readonly HouseContext _context;

        public HouseController(HouseContext context)
        {
            _context = context;
        }

        // GET: api/House
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            var resp = await _context.Set<House>()
            .Include(h => h.Rooms)
            .ToListAsync();
            return resp;
        }

        // GET: api/House/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(string id)
        {
            var house = await _context.Houses.Include(f => f.Rooms).FirstOrDefaultAsync(f => f.HouseID == id);

            if (house == null)
            {
                return NotFound();
            }

            return house;


                }

        // PUT: api/House/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(string id, House house)
        {
            if (id != house.HouseID)
            {
                return BadRequest();
            }

            _context.Entry(house).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
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

        // POST: api/House
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.HouseID }, house);
        }

        // DELETE: api/House/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteHouse(string id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }

        private bool HouseExists(string id)
        {
            return _context.Houses.Any(e => e.HouseID == id);
        }
    }
}
