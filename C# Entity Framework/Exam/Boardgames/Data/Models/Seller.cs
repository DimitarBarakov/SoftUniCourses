﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = null!;
    }
}
//⦁	Id – integer, Primary Key
//⦁	Name – text with length [5…20] (required)
//⦁	Address – text with length [2…30] (required)
//⦁	Country – text (required)
//⦁	Website – a string (required). First four characters are "www.", followed by upper and lower letters, digits or '-' and the last three characters are ".com".
//⦁	BoardgamesSellers – collection of type BoardgameSeller

