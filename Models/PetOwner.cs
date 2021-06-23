using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner
    {
        public int id { get; set; }

        // name
        [Required]
        public string name { get; set; }
        
        // email validated format name@email.com
        [Required]
        public string emailAddress { get; set; } 

        // pet count 
        [NotMapped]
        public int petCount { get; set; }
    }
}

// public int breadCount
// {
//     get
//     {
//         // if breads is not populated, assume 0
//         if (this.breads == null) return 0;
//         return this.breads.Count;
//     }