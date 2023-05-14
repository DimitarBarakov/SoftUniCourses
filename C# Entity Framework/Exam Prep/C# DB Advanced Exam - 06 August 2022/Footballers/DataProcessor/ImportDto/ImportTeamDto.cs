using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"^[A-Za-z0-9\s\.\-]{3,}$")]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }
        [JsonProperty("Footballers")]

        public ICollection<int> FootballersIds { get; set; } = new List<int>();
    }
}
