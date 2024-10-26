using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Store_Management
{
    public class Store
    {
        public Product[] Products { get; private set; }
        private int productCount;
        public Store(int capacity)
        {
            Products = new Product[capacity];
            productCount = 0;
        }
        public void AddProduct(Product product)
        {

            if (productCount < Products.Length)
            {
                Products[productCount] = product;
                productCount++;
            }
            else
            {
                Console.WriteLine("Магазин заполнен, невозможно добавить больше товаров.");
            }
        }
        public void DisplayProducts()
        {
            for (int i = 0; i < productCount; i++)
            {
                if (Products[i] != null)
                {
                    Products[i].DisplayProductInfo();
                    Products[i].DisplayCategory();
                }
            }
        }
        public double CalculateTotalStoreValue()
        {
            double totalVale = 0;
            for (int i = 0; i < productCount; i++)
            {
                if (Products[i] != null)
                {
                    totalVale += Products[i].CalculateTotalPrice();
                }
            }
            return totalVale;
        }
        public void ApplyDiscountToProduct(int productIndex, Discount discount)
        {
            if (productIndex >= 0 && productIndex < productCount)
            {
                Products[productIndex].ApplyDiscount(discount);
                Console.WriteLine($"Cкидка{discount.Percentage}% Применена к товару {Products[productIndex].Name} ");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
    }
}