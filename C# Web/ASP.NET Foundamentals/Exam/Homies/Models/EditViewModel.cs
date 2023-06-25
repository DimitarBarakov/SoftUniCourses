using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EditViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;


        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        [Required]
        public List<TypesViewModel> Types { get; set; } = new List<TypesViewModel>();
    }
}
