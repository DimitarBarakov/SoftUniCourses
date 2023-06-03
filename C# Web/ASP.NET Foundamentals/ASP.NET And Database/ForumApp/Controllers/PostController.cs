using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _context;

        public PostController(ForumAppDbContext forumAppDbContext)
        {
            _context = forumAppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> All()
        {
            var posts = await _context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();
            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel postToAdd)
        {
            var post = new Post()
            {
                Title = postToAdd.Title,
                Content = postToAdd.Content
            };

            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            var formModel = new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel postToEdit)
        {
            var post = await _context.Posts.FindAsync(id);
            post.Content = postToEdit.Content;
            post.Title = postToEdit.Title;

            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
             _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
