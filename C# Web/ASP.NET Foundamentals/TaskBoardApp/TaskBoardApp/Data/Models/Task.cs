using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstraints.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board? Board { get; set; } 

        [Required]
        public string OwnerId { get; set; } = null!;

        public IdentityUser Owner { get; set; } = null!;
    }
}
//• Id – a unique integer, Primary Key
//• Title – a string with min length 5 and max length 70 (required)
//• Description – a string with min length 10 and max length 1000 (required)
//• CreatedOn – date and time
//• BoardId – an integer
//• Board – a Board object
//• OwnerId – an integer (required)
//• Owner – an IdentityUser object