using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management
{
    public enum ProductCategory
    {
        Food,
        Electronics,
        Clothing
    }
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public ProductCategory Category { get; private set; }
        public const double TAX_RATE = 0.2;
        public static int productCount = 0;

        public Product(string name, double price, ProductCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
            productCount++;
        }
        public double CalculateTotalPrice()
        {
            return Price + (Price * TAX_RATE);
        }
        public void ApplyDiscount(double discount)
        {
            Price -= Price * (discount / 100);
        }
        public void DisplayProductInfo()
        {
            Console.WriteLine($"Название товра: {Name}");
            Console.WriteLine($"Цена товара: {Price}");
            Console.WriteLine($"Цена с учетом налога: {CalculateTotalPrice()}");
        }
        public void DisplayCategory()
        {
            switch (Category)
            {
                case ProductCategory.Food:
                    Console.WriteLine("Категория товара : Продукты питания");
                    break;
                case ProductCategory.Electronics:
                    Console.WriteLine("Категория товра : Электороника");
                    break;
                case ProductCategory.Clothing:
                    Console.WriteLine("Категория товара : Ожежда");
                    break;
            }
        }
        public void CheckDiscount()
        {
            if (Price > 10)
            {
                ApplyDiscount(10);
                Console.WriteLine("Применена скидка 10%");

            }
        }
        public string CheckAvailability(int quanity)
        {
            return quanity > 0 ? "В наличии" : "Нет в наличии";
        }

    }

}
