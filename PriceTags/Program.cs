using System;
using System.Collections.Generic;
using System.Globalization;
using PriceTags.Entities;

namespace PriceTags
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: "); 
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char resp = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (resp == 'u' || resp == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }

                else if(resp == 'i' || resp == 'I')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }

                else
                {
                    list.Add(new Product(name, price));
                }
            }

            Console.WriteLine("");
            Console.WriteLine("PRICE TAGS:");
            foreach(Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}