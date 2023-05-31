using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Product;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            },
        };
        public IActionResult Index()
        {
            return View();
        }
        [ActionName("My-Products")]
        public IActionResult All()
        {
            return View(_products);
        }
        public IActionResult ById(int id)
        {
            ProductViewModel product = _products.First(p => p.Id == id);
            return View(product);
        }
        public IActionResult AllASJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return Json(_products, options);
        }
        public IActionResult AllASText()
        {
            var text = string.Empty;
            foreach (var item in _products)
            {
                text += $"Product {item.Id}: {item.Name} - {item.Price:f2} lv.";
                text += "\r\n";
            }

            return Content(text);
        }
    }
}
