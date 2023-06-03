using ForumApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.ViewModels.Post
{
    public class PostFormModel
    {
        [Required]
        [StringLength(PostConstraints.TitleMaxLength, MinimumLength = PostConstraints.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(PostConstraints.ContentMaxLength, MinimumLength = PostConstraints.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
