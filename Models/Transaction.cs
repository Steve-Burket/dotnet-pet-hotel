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

        public DateTime transaction {get; set;}

        // transaction name
        [Required]
        public string description { get; set; }
    
    }
}

