using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Homies.Models
{
    public class AllEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Organiser { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}
