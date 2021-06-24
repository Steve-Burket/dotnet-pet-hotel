using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pet_hotel
{
    public class Transaction
    {
        public int id { get; set; }

        //transaction date/time
        [Required]

        public Nullable<DateTime> transaction {get; set;}

        // transaction name
        [Required]
        public string name { get; set; }

        //need way to reference any and all transactions

        // TODO: Add a lookup for all pets that this PetOwner made (lookup in the Pet table)
        // EF knows that Pet has a foreign key to this table! So this "just works" as long
        // as we remember to use .Include in the query to populate it automatically
        // [JsonIgnore] // dont include this field in the JSON API because it may cause infinite loop
        // public List<Pet> pets { get; set; }

    
    }
}

