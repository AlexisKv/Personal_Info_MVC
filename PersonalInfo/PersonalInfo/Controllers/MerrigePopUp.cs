using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Data;
using PersonalInfo.Models;

namespace PersonalInfo.Controllers
{
    [Route("person/[controller]")]
    [ApiController]
    public class MerrigePopUp : ControllerBase
    {
        private readonly PersonalInfoContext _context;

        public MerrigePopUp(PersonalInfoContext context)
        {
            _context = context;
        }

        // GET: person/MerrigePopUp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            return await _context.Person.ToListAsync();
        }

        // GET: person/MerrigePopUp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: person/MerrigePopUp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutPerson(int id, string merrigeName)
        {
            
            var person = await _context.Person.FindAsync(id);
            person.Relationship = merrigeName;
                
            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: person/MerrigePopUp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Person>> PostPerson(Person person)
        // {
        //   if (_context.Person == null)
        //   {
        //       return Problem("Entity set 'PersonalInfoContext.Person'  is null.");
        //   }
        //     _context.Person.Add(person);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        // }

        // DELETE: person/MerrigePopUp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
