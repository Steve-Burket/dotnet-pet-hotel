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
        public int petCount
        {
            get
            {
                // if pets is not populated, assume 0
                if (this.pets == null) return 0;
                return this.pets.Count;
            }
        }

        // TODO: Add a lookup for all pets that this PetOwner made (lookup in the Pet table)
        // EF knows that Pet has a foreign key to this table! So this "just works" as long
        // as we remember to use .Include in the query to populate it automatically
        [JsonIgnore] // dont include this field in the JSON API because it may cause infinite loop
        public List<Pet> pets { get; set; }

    
    }
}

