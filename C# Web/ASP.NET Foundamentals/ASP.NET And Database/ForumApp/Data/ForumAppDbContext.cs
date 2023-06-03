using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        public Post ThirdPost { get; set; }

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPost();
            modelBuilder
                .Entity<Post>()
                .HasData(FirstPost,SecondPost,ThirdPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPost()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "This is my first project's content"
            };
            SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second project's content"
            };
            ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "This is my third project's content"
            };
        }
    }
}
