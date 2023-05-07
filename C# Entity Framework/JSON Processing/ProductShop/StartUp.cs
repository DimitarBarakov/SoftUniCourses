using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string json = File.ReadAllText(@"../../../Datasets/products.json");

            Console.WriteLine(ImportProducts(context,json));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var usersToAddAsDtos = JsonConvert.DeserializeObject<ImportUsersDto[]>(inputJson);
            var usersToAdd = new List<User>();
            foreach (var userDto in usersToAddAsDtos)
            {
                var user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };
                usersToAdd.Add(user);
            }
            context.Users.AddRange(usersToAdd);
            context.SaveChanges();
            return $"Successfully imported {usersToAdd.Count}";

        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productsToAddAsDtos = JsonConvert.DeserializeObject<ImportProductsDto[]>(inputJson);
            var productsToAdd = new List<Product>();
            foreach (var productDto in productsToAddAsDtos)
            {
                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                productsToAdd.Add(product);
            }
            context.Products.AddRange(productsToAdd);
            context.SaveChanges();
            return $"Successfully imported {productsToAdd.Count}";
        }
    }
}