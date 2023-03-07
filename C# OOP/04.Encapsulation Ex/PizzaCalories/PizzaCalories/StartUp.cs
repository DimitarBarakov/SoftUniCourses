using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaArgs[1]);

                string[] doughArgs = Console.ReadLine().Split();
                Dough dough = new Dough(doughArgs[1].ToLower(), doughArgs[2].ToLower(), double.Parse(doughArgs[3]));
                pizza.Dough = dough;
                string cmd;
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string[] toppingArgs = cmd.Split();
                    Topping topping = new Topping(toppingArgs[1].ToLower(), double.Parse(toppingArgs[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
