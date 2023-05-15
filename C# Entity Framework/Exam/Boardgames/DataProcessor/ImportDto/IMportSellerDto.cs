using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class IMportSellerDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        [JsonProperty("Address")]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"www\.[A-z0-9\-]+\.com")]
        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; } = null!;
    }
}
