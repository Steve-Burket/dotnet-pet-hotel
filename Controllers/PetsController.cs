using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<Pet> GetPets() {
        //     return new List<Pet>();
        // }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    [HttpGet] // GET /api/pets/
        public IEnumerable<Pet> GetPets() {
            return _context.Pets.Include(p => p.petOwner);

        }


       [HttpGet("{id}")] 
        public IActionResult GetById(int id) {
            Pet pet = _context.Pets.Find(id);
            // Return 404 if the pet  wasn't found by that id
            if (pet == null) {
                return NotFound(); // returns 404 not found error
            }
            return Ok(pet); // returns 200 OK w/ the pet
        }

        // CREATE new pet
        [HttpPost] // POST /api/pets
        public IActionResult CreatePet([FromBody] Pet pet)
        {
            PetOwner owner = _context.PetOwners.SingleOrDefault(o => o.id == pet.petOwnerid);
            _context.Add(pet);
            _context.SaveChanges();
            // return Created("", pet); // this works but isnt great
            return CreatedAtAction(nameof(GetById), pet, pet);
        }

    // DELETE pet  by id
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {
            Pet pet = _context.Pets.Find(id);
            if (pet == null) {
                return NotFound(); // returns 404 not found error
            }
            _context.Remove(pet);
            _context.SaveChanges();
            return NoContent(); // returns 204 No Content
        }

        
        // PUT to checkIn a pet
        [HttpPut("{id}/checkin")] // PUT /api/Pet/10/checkin
        public IActionResult PetCheckIn(int id) {
            // Look up the pet that we want to checkIn by id
            Pet pet = _context.Pets.Find(id);
            if (pet == null) return NotFound();

            pet.checkin();
            // pet++; // this would work too because inventory is public
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }

        // PUT to checkOut a pet
        [HttpPut("{id}/checkout")] // PUT /api/Pet/10/checkout
        public IActionResult PetCheckOut(int id) {
            // Look up the pet 
            Pet pet = _context.Pets.Find(id);
            if (pet == null) return NotFound();

            pet.checkout();
            // pet.inventory++; // this would work too because inventory is public
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet);
        }
        
 [HttpPut("{id}")] 
        public IActionResult EditPet(int id, [FromBody] Pet pet) {
            // Return 404 if the pet  wasn't found by that id
            if (pet == null) {
                return NotFound(); // returns 404 not found error
            }
            _context.Update(pet);
            _context.SaveChanges();
            return Ok(pet); // returns 200 OK w/ the pet
        }
    }
}


    