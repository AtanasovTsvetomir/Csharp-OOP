using PizzaCalories.Models;
using System;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string[] doughInfo = Console.ReadLine().Split();

                Dough dough = CreateDough(doughInfo);

                Pizza pizza = CreatePizza(pizzaInfo, dough);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input.Split();

                    Topping topping = CreateTopping(toppingInfo);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private Topping CreateTopping(string[] toppingInfo)
        {
            string toppingType = toppingInfo[1];
            double toppingWeight = double.Parse(toppingInfo[2]);

            Topping topping = new Topping(toppingType, toppingWeight);

            return topping;
        }

        private Pizza CreatePizza(string[] pizzaInfo, Dough dough)
        {
            string pizzaName = pizzaInfo[1];

            Pizza pizza = new Pizza(pizzaName, dough);

            return pizza;
        }

        private Dough CreateDough(string[] doughInfo)
        {
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double flourWeight = double.Parse(doughInfo[3]);

            Dough dough = new Dough(flourType, bakingTechnique, flourWeight);

            return dough;
        }
    }
}
