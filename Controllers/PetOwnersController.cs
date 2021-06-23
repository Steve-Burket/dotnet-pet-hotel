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
        public IEnumerable<PetOwner> GetPetOwners() {
            return _context.PetOwners;
               
        }

        // //GET owners by ID
        // [HttpGet("{id}")]
        // public IActionResult GetById(int id)
        // {
        //     PetOwner owner = _context.PetOwners;
        //     if (owner == null)
        //     {
        //         return NotFound();

        //     }
        //     return Ok(owner);
        // }

    // [HttpPost]
    // public IActionResult CreatePetOwner([FromBody] PetOwner owner) {
    //     _context.Add(owner);
    //     _context.SaveChanges();
    //     return CreatedAtAction(nameof(GetById), owner, owner);
    // }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets()
        {
            return new List<PetOwner>();
        }
    }
}
