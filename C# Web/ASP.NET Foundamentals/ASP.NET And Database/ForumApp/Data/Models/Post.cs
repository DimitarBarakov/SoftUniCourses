using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Models
{
    public class Post
    {
        [Required]
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(PostConstraints.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PostConstraints.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
