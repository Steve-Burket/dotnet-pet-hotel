using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        //GET api/petowners all pet owners

        [HttpGet] // GET /api/petOwners/
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwners
            .Include(p => p.pets)
            .OrderBy(p => p.name);

        }


        // GET owners by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PetOwner owner = _context.PetOwners
                    .Include(p => p.pets)
                    .SingleOrDefault(p => p.id == id);

            if (owner == null)
            {
                return NotFound();

            }
            return Ok(owner);
        }

            // DELETE owner  by id
        [HttpDelete("{id}")] // GET /api/petowner/1
        public IActionResult DeleteById(int id) {

            PetOwner owner = _context.PetOwners.Find(id);
            // Return 404 if the owner wasn't found by that id
            if (owner == null) {
                return NotFound(); // returns 404 not found error
            }
            Transaction t = new Transaction();
            t.description = $"{owner.name} was deleted";
            t.transaction = DateTime.UtcNow;
            _context.Add(t);
            _context.PetOwners.Remove(owner);
            _context.SaveChanges();
            return NoContent(); // returns 204 No Content
        }

        // /api/petowners
        [HttpPost]
        public IActionResult CreatePetOwner([FromBody] PetOwner owner) {
            Transaction t = new Transaction();
            t.description = $"{owner.name} was created as pet owner";
            t.transaction = DateTime.UtcNow;
            _context.Add(owner);
            _context.Add(t);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), owner, owner);
        }

        

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, [FromBody] PetOwner owner) {
            // { id: 1, name: 'new name' }
            // Make sure this is a real owner
            if (!_context.PetOwners.Any(b => b.id == id)) return NotFound();

            // Find the owner and mark it as modified
            Transaction t = new Transaction();
            t.description = $"{owner.name} was updated";
            t.transaction = DateTime.UtcNow;
            _context.Add(t);

            _context.PetOwners.Update(owner);
            _context.SaveChanges();
            return Ok(owner);

        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets()
        // {
        //     return new List<PetOwner>();
        // }
    }
}
