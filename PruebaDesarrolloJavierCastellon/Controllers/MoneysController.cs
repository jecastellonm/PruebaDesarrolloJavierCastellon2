using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesarrolloJavierCastellon.Models;

namespace PruebaDesarrolloJavierCastellon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneysController : ControllerBase
    {
        private readonly TestDBContext _context;

        public MoneysController(TestDBContext context)
        {
            _context = context;
        }

        // GET: api/Moneys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JecmMoney>>> GetJecmMoneys()
        {
            return await _context.JecmMoneys.ToListAsync();
        }

        // GET: api/Moneys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JecmMoney>> GetJecmMoney(int id)
        {
            var jecmMoney = await _context.JecmMoneys.FindAsync(id);

            if (jecmMoney == null)
            {
                return NotFound();
            }

            return jecmMoney;
        }

        // PUT: api/Moneys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJecmMoney(int id, JecmMoney jecmMoney)
        {
            if (id != jecmMoney.IdMoney)
            {
                return BadRequest();
            }

            _context.Entry(jecmMoney).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JecmMoneyExists(id))
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

        // POST: api/Moneys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JecmMoney>> PostJecmMoney(JecmMoney jecmMoney)
        {
            _context.JecmMoneys.Add(jecmMoney);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJecmMoney", new { id = jecmMoney.IdMoney }, jecmMoney);
        }

        // DELETE: api/Moneys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJecmMoney(int id)
        {
            var jecmMoney = await _context.JecmMoneys.FindAsync(id);
            if (jecmMoney == null)
            {
                return NotFound();
            }

            _context.JecmMoneys.Remove(jecmMoney);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JecmMoneyExists(int id)
        {
            return _context.JecmMoneys.Any(e => e.IdMoney == id);
        }
    }
}
