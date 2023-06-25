using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Type = Homies.Data.Models.Type;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;


        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public List<TypesViewModel> Types { get; set; } = new List<TypesViewModel>();
    }
}
