using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            Boardgames = new HashSet<Boardgame>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(7)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(7)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Boardgame> Boardgames { get; set; } = null!;
    }
}

//⦁	Id – integer, Primary Key
//⦁	FirstName – text with length [2, 7] (required)
//⦁	LastName – text with length [2, 7] (required)
//⦁	Boardgames – collection of type Boardgame

