﻿using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;


        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductsInput();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {

                try
                {
                    string[] commandTokens = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.persons
                        .FirstOrDefault(p => p.Name == personName);

                    Product product = this.products
                        .FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, this.persons));
        }

        private void ReadPersonsInput()
        {
            string[] personTokens = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var pt in personTokens)
            {
                string[] personInfo = pt.Split("=");

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);

                this.persons.Add(person);
            }
        }

        private void ReadProductsInput()
        {
            string[] productsInput = Console.ReadLine()
                                       .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var pt in productsInput)
            {
                string[] productInfo = pt.Split("=");

                string name = productInfo[0];
                decimal money = decimal.Parse(productInfo[1]);

                Product product = new Product(name, money);

                this.products.Add(product);
            }
        }
    }
}
