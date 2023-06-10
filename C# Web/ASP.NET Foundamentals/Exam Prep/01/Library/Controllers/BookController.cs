using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;
        public BookController(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> All()
        {
            var books = await _context.Books
                .Select(b => new AllBookViewModel
                {
                    Author = b.Author,
                    Title = b.Title,
                    Id = b.Id,
                    Category = b.Category.Name,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                }).ToListAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var book = new BookFormModel();
            book.Categories = await _context.Categories.ToListAsync();

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bookModel);
            }
            var bookToAdd = new Book()
            {
                Author = bookModel.Author,
                Title = bookModel.Title,
                Description = bookModel.Description,
                Rating = bookModel.Rating,
                ImageUrl = bookModel.Url,
                CategoryId = bookModel.CategoryId,
                
            };

            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookToAdd = await _context.Books.FirstAsync(us=>us.Id == id);

            if (_context.UsersBooks.Any(ub=>ub.CollectorId == userId && ub.BookId == bookToAdd.Id))
            {
                return RedirectToAction("All");
            }

            var userbook = new IdentityUserBook()
            {
                CollectorId = userId,
                BookId = bookToAdd.Id
            };

            await _context.UsersBooks.AddAsync(userbook);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookToRemove = await _context.UsersBooks.FirstAsync(us => us.BookId == id);

            _context.UsersBooks.Remove(bookToRemove);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myBooks = await _context.UsersBooks.Where(ub => ub.CollectorId == userId)
                .Select(b => new MyBookModel
                {
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    ImageUrl = b.Book.ImageUrl,
                    Id = b.Book.Id,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();

            return View(myBooks);
        }
    }
}
