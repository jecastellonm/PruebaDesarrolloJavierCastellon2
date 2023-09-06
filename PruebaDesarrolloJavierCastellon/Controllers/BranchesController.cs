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
 public class BranchesController : ControllerBase
 {
  private readonly TestDBContext _context;

  public BranchesController(TestDBContext context)
  {
   _context = context;
  }

  // GET: api/Branches
  [HttpGet]
  public async Task<ActionResult<IEnumerable<JecmBranch>>> GetJecmBranches()
  {
   return await _context.JecmBranches
     //.Where(m=>m.Money.IdMoney == m.MoneyId)
     //.Include(m => m.Money)
     .ToListAsync();
  }

  // GET: api/Branches/5
  [HttpGet("{id}")]
  public async Task<ActionResult<JecmBranch>> GetJecmBranch(int id)
  {
   var jecmBranch = await _context.JecmBranches.FindAsync(id);

   if (jecmBranch == null)
   {
    return NotFound();
   }

   return jecmBranch;
  }

  // PUT: api/Branches/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutJecmBranch(int id, JecmBranch jecmBranch)
  {
   if (id != jecmBranch.IdBranch)
   {
    return BadRequest();
   }

   _context.Entry(jecmBranch).State = EntityState.Modified;

   try
   {
    await _context.SaveChangesAsync();
   }
   catch (DbUpdateConcurrencyException)
   {
    if (!JecmBranchExists(id))
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

  // POST: api/Branches
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<JecmBranch>> PostJecmBranch(JecmBranch jecmBranch)
  {
   _context.JecmBranches.Add(jecmBranch);
   await _context.SaveChangesAsync();

   return CreatedAtAction("GetJecmBranch", new { id = jecmBranch.IdBranch }, jecmBranch);
  }

  // DELETE: api/Branches/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteJecmBranch(int id)
  {
   var jecmBranch = await _context.JecmBranches.FindAsync(id);
   if (jecmBranch == null)
   {
    return NotFound();
   }

   _context.JecmBranches.Remove(jecmBranch);
   await _context.SaveChangesAsync();

   return NoContent();
  }

  private bool JecmBranchExists(int id)
  {
   return _context.JecmBranches.Any(e => e.IdBranch == id);
  }
 }
}
